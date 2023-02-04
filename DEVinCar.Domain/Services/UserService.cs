using System;
using System.Security.Authentication;
using AutoMapper;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Interfaces.Repository;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DEVinCar.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public void DeleteUser(int id)
        {
            var userDb = _userRepository.GetById(id);
            if (userDb == null)
            {
                throw new NotImplementedException();
            }

            _userRepository.Delete(userDb);
        }

        public IList<SaleDTO> GetBuyerByUserID(int id)
        {
            var buyerByUserId = _userRepository.GetBuyerByUserID(id);
            if (!buyerByUserId.ToList().Any())
            {
                throw new NotImplementedException();
            }

            return _mapper.Map<IList<SaleDTO>>(buyerByUserId);
        }

        public UserDTO GetById(int id)
        {
            var userDb = _userRepository.GetById(id);
            return _mapper.Map<UserDTO>(userDb);
        }

        public UserDTO GetByUser(int id)
        {
            var userDb = _userRepository.GetById(id);
            if (userDb == null)
                throw new NotImplementedException();

            return _mapper.Map<UserDTO>(userDb);
        }

        public UserDTO GetByUser(LoginDTO login)
        {
            var userDb = _userRepository.GetByUser(login);
            if (userDb == null)
                throw new NotImplementedException();

            return _mapper.Map<UserDTO>(userDb);
        }

        public IList<SaleDTO> GetSalesByUserID(int id)
        {
            var salesByUserId = _userRepository.GetSalesByUserID(id);
            if (!salesByUserId.ToList().Any())
            {
                throw new NotImplementedException();
            }

            return _mapper.Map<IList<SaleDTO>>(salesByUserId);
        }

        public void Insert(UserDTO dto)
        {
            _userRepository.Insert(_mapper.Map<User>(dto));
        }

        public void InsertBuy(int userId, BuyDTO DTO)
        {
            var userDb = _userRepository.GetById(userId);
            var seller = _userRepository.GetById(DTO.SellerId);
            if (seller == null)
            {
                throw new NotImplementedException();
            }
            if (userDb == null)
            {
                throw new NotImplementedException();
            }
            Sale buy = _mapper.Map<Sale>(DTO);
            buy.BuyerId = userId;

            _userRepository.InsertSale(buy);
        }

        public void InsertSale(int userId, SaleDTO DTO)
        {
            var userDb = _userRepository.GetById(userId);
            var buyer = _userRepository.GetById(DTO.BuyerId);

            if (userDb == null)
            {
                throw new NotImplementedException();
            }

            if (buyer == null)
            {
                throw new NotImplementedException();
            }

            DTO.SellerId = userId;
            _userRepository.InsertSale(_mapper.Map<Sale>(DTO));
        }

        public IList<UserDTO> ListAll(string name, DateTime? birthDateMax, DateTime? birthDateMin)
        {
            var query = _userRepository.ListAll().AsQueryable();

            if (!String.IsNullOrEmpty(name))
                query = query.Where(u => u.Name.Contains(name));

            if (birthDateMin.HasValue)
                query = query.Where(c => c.BirthDate >= birthDateMin.Value);

            if (birthDateMax.HasValue)
                query = query.Where(c => c.BirthDate <= birthDateMax.Value);

            if (!query.ToList().Any())
            {
                throw new NotImplementedException();
            }

            return _mapper.Map<IList<UserDTO>>(query).ToList();
        }
    }
}

