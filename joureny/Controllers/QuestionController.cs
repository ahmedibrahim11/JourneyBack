using Framework.Data.EF;
using joureny.Data.Entities;
using joureny.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace joureny.Controllers
{
    [RoutePrefix("questions")]

    public class QuestionController : ApiController
    {

        private IRepository<Question> _questionRepo;
        private IUnitOfWorkFactory _unitOfwork;

        public QuestionController(IRepository<Question> questionRepo, IUnitOfWorkFactory unitOfwork)
        {
            _questionRepo = questionRepo;
            _unitOfwork = unitOfwork;
        }
       [HttpGet]
        [Route("allQuestions/{journeyId:long}")]
        public IHttpActionResult GetAllQuestions(long journeyId)
        {
            var Questions = _questionRepo.GetAll<QuestionDto>(new Specification<Question>(s=>s.TripQuestions.Any(t=>t.TripId==journeyId))).Where(t=>t.IsTop==false).ToList();
            return Ok(Questions);
        }
        [HttpGet]
        [Route("tabQuestions/{tabId:long}")]
        public IHttpActionResult GetTabQuestions(long tabId)
        {
            var Questions = _questionRepo.GetAll<QuestionDto>(new Specification<Question>(s => s.TripQuestions.Any(t => t.Question.QuestionTab == (QuestionTab)tabId))).ToList();
            return Ok(Questions);
        }

        // GET: api/Question/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Question
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Question/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Question/5
        public void Delete(int id)
        {
        }
    }
}
