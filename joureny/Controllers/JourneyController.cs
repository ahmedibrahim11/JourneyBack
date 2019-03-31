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
    [RoutePrefix("journey")]
    public class JourneyController : ApiController
    {
        private readonly IUnitOfWorkFactory _unitOfWork;

        private readonly IRepository<Trip> _tripRepo;
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<UserTrips> _userTripRepo;



        public JourneyController(IUnitOfWorkFactory unitOfWork, IRepository<Trip> tripRepo, IRepository<User> userRepo,
            IRepository<UserTrips> userTripRepo)
        {
            _unitOfWork = unitOfWork;
            _tripRepo = tripRepo;
            _userRepo = userRepo;
            _userTripRepo = userTripRepo;

        }

        [HttpGet]
        [Route("allusers/{journeyId:long}")]
        public IHttpActionResult GetAllUsers(long journeyId)
        {
            var UserTrip = _userRepo.Get<UserDto>(new Specification<User>(f=>f.UserTrips.Any(v=>v.TripId==journeyId))).ToList();
            return Ok(UserTrip);
        }

    }
}
