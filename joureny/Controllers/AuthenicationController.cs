using Framework.Data.EF;
using joureny.Data.Entities;
using joureny.Dtos;
using joureny.Helpers;
using joureny.Models;
using journey.Utilities.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace joureny.Controllers
{
    [RoutePrefix("auth")]
    public class AuthenicationController : ApiController
    {
        private readonly IRepository<User> _userRepo;
        private readonly IUnitOfWorkFactory _unitOfWork;

        private readonly IEncryptionService _encryptionService;

        public AuthenicationController(IRepository<User> userRepo, IUnitOfWorkFactory unitOfWork, IEncryptionService encryptionService)
        {
            _userRepo = userRepo;
            _unitOfWork = unitOfWork;
            _encryptionService = encryptionService;
        }


        [HttpPost]
        [Route("register")]
        public IHttpActionResult Post([FromBody]CreateUserModel user)
        {
            if (user != null)
            {
                var enSaltKey = _encryptionService.CreateSaltKey(8);
                var enPassword = _encryptionService.CreatePasswordHash(user.Password, enSaltKey);

                User entity = new User()
                {
                    PasswordSalt = enSaltKey,
                    Password = enPassword,
                    UserName = user.UserName,
                    Email = user.Email,
                    Gender=(Gender)user.Gender
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
            var entity = _userRepo.First(new Specification<User>(s => s.Email == user.Email));

            var passwordHash = _encryptionService.CreatePasswordHash(user.Password, entity.PasswordSalt);
            if (user.Password != entity.Password)
                return BadRequest();

            if (user != null)
            {
                return Ok(
                     new { token = JWTManager.GenerateToken(entity) }
                    );
            }

            else
                return BadRequest();

        }


        [HttpPost]
        [Route("changepassword/{Id:long}")]
        public IHttpActionResult ChangePassword(long Id, ChangePasswordModel model)
        {
            var mbership = _userRepo.First(new Specification<User>(u => u.Id == Id));
            if (mbership == null)
                return NotFound();
            var passwordHash = _encryptionService.CreatePasswordHash(model.OldPassword, mbership.PasswordSalt);
            if (passwordHash != mbership.Password)
                return BadRequest("Old Password is inCorrect");

            using (var uow = _unitOfWork.Create())
            {
                var enSaltKey = _encryptionService.CreateSaltKey(4);
                var enPassword = _encryptionService.CreatePasswordHash(model.NewPassword, enSaltKey);
                mbership.PasswordSalt = enSaltKey;
                mbership.Password = enPassword;
            }
            return Ok();
        }

        [HttpGet]
        [Route("userInfo/{userId}")]
        public IHttpActionResult GetUserInfo(long userId)
        {
            var User = _userRepo.First<UserDto>(new Specification<User>(s => s.Id == userId));
            if (User != null)
                return Ok(User);
            return NotFound();
        }
    }


}
