using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using SecuritySystem.Core.Models;
using SecuritySystem.Core.Repositories;

namespace SecuritySystem.Web.Host.Controllers
{
    public class DoorController :  ControllerBase
    {
        IRepositoryBase<Door, Guid> _repository;
        public DoorController(IRepositoryBase<Door, Guid> repository)
        {
            _repository = repository;
        }
    }
}