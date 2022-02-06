using Microsoft.AspNetCore.Http;
using Services.Abstractions.Dto.Purchase;
using Services.Abstractions.Dto.StoreBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI_Web.Services
{
    public interface ISessionService
    {
        void AddProductToCart(HttpContext context, string key, PurchaseDto value);
        void RemoveProductFromCart(HttpContext context, string key, PurchaseDto value);
        List<PurchaseDto> GetCartProducts(HttpContext context, string key);
        double GetPriceInCartProducts(HttpContext context, string key, PurchaseDto book);
        int GetCountProdInCart(HttpContext context, string key, PurchaseDto book);
    }
}
