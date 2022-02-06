using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Services.Abstractions.Dto.Purchase;
using Services.Abstractions.Dto.StoreBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI_Web.Services
{
    public class SessionService : ISessionService
    {
        public void AddProductToCart(HttpContext context, string key, PurchaseDto value)
        {
            if (context.Session.GetString(key) is null)
            {
                context.Session.SetString(key, JsonConvert.SerializeObject(new List<PurchaseDto>()));
            }

            var cartProducts = JsonConvert.DeserializeObject<List<PurchaseDto>>(context.Session.GetString(key));
            cartProducts.Add(value);
            context.Session.SetString(key, JsonConvert.SerializeObject(cartProducts));
        }

        public void RemoveProductFromCart(HttpContext context, string key, PurchaseDto value)
        {
            if (context.Session.GetString(key) is null)
            {
                context.Session.SetString(key, JsonConvert.SerializeObject(new List<PurchaseDto>()));
            }
            var cartProducts = JsonConvert.DeserializeObject<List<PurchaseDto>>(context.Session.GetString(key));
            cartProducts.Remove(cartProducts.FirstOrDefault(p => p.Id == value.Id));
            context.Session.SetString(key, JsonConvert.SerializeObject(cartProducts));
        }

        public List<PurchaseDto> GetCartProducts(HttpContext context, string key)
        {
            string json = context.Session.GetString(key);
            return json is null ? new List<PurchaseDto>() : JsonConvert.DeserializeObject<List<PurchaseDto>>(json);
        }

        public double GetPriceInCartProducts(HttpContext context, string key, PurchaseDto book)
        {
            double price = 0;
            var books = GetCartProducts(context, key);
            foreach (var item in books)
            {
                if (item.Id == book.Id)
                {
                    price = item.Price;
                }
            }
            return price;
        }

        public int GetCountProdInCart(HttpContext context, string key, PurchaseDto book)
        {
            int count = 0;
            var books = GetCartProducts(context, key);
            foreach (var item in books)
            {
                if (item.Id == book.Id)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
