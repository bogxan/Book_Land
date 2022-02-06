using AutoMapper;
using Domain.Entity;
using Services.Abstractions.Dto.Order;
using Services.Abstractions.Dto.Purchase;
using Services.Abstractions.Dto.StoreBook;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.AutoMapper.Profiles
{
    public class MapingProfile: Profile
    {
        public MapingProfile()
        {
            CreateMap<StoreBook, StoreBookDto>().ReverseMap();
            CreateMap<StoreBook, CreateStoreBookDto>().ReverseMap();
            CreateMap<StoreBook, UpdateStoreBookDto>().ReverseMap();
            CreateMap<StoreBookDto, CreateStoreBookDto>().ReverseMap();
            CreateMap<StoreBookDto, UpdateStoreBookDto>().ReverseMap();

            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderDto>().ReverseMap();
            CreateMap<OrderDto, CreateOrderDto>().ReverseMap();
            CreateMap<OrderDto, UpdateOrderDto>().ReverseMap();

            CreateMap<Purchase, PurchaseDto>().ReverseMap();
            CreateMap<Purchase, CreatePurchaseDto>().ReverseMap();
            CreateMap<Purchase, UpdatePurchaseDto>().ReverseMap();
            CreateMap<PurchaseDto, CreatePurchaseDto>().ReverseMap();
            CreateMap<PurchaseDto, UpdatePurchaseDto>().ReverseMap();

            CreateMap<Func<StoreBook>, Func<StoreBookDto>> ();
            CreateMap<Func<StoreBookDto>, Func<StoreBook>> ();
        }
    }
}
