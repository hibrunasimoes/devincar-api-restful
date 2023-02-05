using System;
using AutoMapper;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Exceptions;
using DEVinCar.Domain.Interfaces.Repository;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DEVinCar.Domain.Services;

public class DeliveryService : IDeliveryService
{
    private readonly IDeliveryRepository _deliveryRepository;
    private readonly IMapper _mapper;

    public DeliveryService(IDeliveryRepository deliveryRepository, IMapper mapper)
    {
        _deliveryRepository = deliveryRepository;
        _mapper = mapper;
    }

    public IList<DeliveryDTO> ListAll(int? addressId, int? saleId)
    {
        var query = _deliveryRepository.ListAll();

        if (addressId.HasValue)
            query = query.Where(a => a.AddressId == addressId);

        if (saleId.HasValue)
            query = query.Where(s => s.SaleId == saleId);

        if (!query.ToList().Any())
            throw new IsExistsException("Register not found!");

        return _mapper.Map<IList<DeliveryDTO>>(query).ToList();
    }
}

