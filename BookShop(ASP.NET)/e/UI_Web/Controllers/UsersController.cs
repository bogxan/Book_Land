using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Domain.Entity;
using UI_Web.Models.Home;
using Services.Abstractions.Service;
using Microsoft.AspNetCore.Authorization;
using UI_Web.Models.Users;

namespace CustomIdentityApp.Controllers
{
    public class UsersController : Controller
    {
        UserManager<MyUser> _userManager;
        IServiceManager _serviceManager;
        private readonly SignInManager<MyUser> _signInManager;
        public UsersController(IServiceManager serviceManager, UserManager<MyUser> userManager, SignInManager<MyUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _serviceManager = serviceManager;
        }
        [Authorize]
        public IActionResult Index()
        {
            if (User.Identity.Name == "admin@gmail.com")
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            if (User.Identity.Name == "admin@gmail.com")
            {
                return RedirectToAction("Index", "Admin");
            }
            MyUser user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return View("MyError", new UI_Web.Models.Users.MyErrorViewModel { Message = "Сталася помилка!" });
            }
            EditUserViewModel model = new EditUserViewModel { 
                Id = user.Id, 
                Email = user.Email, 
                FirstName = user.FirstName, 
                LastName = user.LastName, 
                Password = user.Password, 
                PhoneNumber = user.PhoneNumber 
            };
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (User.Identity.Name == "admin@gmail.com")
            {
                return RedirectToAction("Index", "Admin");
            }
            if (model.PhoneNumber == "+380673938899" || model.PhoneNumber == "+380958178480")
            {
                return RedirectToAction("Index", "Users");
            }
            if (ModelState.IsValid)
            {
                MyUser user = await _userManager.FindByIdAsync(model.Id.ToString());
                if (user != null)
                {
                    var orders = (await _serviceManager.OrdersService.GetAllAsync()).Where(x => x.MyUserId.ToString() == user.Id);
                    if (orders != null)
                    {
                        int k = 0;
                        foreach (var order in orders)
                        {
                            if (order.IsCompleted == false)
                            {
                                k++;
                            }
                        }
                        if (k > 0)
                        {
                            return View("MyError", new UI_Web.Models.Users.MyErrorViewModel { Message = "Ви маєте активні замовлення!" });
                        }
                    }
                    user.Id = model.Id;
                    user.Email = model.Email;
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.PhoneNumber = model.PhoneNumber;
                    user.Password = model.Password;
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Delete(string id)
        {
            if (User.Identity.Name == "admin@gmail.com")
            {
                return RedirectToAction("Index", "Admin");
            }
            MyUser user = await _userManager.FindByIdAsync(id);
            if (user==null)
            {
                return View("MyError", new UI_Web.Models.Users.MyErrorViewModel { Message = "Сталася помилка!" });
            }
            if (user != null)
            {
                var orders = (await _serviceManager.OrdersService.GetAllAsync()).Where(x=>x.MyUserId.ToString()==user.Id);
                if(orders != null)
                {
                    int k = 0;
                    foreach (var order in orders)
                    {
                        if(order.IsCompleted == false)
                        {
                            k++;
                        }
                    }
                    if (k > 0)
                    {
                        return View("MyError", new UI_Web.Models.Users.MyErrorViewModel { Message = "Ви маєте активні замовлення!" });
                    }
                    else
                    {
                        foreach (var order in orders)
                        {
                            await _serviceManager.OrdersService.DeleteAsync(order.Id);
                        }
                        await _signInManager.SignOutAsync();
                    }
                }
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult MyError(string msg)
        {
            return View(msg);
        }

        [Authorize]
        public async Task<IActionResult> ChangePassword(string id)
        {
            if (User.Identity.Name == "admin@gmail.com")
            {
                return RedirectToAction("Index", "Admin");
            }
            MyUser user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return View("MyError", new UI_Web.Models.Users.MyErrorViewModel { Message = "Сталася помилка!" });
            }
            ChangePasswordViewModel model = new ChangePasswordViewModel { Id = user.Id, Email = user.Email };
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (User.Identity.Name == "admin@gmail.com")
            {
                return RedirectToAction("Index", "Admin");
            }
            if (ModelState.IsValid)
            {
                if (model.NewPassword.ToLower().Contains("droptable") ||
                model.NewPassword.ToLower().Contains("truncatetable") ||
                model.NewPassword.ToLower().Contains("dropdatabase"))
                {
                    return RedirectToAction("Index", "Users");
                }
                MyUser user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    if (user.Password != model.OldPassword)
                    {
                        return View("MyError", new UI_Web.Models.Users.MyErrorViewModel { Message = "Паролі не співпадають!" });
                    }
                    IdentityResult result =
                        await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        user.Password = model.NewPassword;
                        await _userManager.UpdateAsync(user);
                        return RedirectToAction("Login", "Account");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Користувача не знайдено!");
                }
            }
            return View(model);
        }
    }
}