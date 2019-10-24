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
        private readonly IRepository<UserAnswerQuestion> _userAnswers;

        private readonly IEncryptionService _encryptionService;

        public AuthenicationController(IRepository<User> userRepo, IUnitOfWorkFactory unitOfWork, IEncryptionService encryptionService, IRepository<UserAnswerQuestion> userAnswers)
        {
            _userRepo = userRepo;
            _unitOfWork = unitOfWork;
            _userAnswers = userAnswers;
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
                using (var uow=_unitOfWork.Create())
                {
                    entity.PushToken = user.TokenPush;
                }
                var job = _userAnswers.GetAll<UserAnswerQuestionDto>().Where(s => s.userId == entity.Id && s.QuestionId == 47).ToList().FirstOrDefault().Value;
                return Ok(
                     new {
                         token = JWTManager.GenerateToken(entity),
                         name = entity.UserName,
                         jobtitle = job
                     });
            }

            else
                return BadRequest();

        }


        [HttpPost]
        [Route("changepassword/{Id:long}")]
        public IHttpActionResult ChangePassword(long Id, ChangePasswordModel model)
        {
            using (var uow=_unitOfWork.Create())
            {
                var user = _userRepo.First(new Specification<User>(u => u.Id == Id));
                if (user == null)
                    return NotFound();

                if (user.Password == model.OldPassword)
                {
                    user.Password = model.NewPassword;
                }
                else
                {
                    return BadRequest();
                }
                return Ok();
            }
            
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
