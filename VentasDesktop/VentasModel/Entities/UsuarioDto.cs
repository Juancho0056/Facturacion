using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using VentasModel.Entities.BaseEntities;

namespace VentasModel.Entities
{
    public class UsuarioDto : ErrorDto
    {

        public static UsuarioDto create()
        {
            UsuarioDto dto = new UsuarioDto();
            return dto;
        }
        public static UsuarioDto create(UsuarioDto usuario, List<BaseErrorDto> Errors, int ErrorCode)
        {
            UsuarioDto dto = new UsuarioDto();
            dto.ErrorCode = ErrorCode;
            dto.Errors = Errors;
            dto.Id = usuario.Id;
            dto.Username = usuario.Username;
            dto.Email = usuario.Email;
            dto.FirstName = usuario.LastName;
            dto.Token = usuario.Token;
            dto.LastLogin = usuario.LastLogin;
            return dto;
        }
        public static UsuarioDto create(List<BaseErrorDto> Errors, int Error)
        {
            UsuarioDto dto = new UsuarioDto();
            dto.Errors = Errors;
            dto.ErrorCode = Error;
            return dto;
        }
    
        public static UsuarioDto create(JObject objeto)
        {
            UsuarioDto item = new UsuarioDto();
            item.Id = objeto["id"].ToString();
            item.Username = objeto["username"].ToString();
            if(objeto["email"] != null)
                item.Email = objeto["email"].ToString();
            item.FirstName = objeto["firstName"].ToString();
            item.LastName = objeto["lastName"].ToString();
            if(!string.IsNullOrEmpty(objeto["lastLogin"].ToString()))
                item.LastLogin = Convert.ToDateTime(objeto["lastLogin"].ToString());

            item.Token = objeto["token"].ToString();


            return item;
        }
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LastLogin { get; set; }
        public string Token { get; set; }
        //public DateTime ExpirationToken { get; set; }
        public ICollection<Rol> Roles { get; set; }
    }
}
