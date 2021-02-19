﻿using System.Linq;
using System.Collections.Generic;
using ShiningBeautySalon.Core.Model;
using ShiningBeautySalon.DAL.UnitOfWork;
using ShiningBeautySalon.Domain.Entities;
using ShiningBeautySalon.Service.Interfaces;

namespace ShiningBeautySalon.Service.Services
{
    public class SalonService : ISalonService
    {
        private readonly ShiningUnitOfWork _shiningUnitOfWork;
        public SalonService(ShiningUnitOfWork shiningUnitOfWork)
        {
            _shiningUnitOfWork = shiningUnitOfWork;
        }

        public IResponse<Salon> Add(Salon model)
        {
            _shiningUnitOfWork.SalonRepository.Add(model);
            _shiningUnitOfWork.SaveChanges();
            return new Response<Salon>
            {
                IsSuccessful = true,
                Result = model
            };
        }

        public IResponse<Salon> Update(Salon model)
        {
            _shiningUnitOfWork.SalonRepository.Update(model);
            _shiningUnitOfWork.SaveChanges();
            return new Response<Salon>
            {
                IsSuccessful = true,
                Result = model
            };
        }

        public IResponse<Salon> Delete(Salon model)
        {
            _shiningUnitOfWork.SalonRepository.Remove(model);
            _shiningUnitOfWork.SaveChanges();
            return new Response<Salon>
            {
                IsSuccessful = true,
                Result = model
            };
        }

        public IResponse<List<Salon>> GetAll()
        {
            var response = _shiningUnitOfWork.SalonRepository.Get().ToList();
            return new Response<List<Salon>>
            {
                IsSuccessful = true,
                Result = response
            };
        }

        public IResponse<Salon> GetByID(int salonId)
        {
            var response = _shiningUnitOfWork.SalonRepository.Find(x => x.ID == salonId).FirstOrDefault();
            return new Response<Salon>
            {
                IsSuccessful = true,
                Result = response
            };
        }
    }
}
