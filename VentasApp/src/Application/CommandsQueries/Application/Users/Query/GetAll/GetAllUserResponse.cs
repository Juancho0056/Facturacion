using Application.Application.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace VentasApp.Application.CommandsQueries.Application.Users.Query.GetAll
{
    public class GetAllUserResponse
    {
        public ICollection<UserDto> Data { get; set; }
        public int Count { get; set; }
        public int Pages { get; set; }
    }
}
