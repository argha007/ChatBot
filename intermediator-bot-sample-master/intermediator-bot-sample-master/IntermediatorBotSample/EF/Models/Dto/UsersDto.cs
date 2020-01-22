﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace IntermediatorBotSample.EF.Models.Dto
{
    public class UsersDto
    {
        //[JsonProperty(PropertyName = "id")]
        //public int Id { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "roleId")]
        public int RoleId { get; set; }
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }
        [JsonProperty(PropertyName = "isActive")]
        public bool? IsActive { get; set; }
        [JsonProperty(PropertyName = "phoneNumbers")]
        public string PhoneNumbers { get; set; }
        [JsonProperty(PropertyName = "dateOfBirth")]
        public DateTime? DateOfBirth { get; set; }
        [JsonProperty(PropertyName = "registeredOn")]
        public DateTime? RegisteredOn { get; set; }


    }

    public static class UsersDtoMapper
    {
        public static UsersDto MapToDto(Users users)
        {
            if (users!=null)
            {
                return new UsersDto()
                {
                    //Id = users.Id,
                    FirstName = users.FirstName,
                    LastName = users.LastName,
                    Email = users.Email,
                    DateOfBirth = users.DateOfBirth,
                    RegisteredOn = users.RegisteredOn,
                    Password = users.Password,
                    IsActive = users.IsActive,
                    RoleId = users.RoleId
                };
            }
            return new UsersDto();
        }
        public static Users MapToAddEntity(UsersDto users)
        {
            if (users != null)
            {
                return new Users()
                {
                    FirstName = users.FirstName,
                    LastName = users.LastName,
                    Email = users.Email,
                    DateOfBirth = users.DateOfBirth,
                    RegisteredOn = users.RegisteredOn,
                    Password = users.Password,
                    IsActive = users.IsActive,
                    RoleId = users.RoleId
                    //Role=null,
                   // EndCustomer = null
                };
            }
            return new Users();
        }
    }
}