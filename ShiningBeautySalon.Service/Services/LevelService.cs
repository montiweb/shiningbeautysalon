﻿using System.Linq;
using System.Collections.Generic;
using ShiningBeautySalon.Core.Model;
using ShiningBeautySalon.DAL.UnitOfWork;
using ShiningBeautySalon.Domain.Entities;
using ShiningBeautySalon.Service.Interfaces;

namespace ShiningBeautySalon.Service.Services
{
    public class LevelService : ILevelService
    {
        private readonly ShiningUnitOfWork _shiningUnitOfWork;
        public LevelService(ShiningUnitOfWork shiningUnitOfWork)
        {
            _shiningUnitOfWork = shiningUnitOfWork;
        }

        public IResponse<Level> Add(Level model)
        {
            _shiningUnitOfWork.LevelRepository.Add(model);
            _shiningUnitOfWork.SaveChanges();
            return new Response<Level>
            {
                IsSuccessful = true,
                Result = model
            };
        }

        public IResponse<Level> Update(Level model)
        {
            _shiningUnitOfWork.LevelRepository.Update(model);
            _shiningUnitOfWork.SaveChanges();
            return new Response<Level>
            {
                IsSuccessful = true,
                Result = model
            };
        }

        public IResponse<Level> Delete(Level model)
        {
            _shiningUnitOfWork.LevelRepository.Remove(model);
            _shiningUnitOfWork.SaveChanges();
            return new Response<Level>
            {
                IsSuccessful = true,
                Result = model
            };
        }

        public IResponse<List<Level>> GetAll()
        {
            var response = _shiningUnitOfWork.LevelRepository.Get().ToList();
            return new Response<List<Level>>
            {
                IsSuccessful = true,
                Result = response
            };
        }

        public IResponse<Level> GetByID(int levelId)
        {
            var response = _shiningUnitOfWork.LevelRepository.Find(x => x.ID == levelId).FirstOrDefault();
            return new Response<Level>
            {
                IsSuccessful = true,
                Result = response
            };
        }

    }
}
