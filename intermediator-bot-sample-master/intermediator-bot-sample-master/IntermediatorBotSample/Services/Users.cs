using IntermediatorBotSample.EF.Models;
using IntermediatorBotSample.EF.Models.Dto;
using IntermediatorBotSample.EF.Models.Repository;
using IntermediatorBotSample.Services.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace IntermediatorBotSample.Services
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IDataRepository<Users, UsersDto> _dataRepository;
        public UsersController(IDataRepository<Users, UsersDto> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            var users = _dataRepository.GetAll();
            if (users == null)
            {
                return Json(new { statusCode = (int)HttpStatusCode.OK, status = ResponseMessage.Success, message = ResponseMessage.RecordNotPresent, data = null as object });
            }

            return Json(new { statusCode = (int)HttpStatusCode.OK, status = ResponseMessage.Success, message = ResponseMessage.RecordPresent, data = users });
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult Get(int id)
        {

            var user = _dataRepository.GetDto(id);
            if (user == null)
            {
                return Json(new { statusCode = (int)HttpStatusCode.OK, status = ResponseMessage.Success, message = ResponseMessage.RecordNotPresent, data=null as object });
            }

            return Json(new { statusCode = (int)HttpStatusCode.OK, status = ResponseMessage.Success, message = ResponseMessage.RecordPresent, data = user });
        }

        // POST api/<controller>
        [HttpPost(Name ="AddUser")]
        public IActionResult Post(UsersDto user)
        {
            try
            {
                if (user is null)
                {
                    return Json(new { statusCode = (int)HttpStatusCode.OK, status = ResponseMessage.Success, message = ResponseMessage.RecordNotPresent, data = null as object });
                }

                if (!ModelState.IsValid)
                {
                    return Json(new { statusCode = (int)HttpStatusCode.BadRequest, status = ResponseMessage.BadRequest, message = ResponseMessage.BadRequest, data = null as object });
                }

                var retVal = _dataRepository.Add(user);

                if (retVal != -1)
                {
                    return Json(new {statusCode= (int)HttpStatusCode.OK, status = ResponseMessage.Success, message = ResponseMessage.AddSuccess, data = null as object });
                }
                else
                {
                    return Json(new { statusCode = (int)HttpStatusCode.ExpectationFailed, status = ResponseMessage.AddSuccess, message = ResponseMessage.Failed, data = retVal });
                }
            }
            catch (Exception ex)
            {
                return Json(new { statusCode = (int)HttpStatusCode.InternalServerError, status = ResponseMessage.Fail, message = ex.Message, data = null as object });
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}", Name="ModifyUser")]
        public IActionResult Put(int id, Users user)
        {
            try
            {
                if (user is null)
                {
                    return Json(new { statusCode = (int)HttpStatusCode.OK, status = ResponseMessage.Success, message = ResponseMessage.RecordNotPresent, data = null as object });
                }

                var userToUpdate = _dataRepository.Get(id);
                if (userToUpdate == null)
                {
                    return Json(new { statusCode = (int)HttpStatusCode.OK, status = ResponseMessage.Success, message = ResponseMessage.RecordNotPresent, data = null as object });
                }

                if (!ModelState.IsValid)
                {
                    return Json(new { statusCode = (int)HttpStatusCode.BadRequest, status = ResponseMessage.BadRequest, message = ResponseMessage.BadRequest, data = null as object });
                }

                var retVal = _dataRepository.Update(userToUpdate, user);

                if (retVal != -1)
                {
                    return Json(new { statusCode = (int)HttpStatusCode.OK, status = ResponseMessage.Success, message = ResponseMessage.UpdateSuccess, data = null as object });
                }
                else
                {
                    return Json(new { statusCode = (int)HttpStatusCode.ExpectationFailed, status = ResponseMessage.AddSuccess, message = ResponseMessage.Failed, data = retVal });
                }
            }
            catch (Exception ex)
            {
                return Json(new { statusCode = (int)HttpStatusCode.InternalServerError, status = ResponseMessage.Fail, message = ex.Message, data = null as object });
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}", Name = "RemoveUser")]
        public IActionResult Delete(int id)
        {
            try
            {
                var userToDelete = _dataRepository.Get(id);
                if (userToDelete is null)
                {
                    return Json(new { statusCode = (int)HttpStatusCode.OK, status = ResponseMessage.Success, message = ResponseMessage.RecordNotPresent, data = null as object });
                }

                
                var retVal = _dataRepository.Delete(userToDelete);

                if (retVal != -1)
                {
                    return Json(new { statusCode = (int)HttpStatusCode.OK, status = ResponseMessage.Success, message = ResponseMessage.DeleteSuccess, data = null as object });
                }
                else
                {
                    return Json(new { statusCode = (int)HttpStatusCode.ExpectationFailed, status = ResponseMessage.AddSuccess, message = ResponseMessage.Failed, data = retVal });
                }
            }
            catch (Exception ex)
            {
                return Json(new { statusCode = (int)HttpStatusCode.InternalServerError, status = ResponseMessage.Fail, message = ex.Message, data = null as object });
            }
        }
    }
}
