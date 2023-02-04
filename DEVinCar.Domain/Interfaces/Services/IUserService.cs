using System;
using DEVinCar.Domain.DTOs;

namespace DEVinCar.Domain.Interfaces.Services
{
    public interface IUserService
    {
        IList<UserDTO> ListAll(string name, DateTime? birthDateMax, DateTime? birthDateMin);
        UserDTO GetById(int id);
        IList<SaleDTO> GetBuyerByUserID(int id);
        IList<SaleDTO> GetSalesByUserID(int id);
        void Insert(UserDTO dto);
        void InsertSale(int userId, SaleDTO DTO);
        void InsertBuy(int userId, BuyDTO DTO);
        void DeleteUser(int id);
        UserDTO GetByUser(LoginDTO login);
    }
}

