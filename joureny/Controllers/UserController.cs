using Framework.Data.EF;
using joureny.Data.Entities;
using joureny.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace joureny.Controllers
{
    [RoutePrefix("user")]
    public class UserController : ApiController
    {
        private IRepository<Feedback> _helpRepo;
        private IUnitOfWorkFactory _unitOfwork;
        public UserController(IRepository<Feedback> helpRepo, IUnitOfWorkFactory unitOfwork)
        {
            _helpRepo = helpRepo;
            _unitOfwork = unitOfwork;
        }

        [HttpPost]
        [Route("feedback/{userId:long}")]
        public IHttpActionResult createFeedback(long userId,FeedbackModel model)
        {
            if (model == null)
                return BadRequest();
            using (_unitOfwork.Create())
            {
                Feedback feedback = new Feedback()
                {
                    Message = model.Message,
                    UserId=userId
                };

                _helpRepo.Add(feedback);
            }
            return Ok();
        }
    }
}
