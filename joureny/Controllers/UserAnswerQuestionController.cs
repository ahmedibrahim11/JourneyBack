using Framework.Data.EF;
using joureny.Data.Entities;
using joureny.Dtos;
using joureny.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace joureny.Controllers
{
    [RoutePrefix("userAnswer")]
    public class UserAnswerQuestionController : ApiController
    {
        private IUnitOfWorkFactory _unitOfwork;
        private IRepository<UserAnswerQuestion> _userAnswerQuestionRepo;
        private IRepository<User> _userRepo;

        public UserAnswerQuestionController(IUnitOfWorkFactory unitOfwork,
            IRepository<UserAnswerQuestion> userAnswerQuestionRepo,
            IRepository<User> userRepo)
        {
            _userAnswerQuestionRepo = userAnswerQuestionRepo;
            _unitOfwork = unitOfwork;
            _userRepo = userRepo;
        }

        [HttpPost]
        [Route("saveData/{userId:long}")]
        public IHttpActionResult Post([FromBody]List<UserAnswerQuestionModel> answers,long userId)
        {
            if (answers != null)
            {
                using (var uow = _unitOfwork.Create())
                {
                    foreach (var answer in answers)
                    {
                        var entity = new UserAnswerQuestion()
                        {
                            QuestionId = answer.QuestionId,
                            UserId = answer.UserId,
                            Value = answer.Value
                        };

                        _userAnswerQuestionRepo.Add(entity);
                    }

                    var user = _userRepo.Get(new Specification<User>(s => s.Id == userId)).FirstOrDefault();
                    if (user == null)
                        return NotFound();
                    user.HasRegistered = true;
                }
            }
            return Ok();
        }

        [HttpGet]
        [Route("GetUserAnswers/{userId:long}")]
        public IHttpActionResult Get(long userId)
        {
            if (userId != 0)
            {
             var _userAnswers = _userAnswerQuestionRepo.GetAll<UserAnswerQuestionDto>().Where(s => s.userId == userId).ToList();
                return Ok(_userAnswers);

            }
            return BadRequest();
        }
    }
}
