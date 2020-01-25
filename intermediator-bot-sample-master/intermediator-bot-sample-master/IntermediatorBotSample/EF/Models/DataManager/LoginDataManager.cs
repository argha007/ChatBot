using IntermediatorBotSample.EF.Models.Dto;
using IntermediatorBotSample.EF.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

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

        #endregion

        
    }

}
