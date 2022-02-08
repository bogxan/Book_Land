using Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Services.Abstractions.Dto.Order;
using Services.Abstractions.Dto.Purchase;
using Services.Abstractions.Dto.StoreBook;
using Services.Abstractions.Service;
using Services.AutoMapper.Profiles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UI_Web.Models;
using UI_Web.Models.Home;
using UI_Web.Services;

namespace UI_Web.Controllers
{
    public class HomeController : Controller
    {
        IServiceManager _serviceManager;
        ISessionService _sessionService;
        UserManager<MyUser> _userManager;
        static List<StoreBookDto> booksSrch = new List<StoreBookDto>();
        static string srchWrd;
        public HomeController(ISessionService sessionService, IServiceManager serviceManager, UserManager<MyUser> userManager)
        {
            _sessionService = sessionService;
            _serviceManager = serviceManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            if(User.Identity.Name == "admin@gmail.com")
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                srchWrd = "";
                List<StoreBookDto> books = (await _serviceManager.StoreBooksService.GetAllAsync()).ToList();
                booksSrch = new List<StoreBookDto>();
                if (books.Count > 0)
                {
                    return View(new HomeIndexViewModel
                    {
                        Books = books,
                        SrchWrd = srchWrd
                    });
                }
                else
                {
                    return View(new HomeIndexViewModel
                    {
                        Books = books,
                        SrchWrd = "Empty"
                    });
                }
            }
        }
        public IActionResult MyError(string msg)
        {
            return View(msg);
        }
        [Authorize]
        public async Task<IActionResult> ShowMyOrders()
        {
            if (User.Identity.Name == "admin@gmail.com")
            {
                return RedirectToAction("Index", "Admin");
            }
            var orders = (await _serviceManager.OrdersService.GetAllAsync()).Where(u => u.MyUserId == Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)) && u.IsCompleted == true).ToList();
            return View(orders);
        }
        [Authorize]
        public async Task<IActionResult> ShowMyActiveOrders()
        {
            if (User.Identity.Name == "admin@gmail.com")
            {
                return RedirectToAction("Index", "Admin");
            }
            var orders = (await _serviceManager.OrdersService.GetAllAsync()).Where(u => u.MyUserId == Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)) && u.IsCompleted==false).ToList();
            return View(orders);
        }

        public async Task<IActionResult> Search(string srch)
        {
            if (User.Identity.Name == "admin@gmail.com")
            {
                return RedirectToAction("Index", "Admin");
            }
            if (srch != null)
            {
                if (srch.Length > 0 && srch.ToLower().Contains("drop table") ||
                srch.ToLower().Contains("truncate table") ||
                srch.ToLower().Contains("drop database"))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    booksSrch = (await _serviceManager.StoreBooksService.Search(srch)).ToList();
                    srchWrd = srch;
                    return View("Index", new HomeIndexViewModel
                    {
                        Books = booksSrch,
                        SrchWrd = srchWrd
                    });
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> FilterByNew()
        {
            if (User.Identity.Name == "admin@gmail.com")
            {
                return RedirectToAction("Index", "Admin");
            }
            if (booksSrch.Count > 0)
            {
                var books = booksSrch.ToList();
                books.Reverse();
                return View("Index", new HomeIndexViewModel
                {
                    Books = books,
                    SrchWrd = srchWrd
                });
            }
            else
            {
                var books = (await _serviceManager.StoreBooksService.GetAllAsync()).ToList();
                books.Reverse();
                return View("Index", new HomeIndexViewModel
                {
                    Books = books,
                    SrchWrd = srchWrd
                });
            }
        }

        public async Task<IActionResult> FilterByAlphabet()
        {
            if (User.Identity.Name == "admin@gmail.com")
            {
                return RedirectToAction("Index", "Admin");
            }
            if (booksSrch.Count > 0)
            {
                var books = booksSrch.OrderBy(u => u.Name).ToList();
                return View("Index", new HomeIndexViewModel
                {
                    Books = books,
                    SrchWrd = srchWrd
                });
            }
            else
            {
                var books = (await _serviceManager.StoreBooksService.GetAllAsync()).OrderBy(u => u.Name).ToList();
                return View("Index", new HomeIndexViewModel
                {
                    Books = books,
                    SrchWrd = srchWrd
                });
            }
        }

        public async Task<IActionResult> FilterByPriceLow()
        {
            if (User.Identity.Name == "admin@gmail.com")
            {
                return RedirectToAction("Index", "Admin");
            }
            if (booksSrch.Count > 0)
            {
                var books = booksSrch.OrderBy(u => u.Cost).ToList();
                return View("Index", new HomeIndexViewModel
                {
                    Books = books,
                    SrchWrd = srchWrd
                });
            }
            else
            {
                var books = (await _serviceManager.StoreBooksService.GetAllAsync()).OrderBy(u => u.Cost).ToList();
                return View("Index", new HomeIndexViewModel
                {
                    Books = books,
                    SrchWrd = srchWrd
                });
            }
        }

        public async Task<IActionResult> FilterByPriceHigh()
        {
            if (User.Identity.Name == "admin@gmail.com")
            {
                return RedirectToAction("Index", "Admin");
            }
            if (booksSrch.Count > 0)
            {
                var books = booksSrch.OrderByDescending(u => u.Cost).ToList();
                return View("Index", new HomeIndexViewModel
                {
                    Books = books,
                    SrchWrd = srchWrd
                });
            }
            else
            {
                var books = (await _serviceManager.StoreBooksService.GetAllAsync()).OrderByDescending(u => u.Cost).ToList();
                return View("Index", new HomeIndexViewModel
                {
                    Books = books,
                    SrchWrd = srchWrd
                });
            }
        }
        [Authorize]
        public async Task<IActionResult> InfoBook(Guid id)
        {
            if (User.Identity.Name == "admin@gmail.com")
            {
                return RedirectToAction("Index", "Admin");
            }
            var book = await _serviceManager.StoreBooksService.GetByIdAsync(id);
            if (book is null)
            {
                return View("MyError", new MyErrorViewModel { Message = "Сталася помилка!" });
            }
            return View(book);
        }

        [Authorize]
        public async Task<IActionResult> InfoOrder(Guid id)
        {
            if (User.Identity.Name == "admin@gmail.com")
            {
                return RedirectToAction("Index", "Admin");
            }
            var order = await _serviceManager.OrdersService.GetByIdAsync(id);
            if (order is null)
            {
                return View("MyError", new MyErrorViewModel { Message = "Сталася помилка!" });
            }
            return View(order);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddToCart(Guid id)
        {
            if (User.Identity.Name == "admin@gmail.com")
            {
                return RedirectToAction("Index", "Admin");
            }
            int s = 0;
            int k = 0;
            var purchases = _sessionService.GetCartProducts(HttpContext, "cart");
            var book = await _serviceManager.StoreBooksService.GetByIdAsync(id);
            int countBooks = 0;
            Guid purchaseId = Guid.NewGuid();
            double price = 0;
            if (book is null)
            {
                return View("MyError", new MyErrorViewModel { Message = "Сталася помилка!" });
            }
            foreach (var it in purchases)
            {
                if (it.BookId == book.Id)
                {
                    s += it.CountBooks;
                }
            }
            if (s+1 > book.Count)
            {
                return View("MyError", new MyErrorViewModel { Message = "Сталася помилка!" });
            }
            if (k == 0)
            {
                countBooks++;
                price += book.Cost * countBooks;
                var result = await _serviceManager.PurchasesService.CreateAsync(new CreatePurchaseDto
                {
                    BookId = book.Id,
                    Price = price,
                    CountBooks = countBooks,
                });
                purchaseId = result.Id;
                k++;
            }
            else
            {
                foreach (var item in purchases)
                {
                    if (item.BookId == book.Id)
                    {
                        var purchase = await _serviceManager.PurchasesService.GetByIdAsync(item.Id);
                        purchase.CountBooks++;
                        purchase.Price = book.Cost * item.CountBooks;
                        k++;
                        purchaseId = item.Id;
                    }
                }
            }
            
            _sessionService.AddProductToCart(HttpContext, "cart", await _serviceManager.PurchasesService.GetByIdAsync(purchaseId));
            StringValues referer;
            HttpContext.Request.Headers.TryGetValue("referer", out referer);
            return Redirect(referer.First());
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(Guid id)
        {
            if (User.Identity.Name == "admin@gmail.com")
            {
                return RedirectToAction("Index", "Admin");
            }
            int k = 0;
            Guid purchaseId = Guid.NewGuid();
            var book = await _serviceManager.StoreBooksService.GetByIdAsync(id);
            var purchases = _sessionService.GetCartProducts(HttpContext, "cart");
            if (book is null)
            {
                return View("MyError", new MyErrorViewModel { Message = "Сталася помилка!" });
            }
            foreach (var item in purchases)
            {
                if (item.BookId==book.Id)
                {
                    k++;
                    purchaseId = item.Id;
                }
            }
            if (k>0)
            {
                var res = await _serviceManager.PurchasesService.GetByIdAsync(purchaseId);
                _sessionService.RemoveProductFromCart(HttpContext, "cart", res);
            }
            StringValues referer;
            HttpContext.Request.Headers.TryGetValue("referer", out referer);
            return Redirect(referer.First());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public async Task<IActionResult> Submit()
        {
            if (User.Identity.Name == "admin@gmail.com")
            {
                return RedirectToAction("Index", "Admin");
            }
            double price = 0;
            var purchases = _sessionService.GetCartProducts(HttpContext, "cart");
            foreach (var item in purchases)
            {
                var tmp = await _serviceManager.StoreBooksService.GetByIdAsync(item.BookId);
                price += tmp.Cost;
            }
            if (purchases.Count <= 0)
            {
                return RedirectToAction("Index");
            }
            return View(new CreateOrderDto
            {
                Price = price
            });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Submit(CreateOrderDto model)
        {
            if (User.Identity.Name == "admin@gmail.com")
            {
                return RedirectToAction("Index", "Admin");
            }
            if (!ModelState.IsValid)
            {
                return View("MyError", new MyErrorViewModel { Message = "Сталася помилка!" });
            }
            else
            {
                int countBooks = 0;
                var purchasesInCart = _sessionService.GetCartProducts(HttpContext, "cart");
                var booksAll = (await _serviceManager.StoreBooksService.GetAllAsync()).ToList();
                foreach (var item in purchasesInCart)
                {
                    countBooks++;
                }
                var result = await _serviceManager.OrdersService.CreateAsync(new CreateOrderDto
                {
                    City = model.City,
                    Adress = model.Adress,
                    PostalCode = model.PostalCode,
                    MyUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)),
                    Price = model.Price,
                    CountBooks = countBooks
                });
                foreach (var item in booksAll)
                {
                    foreach (var it in purchasesInCart)
                    {
                        if (item.Id == it.BookId)
                        {
                            if (item.Count > it.CountBooks)
                            {
                                item.Count -= it.CountBooks;
                            }
                            else
                            {
                                item.Count = 0;
                            }
                            await _serviceManager.StoreBooksService.UpdateAsync(new UpdateStoreBookDto
                            {
                                Id = item.Id,
                                Name = item.Name,
                                Authors = item.Authors,
                                Cost = item.Cost,
                                Count = item.Count,
                                CountPages = item.CountPages,
                                Genre = item.Genre,
                                PublishOffice = item.PublishOffice,
                                PublishYear = item.PublishYear
                            });
                            _sessionService.RemoveProductFromCart(HttpContext, "cart", it);
                        }
                    }
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToArchive(Guid id)
        {
            if (User.Identity.Name == "admin@gmail.com")
            {
                return RedirectToAction("Index", "Admin");
            }
            var order = await _serviceManager.OrdersService.GetByIdAsync(id);
            if (order == null)
            {
                return View("MyError", new MyErrorViewModel { Message = "Сталася помилка!" });
            }
            order.IsCompleted = true;
            await _serviceManager.OrdersService.UpdateAsync(new UpdateOrderDto { 
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
            return RedirectToAction("ShowMyOrders");
        } 
    }
}
