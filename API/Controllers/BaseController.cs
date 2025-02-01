using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        private  IMediator _mediator;

        public IMediator Mediator => _mediator??=HttpContext.RequestServices.GetService<IMediator>();
    }
}