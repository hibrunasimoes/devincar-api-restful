using System;
using DEVinCar.Domain.DTOs;

namespace DEVinCar.Domain.Interfaces.Services
{
    public interface IUserService
    {
        IList<UserDTO> ListAll();
        UserDTO GetById(int id);
        IList<SaleCarDTO> GetBuyerByUserID(int id);
        IList<SaleCarDTO> GetSalesByUserID(int id);
        void Insert(UserDTO dto);
        void InsertSale(int userId, SaleDTO DTO);
        void InsertBuy(int userId, BuyDTO DTO);
        void DeleteUser(int id);
    }
}

