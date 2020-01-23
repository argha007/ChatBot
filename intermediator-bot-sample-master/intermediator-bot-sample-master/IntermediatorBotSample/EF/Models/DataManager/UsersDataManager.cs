using IntermediatorBotSample.EF.Models.Dto;
using IntermediatorBotSample.EF.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntermediatorBotSample.EF.Models.DataManager
{
    public class UsersDataManager : IDataRepository<Users, UsersDto>
    {
        #region Declaration Zone

        private readonly VaaniContext _context;

        #endregion

        #region Constructor

        public UsersDataManager(VaaniContext context)
        {
            _context = context;
        }

        #endregion

        #region Select
        public IEnumerable<Users> GetAll()
        {
            return _context.Users
                .ToList();
        }

        public Users Get(long id)
        {
            return _context.Users
                .SingleOrDefault(b => b.Id == id);
        }

        public UsersDto GetDto(long id)
        {
            //using (var context = new VaaniContext())
            //{
            var user = _context.Users
                   .SingleOrDefault(b => b.Id == id);
            return UsersDtoMapper.MapToDto(user);
            //}
        }

        #endregion

        #region Insert

        public int Add(UsersDto entity)
        {
            int result = -1;
            try
            {
                if (entity != null)
                {
                    _context.Users.Add(UsersDtoMapper.MapToAddEntity(entity));
                    _context.SaveChanges();
                    result = 1;
                }
            }
            catch (Exception ex){ throw ex.InnerException; }

            return result;
        }

        #endregion

        #region Update

        public int Update(Users entityToUpdate, Users entity)
        {
            int result = -1;
            try
            {
                entityToUpdate = _context.Users
                        .Single(b => b.Id == entityToUpdate.Id);

                if (entityToUpdate != null)
                {
                    entityToUpdate.FirstName = entity.FirstName;
                    entityToUpdate.LastName = entity.LastName;
                    entityToUpdate.Password = entity.Password;
                    entityToUpdate.DateOfBirth = entity.DateOfBirth;
                    entityToUpdate.RegisteredOn = entity.RegisteredOn;
                    entityToUpdate.IsActive = entity.IsActive;
                    entityToUpdate.PhoneNumbers = entity.PhoneNumbers;
                    entityToUpdate.RoleId = entity.RoleId;
                    _context.SaveChanges();

                    result = entityToUpdate.Id;
                }
            }
            catch { }

            return result;
        }

        #endregion

        #region Delete

        public int Delete(Users entity)
        {
            int result = -1;
            try
            {
                if (entity != null)
                {
                    _context.Users.Remove(entity);
                    _context.SaveChanges();
                    result = 1;
                }
            }
            catch { }

            return result;

        }

        #endregion
    }

}
