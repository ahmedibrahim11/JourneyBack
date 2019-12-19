using Framework.Data.EF;
using joureny.Data.Entities;
using joureny.Dtos;
using joureny.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace joureny.Controllers
{
    [RoutePrefix("search")]
    public class SearchController : ApiController
    {
        private IRepository<User> _userRepo;

        private IRepository<Question> _questionRepo;

        private IRepository<UserAnswerQuestion> _userAnswerRepo;

        private IUnitOfWorkFactory _unitOfWork;


        public SearchController(
            IRepository<User> userRepo,
            IRepository<Question> questionRepo,
            IRepository<UserAnswerQuestion> userAnswerRepo,
            IUnitOfWorkFactory unitOfWork
            )
        {
            _userRepo = userRepo;
            _questionRepo = questionRepo;
            _userAnswerRepo = userAnswerRepo;
            _unitOfWork = unitOfWork;
        }

        private bool ContainData(SearchModel model)
        {

            var userValue = _userAnswerRepo.First(new Specification<UserAnswerQuestion>(s => s.Value == model.Value && s.QuestionId == model.QuestionId));
            if (userValue != null)
            {
                return true;
            }

            return false;
        }

        [HttpPost]
        [Route("getSearchResult")]
        public IHttpActionResult GetSearchResult([FromBody]List<SearchModel> filters)
        {
            var users = _userRepo.GetAll().ToList();
            List<long> UsersId = new List<long>();
            for (int i = 0; i < users.Count; i++)
            {
                var add = true;
                for (int j = 0; j < filters.Count; j++)
                {
                    if (!_userAnswerRepo.GetAll().Any(e => e.UserId == users[i].Id && e.Value == filters[j].Value && e.QuestionId == filters[j].QuestionId))
                    {
                        add = false;
                        break;
                    }
                }
                if (add)
                {
                    UsersId.Add(users[i].Id);
                }
            }
            return Ok(UsersId);

        }
        [HttpPost]
        [Route("getSearchBarResult")]
        public IHttpActionResult GetSearchBarResult(string SearchBarText)
        {
            string[] SearchBarWords = SearchBarText.Split(' ');
            var users = _userRepo.GetAll<UsersWithAnswersDto>().ToList();
            List<long> UsersId = new List<long>();
            foreach (var Word in SearchBarWords)
            {
                UsersId.AddRange(users.Where(u => u.UserName.Contains(Word)
                                           || u.Email.Contains(Word)
                                           || u.MobileNumber.ToString().Contains(Word)
                                           || u.Answers.Where(ans => ans.Contains(Word)).ToList().Count > 0)
                                           .Select(s => s.Id).ToList());
            }
            
               
        
            return Ok(UsersId.Distinct().ToList());

        }
    }
}
