using IntermediatorBotSample.EF.Models.Dto;
using IntermediatorBotSample.EF.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace IntermediatorBotSample.EF.Models.DataManager
{
    public class LoginDataManager : ILoginRepository<LoggedInDto, LoginDto>
    {
        #region Declaration Zone

        private readonly VaaniContext _context;

        #endregion

        #region Constructor

        public LoginDataManager(VaaniContext context)
        {
            _context = context;
        }

        #endregion

        #region Select

        public LoggedInDto Login(LoginDto logUser)
        {
            var user = _context.Users
                   .SingleOrDefault(b => (b.Email.Equals(logUser.Email) && b.Password.Equals(logUser.Password) && b.IsActive.Equals(true)));
            return UsersDtoMapper.MapToLoggedInDto(user);
        }

        public int Get(string email)
        {
            int retVal = 0;
            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                    var user = _context.Users
                       .SingleOrDefault(b => (b.Email.Equals(email)));
                    if (user != null)
                    {
                        if (!string.IsNullOrEmpty(user.Password))
                        {
                            MailMessage mm = new MailMessage("sender@gmail.com", email)
                            {
                                Subject = string.Format("Password Recovery For {0} {1}", user.FirstName, user.LastName),
                                Body = string.Format("Hi {0},<br /><br />Your password is {1}.<br /><br />Thank You.", email, user.Password),
                                IsBodyHtml = true
                            };
                            SmtpClient smtp = new SmtpClient
                            {
                                Host = "localhost",
                                EnableSsl = false
                            };
                            //smtp.UseDefaultCredentials = true;
                            smtp.Port = 25;
                            smtp.Send(mm);
                            retVal = 1;
                        }
                    }
                    else
                    {
                        retVal = 2;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retVal;

        }
        #endregion


    }

}
