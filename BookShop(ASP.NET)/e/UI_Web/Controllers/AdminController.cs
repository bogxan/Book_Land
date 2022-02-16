using Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions.Dto.Order;
using Services.Abstractions.Dto.StoreBook;
using Services.Abstractions.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI_Web.Models;
using UI_Web.Models.Admin;
using UI_Web.Services;

namespace UI_Web.Controllers
{
    public class AdminController : Controller
    {
        IServiceManager _serviceManager;
        ISessionService _sessionService;
        UserManager<MyUser> _userManager;
        static List<StoreBookDto> booksSrch = new List<StoreBookDto>();
        static string srchWrd;
        public AdminController(ISessionService sessionService, IServiceManager serviceManager, UserManager<MyUser> userManager)
        {
            _serviceManager = serviceManager;
            _sessionService = sessionService;
            _userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            if (User.Identity.Name != "admin@gmail.com")
            {
                return RedirectToAction("Index", "Home");
            }
            srchWrd = "";
            List<StoreBookDto> books = (await _serviceManager.StoreBooksService.GetAllAsync()).ToList();
            booksSrch = new List<StoreBookDto>();
            if (books.Count > 0)
            {
                return View(new HomeIndexBookViewModel
                {
                    Books = books,
                    SrchWrd = srchWrd
                });
            }
            else
            {
                return View(new HomeIndexBookViewModel
                {
                    Books = books,
                    SrchWrd = "Empty"
                });
            }
        }

        public IActionResult MyError(string msg)
        {
            return View(msg);
        }

        [Authorize]
        public async Task<IActionResult> IndexOrders()
        {
            if (User.Identity.Name != "admin@gmail.com")
            {
                return RedirectToAction("Index", "Home");
            }
            List<OrderDto> orders = (await _serviceManager.OrdersService.GetAllAsync()).ToList();
            return View(new HomeIndexOrderViewModel
            {
                Orders = orders
            });
        }

        // GET: AdminController/Details/5
        [Authorize]
        public async Task<IActionResult> DetailsBook(Guid id)
        {
            if (User.Identity.Name != "admin@gmail.com")
            {
                return RedirectToAction("Index", "Home");
            }
            var book = await _serviceManager.StoreBooksService.GetByIdAsync(id);
            if (book is null)
            {
                return View("MyError", new MyErrorViewModel { Message = "Сталася помилка!" });
            }
            return View(book);
        }
        [Authorize]
        public async Task<IActionResult> DetailsOrder(Guid id)
        {
            if (User.Identity.Name != "admin@gmail.com")
            {
                return RedirectToAction("Index", "Home");
            }
            var order = await _serviceManager.OrdersService.GetByIdAsync(id);
            if (order is null)
            {
                return View("MyError", new MyErrorViewModel { Message = "Сталася помилка!"});
            }
            return View(order);
        }

        // GET: AdminController/Create
        [Authorize]
        public IActionResult Create()
        {
            if (User.Identity.Name != "admin@gmail.com")
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateStoreBookDto model)
        {
            if (User.Identity.Name != "admin@gmail.com")
            {
                return RedirectToAction("Index", "Home");
            }
            if (!ModelState.IsValid)
            {
                return View("MyError", new MyErrorViewModel { Message = "Сталася помилка!"});
            }
            else
            {
                //Guid id = Guid.NewGuid();
                int k = 0;
                var books = await _serviceManager.StoreBooksService.GetAllAsync();
                foreach(var book in books)
                {
                    if(book.Name.ToLower() == model.Name.ToLower() && book.Authors.ToLower() == model.Authors.ToLower() && book.Genre.ToLower() == model.Genre.ToLower()
                        && book.CountPages==model.CountPages && book.PublishOffice.ToLower() == model.PublishOffice.ToLower()
                        && book.PublishYear==model.PublishYear && book.Cost==model.Cost)
                    {
                        //id = book.Id;
                        k++;
                    }
                }
                if (k > 0)
                {
                    return View("MyError", new MyErrorViewModel
                    {
                        Message = "Така книга в магазині вже існує!"
                    });
                }
                else
                {
                    await _serviceManager.StoreBooksService.CreateAsync(new CreateStoreBookDto
                    {
                        Authors = model.Authors,
                        Cost = model.Cost,
                        Count = model.Count,
                        CountPages = model.CountPages,
                        Genre = model.Genre,
                        Name = model.Name,
                        PublishOffice = model.PublishOffice,
                        PublishYear = model.PublishYear
                    });
                }
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Search(string srch)
        {
            if (User.Identity.Name != "admin@gmail.com")
            {
                return RedirectToAction("Index", "Home");
            }
            if (srch != null)
            {
                if (srch.Length < 0 || srch.Length > 20 || srch.ToLower().Contains("drop table") ||
                srch.ToLower().Contains("truncate table") ||
                srch.ToLower().Contains("drop database"))
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    booksSrch = (await _serviceManager.StoreBooksService.Search(srch)).ToList();
                    srchWrd = srch;
                    return View("Index", new HomeIndexBookViewModel
                    {
                        Books = booksSrch,
                        SrchWrd = srch
                    });
                }
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
        }
        [Authorize]
        public async Task<IActionResult> FilterByNew()
        {
            if (User.Identity.Name != "admin@gmail.com")
            {
                return RedirectToAction("Index", "Home");
            }
            if (booksSrch.Count > 0)
            {
                var books = booksSrch.ToList();
                books.Reverse();
                return View("Index", new HomeIndexBookViewModel
                {
                    Books = books,
                    SrchWrd = srchWrd
                });
            }
            else
            {
                var books = (await _serviceManager.StoreBooksService.GetAllAsync()).ToList();
                books.Reverse();
                return View("Index", new HomeIndexBookViewModel
                {
                    Books = books,
                    SrchWrd = srchWrd
                });
            }
        }
        [Authorize]
        public async Task<IActionResult> FilterByAlphabet()
        {
            if (User.Identity.Name != "admin@gmail.com")
            {
                return RedirectToAction("Index", "Home");
            }
            if (booksSrch.Count > 0)
            {
                var books = booksSrch.OrderBy(u => u.Name).ToList();
                return View("Index", new HomeIndexBookViewModel
                {
                    Books = books,
                    SrchWrd = srchWrd
                });
            }
            else
            {
                var books = (await _serviceManager.StoreBooksService.GetAllAsync()).OrderBy(u => u.Name).ToList();
                return View("Index", new HomeIndexBookViewModel
                {
                    Books = books,
                    SrchWrd = srchWrd
                });
            }
        }
        [Authorize]
        public async Task<IActionResult> FilterByPriceLow()
        {
            if (User.Identity.Name != "admin@gmail.com")
            {
                return RedirectToAction("Index", "Home");
            }
            if (booksSrch.Count > 0)
            {
                var books = booksSrch.OrderBy(u => u.Cost).ToList();
                return View("Index", new HomeIndexBookViewModel
                {
                    Books = books,
                    SrchWrd = srchWrd
                });
            }
            else
            {
                var books = (await _serviceManager.StoreBooksService.GetAllAsync()).OrderBy(u => u.Cost).ToList();
                return View("Index", new HomeIndexBookViewModel
                {
                    Books = books,
                    SrchWrd = srchWrd
                });
            }
        }
        [Authorize]
        public async Task<IActionResult> FilterByPriceHigh()
        {
            if (User.Identity.Name != "admin@gmail.com")
            {
                return RedirectToAction("Index", "Home");
            }
            if (booksSrch.Count > 0)
            {
                var books = booksSrch.OrderByDescending(u => u.Cost).ToList();
                return View("Index", new HomeIndexBookViewModel
                {
                    Books = books,
                    SrchWrd = srchWrd
                });
            }
            else
            {
                var books = (await _serviceManager.StoreBooksService.GetAllAsync()).OrderByDescending(u => u.Cost).ToList();
                return View("Index", new HomeIndexBookViewModel
                {
                    Books = books,
                    SrchWrd = srchWrd
                });
            }
        }

        // GET: AdminController/Edit/5
        [Authorize]
        public async Task<IActionResult> EditBook(Guid id)
        {
            if (User.Identity.Name != "admin@gmail.com")
            {
                return RedirectToAction("Index", "Home");
            }
            var book = await _serviceManager.StoreBooksService.GetByIdAsync(id);
            if (book != null)
            {
                return View(book);
            }
            else
            {
                return View("MyError", new MyErrorViewModel { Message = "Сталася помилка!" });
            }
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditBook(StoreBookDto model)
        {
            if (User.Identity.Name != "admin@gmail.com")
            {
                return RedirectToAction("Index", "Home");
            }
            if (!ModelState.IsValid)
            {
                return View("MyError", new MyErrorViewModel { Message = "Сталася помилка!" });
            }
            else
            {
                //Guid id = Guid.Empty;
                int k = 0;
                var books = await _serviceManager.StoreBooksService.GetAllAsync();
                foreach (var book in books)
                {
                    if (book.Name.ToLower() == model.Name.ToLower() && book.Authors.ToLower() == model.Authors.ToLower() && book.Genre.ToLower() == model.Genre.ToLower()
                        && book.CountPages == model.CountPages && book.PublishOffice.ToLower() == model.PublishOffice.ToLower()
                        && book.PublishYear == model.PublishYear && book.Cost == model.Cost && book.Count == model.Count)
                    {
                        k++;
                    }
                }
                if (k > 0)
                {
                    return View("MyError", new MyErrorViewModel
                    {
                        Message = "Така книга в магазині вже існує!"
                    });
                }
                else
                {
                    var books_cart = _sessionService.GetCartProducts(HttpContext, "cart");
                    if (books_cart != null)
                    {
                        foreach (var item in books_cart)
                        {
                            if (item.Id == model.Id)
                            {
                                await _serviceManager.StoreBooksService.UpdateAsync(new UpdateStoreBookDto
                                {
                                    Id = item.BookId,
                                    Authors = item.Book.Authors,
                                    Cost = item.Book.Cost,
                                    PublishOffice = item.Book.PublishOffice,
                                    Count = item.Book.Count,
                                    CountPages = item.Book.CountPages,
                                    Genre = item.Book.Genre,
                                    Name = item.Book.Name,
                                    PublishYear = item.Book.PublishYear
                                });
                            }
                        }
                    }
                    await _serviceManager.StoreBooksService.UpdateAsync(new UpdateStoreBookDto
                    {
                        Id = model.Id,
                        Name = model.Name,
                        Authors = model.Authors,
                        Cost = model.Cost,
                        Count = model.Count,
                        CountPages = model.CountPages,
                        Genre = model.Genre,
                        PublishOffice = model.PublishOffice,
                        PublishYear = model.PublishYear
                    });
                }
                return RedirectToAction("Index");
            }
        }

        [Authorize]
        public async Task<IActionResult> EditOrder(Guid id)
        {
            if (User.Identity.Name != "admin@gmail.com")
            {
                return RedirectToAction("Index", "Home");
            }
            var order = await _serviceManager.OrdersService.GetByIdAsync(id);
            if (order != null)
            {
                return View(order);
            }
            else
            {
                return View("MyError", new MyErrorViewModel { Message = "Сталася помилка!" });
            }
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditOrder(OrderDto model)
        {
            if (User.Identity.Name != "admin@gmail.com")
            {
                return RedirectToAction("Index", "Home");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                await _serviceManager.OrdersService.UpdateAsync(new UpdateOrderDto
                {
                    Id = model.Id,
                    IsCompleted = model.IsCompleted,
                    Adress = model.Adress,
                    City = model.City,
                    CountBooks = model.CountBooks,
                    MyUserId = model.MyUserId,
                    PostalCode = model.PostalCode,
                    CreatedAt = model.CreatedAt,
                    Price = model.Price
                });
                return RedirectToAction("IndexOrders");
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToArchive(Guid id)
        {
            if (User.Identity.Name != "admin@gmail.com")
            {
                return RedirectToAction("Index", "Home");
            }
            var order = await _serviceManager.OrdersService.GetByIdAsync(id);
            if (order != null)
            {
                order.IsCompleted = true;
                await _serviceManager.OrdersService.UpdateAsync(new UpdateOrderDto
                {
                    Id = order.Id,
                    Adress = order.Adress,
                    Price = order.Price,
                    City = order.City,
                    CountBooks = order.CountBooks,
                    PostalCode = order.PostalCode,
                    MyUserId = order.MyUserId,
                    IsCompleted = order.IsCompleted,
                    CreatedAt = order.CreatedAt
                });
                return RedirectToAction("IndexOrders");
            }
            else
            {
                return View("MyError", new MyErrorViewModel { Message = "Сталася помилка!" });
            }
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            if (User.Identity.Name != "admin@gmail.com")
            {
                return RedirectToAction("Index", "Home");
            }
            var books = _sessionService.GetCartProducts(HttpContext, "cart");
            foreach (var item in books)
            {
                if (item.Id == id)
                {
                    _sessionService.RemoveProductFromCart(HttpContext, "cart", item);
                }
            }
            await _serviceManager.StoreBooksService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            if (User.Identity.Name != "admin@gmail.com")
            {
                return RedirectToAction("Index", "Home");
            }
            var order = await _serviceManager.OrdersService.GetByIdAsync(id);
            if (order != null)
            {
                foreach (var item in order.Purchases)
                {
                    var book = await _serviceManager.StoreBooksService.GetByIdAsync(item.Id);
                    book.Count++;
                    await _serviceManager.StoreBooksService.UpdateAsync(new UpdateStoreBookDto
                    {
                        Id = book.Id,
                        Name = book.Name,
                        Authors = book.Authors,
                        Cost = book.Cost,
                        Count = book.Count,
                        CountPages = book.CountPages,
                        Genre = book.Genre,
                        PublishOffice = book.PublishOffice,
                        PublishYear = book.PublishYear
                    });
                }
                await _serviceManager.OrdersService.DeleteAsync(id);
                return RedirectToAction("IndexOrders");
            }
            else
            {
                return View("MyError", new MyErrorViewModel { Message = "Сталася помилка!" });
            }
        }

        public IActionResult IndexAccount()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> ChangePassword(string id)
        {
            if (User.Identity.Name != "admin@gmail.com")
            {
                return RedirectToAction("Index", "Home");
            }
            MyUser user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return View("MyError", new MyErrorViewModel { Message = "Сталася помилка!" });
            }
            ChangePasswordViewModel model = new ChangePasswordViewModel { Id = user.Id, Email = user.Email };
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (User.Identity.Name != "admin@gmail.com")
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                if ((model.NewPassword.ToLower().Contains("droptable") ||
                model.NewPassword.ToLower().Contains("truncatetable") ||
                model.NewPassword.ToLower().Contains("dropdatabase")) && 
                (model.OldPassword.ToLower().Contains("droptable") ||
                model.OldPassword.ToLower().Contains("truncatetable") ||
                model.OldPassword.ToLower().Contains("dropdatabase")))
                {
                    return RedirectToAction("Index", "Admin");
                }
                MyUser user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
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
                    ModelState.AddModelError(string.Empty, "Пользователь не найден");
                }
            }
            return View(model);
        }
    }
}
