using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Domain.Models;

namespace TimeSheet.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly IMapper _mapper;
        protected  LoggedUser _user { get
            {
                return (LoggedUser)HttpContext.Items["loggedUser"];
            }
        }
        public BaseController(IMapper mapper) { 
            _mapper = mapper;
            
        }

    }
}
