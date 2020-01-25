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
    public class LoginController : Controller
    {
        private readonly ILoginRepository<LoggedInDto, LoginDto> _dataRepository;
        public LoginController(ILoginRepository<LoggedInDto, LoginDto> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpPost(Name ="Login")]
        public IActionResult Post([FromBody] LoginDto login)
        {
            try
            {
                if (login is null)
                {
                    return Json(new { statusCode = (int)HttpStatusCode.OK, status = ResponseMessage.Success, message = ResponseMessage.RecordNotPresent, data = null as object });
                }

                if (!ModelState.IsValid)
                {
                    return Json(new { statusCode = (int)HttpStatusCode.BadRequest, status = ResponseMessage.BadRequest, message = ResponseMessage.BadRequest, data = null as object });
                }

                var loggedInUsers = _dataRepository.Login(login);

                if (loggedInUsers.Email == null)
                {
                    return Json(new { statusCode = (int)HttpStatusCode.OK, status = ResponseMessage.Success, message = ResponseMessage.InvalidCredentials, data = null as object });
                }

                return Json(new { statusCode = (int)HttpStatusCode.OK, status = ResponseMessage.Success, message = ResponseMessage.RecordPresent, data = loggedInUsers });
            }
            catch (Exception ex)
            {
                return Json(new { statusCode = (int)HttpStatusCode.InternalServerError, status = ResponseMessage.Fail, message = ex.Message, data = null as object });
            }
        }

        [HttpGet(Name = "ForgotPassword")]
        public IActionResult Get(string registeredEmailId)
        {
            var responseMessage = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(registeredEmailId))
                {
                    return Json(new { statusCode = (int)HttpStatusCode.OK, status = ResponseMessage.Success, message = "Email Id is Blank", data = null as object });
                }

                if (!ModelState.IsValid)
                {
                    return Json(new { statusCode = (int)HttpStatusCode.BadRequest, status = ResponseMessage.BadRequest, message = ResponseMessage.BadRequest, data = null as object });
                }

                var forgotPasswordStatus = _dataRepository.Get(registeredEmailId);
                switch (forgotPasswordStatus)
                {
                    case 1:
                        responseMessage = ResponseMessage.ForgotPasswordSuccess;
                        break;
                    case 2:
                        responseMessage = ResponseMessage.ForgotPasswordInvalidEmail;
                        break;
                    case 0:
                        responseMessage = ResponseMessage.Fail;
                        break;
                    default:
                        break;
                }

                return Json(new { statusCode = (int)HttpStatusCode.OK, status = ResponseMessage.Success, message = responseMessage, data = null as object });
            }
            catch (Exception ex)
            {
                return Json(new { statusCode = (int)HttpStatusCode.InternalServerError, status = ResponseMessage.Fail, message = ex.Message, data = null as object });
            }
        }
    }
}
