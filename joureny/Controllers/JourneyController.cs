using Framework.Data.EF;
using joureny.Data.Entities;
using joureny.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace joureny.Controllers
{
    [RoutePrefix("journey")]
    public class JourneyController : ApiController
    {
        private readonly IUnitOfWorkFactory _unitOfWork;

        private readonly IRepository<Trip> _tripRepo;
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<UserTrips> _userTripRepo;
        private readonly IRepository<UserConnection> _userConnection;
        private readonly IRepository<UserAnswerQuestion> _userAnswers;


        public JourneyController(IUnitOfWorkFactory unitOfWork, IRepository<Trip> tripRepo, IRepository<User> userRepo,
            IRepository<UserTrips> userTripRepo, IRepository<UserConnection> userConnection, IRepository<UserAnswerQuestion> userAnswers)
        {
            _userAnswers = userAnswers;
            _unitOfWork = unitOfWork;
            _tripRepo = tripRepo;
            _userRepo = userRepo;
            _userTripRepo = userTripRepo;
            _userConnection = userConnection;

        }

        [HttpGet]
        [Route("allusers/{userId:long}")]
        public IHttpActionResult GetAllUsers(long userId)
        {

            List<ConnectionDto> usersInfo = new List<ConnectionDto>();
            var users = _userRepo.Get(new Specification<User>(s => s.Id != userId)).ToList();

            foreach (var item in users)
            {
                var user = _userConnection.Get(new Specification<UserConnection>(s => s.ConnectionId == item.Id && s.UserId == userId)).FirstOrDefault();
                var _hoppies = _userAnswers.GetAll<UserAnswerQuestionDto>().Where(s => s.userId == item.Id && s.QuestionId == 56).ToList();
                if (user!=null)
                {
                    ConnectionDto userData = new ConnectionDto()
                    {
                        Email = item.Email,
                        Mobile = item.MobileNumber,
                        JobTittle = item.Email,
                        Name = item.UserName,
                        Status = user.ConnectionStatus,
                        Id=item.Id,
                        Hobbies=_hoppies.Count==0?"":_hoppies.FirstOrDefault().Value
                    };
                    usersInfo.Add(userData);
                }
                else
                {
                    ConnectionDto userData = new ConnectionDto()
                    {
                        Email = item.Email,
                        Mobile = item.MobileNumber,
                        JobTittle = item.Email,
                        Name = item.UserName,
                        Status = ConnectionStatus.Requested,
                        Id=item.Id,
                        Hobbies = _hoppies.Count==0 ? "" : _hoppies.FirstOrDefault().Value

                    };
                    usersInfo.Add(userData);
                }
            }
            //var UserTrip = _userRepo.Get<UserDto>(new Specification<User>(f=>f.UserTrips.Any(v=>v.TripId==journeyId))).ToList();
            //return Ok(UserTrip);
            return Ok(usersInfo);

        }

    }
}
