using Framework.Data.EF;
using joureny.Data.Entities;
using joureny.Helpers;
using joureny.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace joureny.Controllers
{
    public class AuthenicationController : ApiController
    {
        private readonly IRepository<User> _userRepo;
        private readonly IUnitOfWorkFactory _unitOfWork;

        public AuthenicationController(IRepository<User> userRepo, IUnitOfWorkFactory unitOfWork)
        {
            _userRepo = userRepo;
            _unitOfWork = unitOfWork;
        }


        [HttpPost]
        [Route("register")]
        public IHttpActionResult Post([FromBody]CreateUserModel user)
        {
            if (user != null)
            {

                User entity = new User()
                {
                    Password = user.Password,
                    UserName = user.UserName,
                    Email = user.Email,
                };
                using (_unitOfWork.Create())
                {
                    _userRepo.Add(entity);
                }

                return Ok(entity.Id);
            }

            return BadRequest();
        }



        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login([FromBody] UserModel user)
        {
            var entity = _userRepo.First(new Specification<User>(s=>s.Email==user.UserName & s.Password==user.Password));
            //test

            if (user != null)
            {
                return Ok(
                     new { token = JWTManager.GenerateToken(entity) }
                    );
            }

            else
                return BadRequest();

        }


    }
}
