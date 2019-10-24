using Framework.Data.EF;
using joureny.Data.Entities;
using joureny.Dtos;
using joureny.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using static joureny.Helpers.ExpoPushHelper;

namespace joureny.Controllers
{
    [RoutePrefix("Connection")]
    public class ConnectionController : ApiController
    {
        private IRepository<User> _userRepo;
        private IRepository<UserConnection> _connectionRepo;
        private IUnitOfWorkFactory _unitOfwork;


        public ConnectionController(IRepository<User> userRepo, IUnitOfWorkFactory unitOfwork, IRepository<UserConnection> connectionRepo)
        {
            _userRepo = userRepo;
            _connectionRepo = connectionRepo;
            _unitOfwork = unitOfwork;
        }

        [HttpPost]
        [Route("newConnection/{userId:long}/{newConnectionId:long}")]
        public IHttpActionResult Connect(long userId, long newConnectionId)
        {
            using (var uow = _unitOfwork.Create())
            {

                var user = _userRepo.Get(new Specification<User>(s => s.Id == userId)).FirstOrDefault();
                if (user == null)
                {
                    return NotFound();
                }

                var RequestedUser = _userRepo.Get(new Specification<User>(s => s.Id == newConnectionId)).FirstOrDefault();
                if (RequestedUser == null)
                {
                    return NotFound();
                }

                UserConnection userConnection = new UserConnection()
                {
                    UserId = userId,
                    ConnectionId = newConnectionId,
                    ConnectionStatus = ConnectionStatus.WaitingForReview
                };
                _connectionRepo.Add(userConnection);

                UserConnection coonection = new UserConnection()
                {
                    UserId = newConnectionId,
                    ConnectionId = userId,
                    ConnectionStatus = ConnectionStatus.Pending
                };
                _connectionRepo.Add(coonection);


                List<NotificationObject> listNotifications = new List<NotificationObject>();
                if (!String.IsNullOrEmpty(RequestedUser.PushToken))
                {
                    listNotifications.Add(new NotificationObject
                    {
                        to = RequestedUser.PushToken,
                        title = "El R7laa",
                        body = "New Request",
                        data = new NotificationData
                        {
                            title = "El R7laa",
                            body = "you have a new request form" + user.UserName,
                            code = "NEW_CONN",
                            id = RequestedUser.Id.ToString()
                        }
                    });
                }

                ExpoPushHelper.SendPushNotification(listNotifications);
            }


            return Ok();
        }

        [HttpPut]
        [Route("approveConnection/{userId:long}/{ConnectionId:long}")]
        public IHttpActionResult ApproveConnect(long userId, long ConnectionId)
        {
            using (var uow = _unitOfwork.Create())
            {
                var oldStatus = _connectionRepo.Get(new Specification<UserConnection>(s => s.UserId == userId && s.ConnectionId == ConnectionId)).FirstOrDefault();
               
                    oldStatus.ConnectionStatus = ConnectionStatus.Connected;

                var connectedoldStatus= _connectionRepo.Get(new Specification<UserConnection>(s => s.UserId == ConnectionId && s.ConnectionId == userId)).FirstOrDefault();
                connectedoldStatus.ConnectionStatus = ConnectionStatus.Connected;
            }

            var RequestedUser = _userRepo.Get(new Specification<User>(s => s.Id == userId)).FirstOrDefault();
            if (RequestedUser == null)
            {
                return NotFound();
            }

            var ConnectedUser = _userRepo.Get(new Specification<User>(s => s.Id == ConnectionId)).FirstOrDefault();
            if (RequestedUser == null)
            {
                return NotFound();
            }

            List<NotificationObject> listNotifications = new List<NotificationObject>();
            if (!String.IsNullOrEmpty(RequestedUser.PushToken))
            {
                listNotifications.Add(new NotificationObject
                {
                    to = ConnectedUser.PushToken,
                    title = "El R7laa",
                    body = "Approve",
                    data = new NotificationData
                    {
                        title = "El R7laa",
                        body = ""+ConnectedUser.UserName+" has approved your Request",
                        code = "APPROVE_CONN",
                        id = RequestedUser.Id.ToString()
                    }
                });
            }

            ExpoPushHelper.SendPushNotification(listNotifications);

            return Ok();
        }

        [HttpPut]
        [Route("rejectConnection/{userId:long}/{ConnectionId:long}")]
        public IHttpActionResult Reject(long userId, long ConnectionId)
        {
            using (var uow = _unitOfwork.Create())
            {
                var oldStatus = _connectionRepo.Get(new Specification<UserConnection>(s => s.UserId == userId && s.ConnectionId == ConnectionId));
                foreach (var item in oldStatus)
                {
                    item.ConnectionStatus = ConnectionStatus.Rejected;
                }
            }

            var RequestedUser = _userRepo.Get(new Specification<User>(s => s.Id == userId)).FirstOrDefault();
            if (RequestedUser == null)
            {
                return NotFound();
            }

            var connectionUser = _userRepo.Get(new Specification<User>(s => s.Id == ConnectionId)).FirstOrDefault();
            if (connectionUser == null)
                return NotFound();

            List<NotificationObject> listNotifications = new List<NotificationObject>();
            if (!String.IsNullOrEmpty(RequestedUser.PushToken))
            {
                listNotifications.Add(new NotificationObject
                {
                    to = RequestedUser.PushToken,
                    title = "El R7laa",
                    body = "Reject",
                    data = new NotificationData
                    {
                        title = "El R7laa",
                        body = ""+connectionUser.UserName+" has been rejected your Request",
                        code = "REJECT_CONN",
                        id = connectionUser.Id.ToString()
                    }
                });
            }

            ExpoPushHelper.SendPushNotification(listNotifications);

            return Ok();
        }



        [HttpGet]
        [Route("getConnection/{userId:long}")]
        public IHttpActionResult Getconnction(long userId)
        {
            List<ConnectionDto> UserConnections = new List<ConnectionDto>();
            var connections = _connectionRepo.Get(new Specification<UserConnection>(s => s.UserId == userId));


            foreach (var item in connections)
            {

                var user = _userRepo.Get(new Specification<User>(s => s.Id == item.ConnectionId)).FirstOrDefault();
                ConnectionDto NewConnection = new ConnectionDto()
                {
                    Email = user.Email,
                    Name = user.UserName,
                    Status = item.ConnectionStatus,
                    Mobile = user.MobileNumber,
                    Id = user.Id
                };

                UserConnections.Add(NewConnection);
            }

            return Ok(UserConnections);
        }
    }
}
