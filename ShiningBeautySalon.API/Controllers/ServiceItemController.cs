﻿using System;

using Microsoft.AspNetCore.Mvc;

using ShiningBeautySalon.Domain.Entities;
using ShiningBeautySalon.Service.Interfaces;

namespace ShiningBeautySalon.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ServiceItemController : ControllerBase
    {
        private readonly IServiceItemService _serviceItemService;
        public ServiceItemController(IServiceItemService serviceItemService)
        {
            _serviceItemService = serviceItemService;
        }
        public IActionResult GetAll()
        {
            throw new NotImplementedException();
        }

        public IActionResult GetByID(int ID)
        {
            throw new NotImplementedException();
        }
        public IActionResult Add(ServiceItem model)
        {
            throw new NotImplementedException();
        }

        public IActionResult Delete(ServiceItem model)
        {
            throw new NotImplementedException();
        }

        public IActionResult Update(ServiceItem model)
        {
            throw new NotImplementedException();
        }
    }
}
