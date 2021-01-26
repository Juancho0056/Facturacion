using Application.Application.Roles.Query.GetUserRoles;
using Application.Application.Users.Command.Login;
using Domain.Entities.Application;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace VentasApp.WebUI.Controllers
{
    /// <summary>
    /// Controlador de acciones Usuario
    /// </summary>
    public class AuthController : ApiController
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public AuthController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
        }
        [HttpPost()]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody]LoginUserRequest request)
        {
            if (ModelState.IsValid)
            {
                var user = await Mediator.Send(request);
                if (user is null)
                {
                    return BadRequest("Error consultando usuario");
                }
                var claims = new[] {
                    new Claim("Username", user.Data.Username),
                    new Claim("Role", user.Data.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
                var signingkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JwT_Secret"].ToString()));
                var token = new JwtSecurityToken(
                    issuer: Configuration["ApplicationSettings:Client_URL"].ToString(),
                    audience: Configuration["ApplicationSettings:Client_URL"].ToString(),
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(24),
                    signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(signingkey, SecurityAlgorithms.HmacSha256)
                );
                user.Data.Token = new JwtSecurityTokenHandler().WriteToken(token);

                var userroles = await Mediator.Send(new GetUserRolesRequest() { Username = user.Data.Username });
                user.Data.Roles = userroles.Data.Data;
                var rolesend = userroles.Data.Data.GroupBy(x => x.Id).Select(z => z.Key);
                user.Data.ExpirationToken = token.ValidTo;
                return Ok(new
                {
                    user = user,
                    isvalid = true,
                    message = ""
                }
                );
            }
            else
            {
                return Unauthorized(ModelState);
            }

        }
        //public async Task<ActionResult> ConfirmEmail([FromQuery]ConfirmModel request)
        //{
        //    var user = await _userManager.Users.Where(u => u.Id == request.UserId).FirstOrDefaultAsync();
        //    var result = await _userManager.ConfirmEmailAsync(user, request.Code);
        //    if (result.Succeeded)
        //    {
        //        return Ok();
        //    }
        //    return BadRequest();
        //}

        //[HttpPost()]
        //[Route("create")]
        //public async Task<ActionResult> Create([FromBody]UserInfoModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new ApplicationUser { 
        //            UserName = model.username, 
        //            Email = model.Email,
        //            FirstName = model.FirstName,
        //            LastName = model.LastName};
        //        var result = await _userManager.CreateAsync(user, model.password);
        //        if (result.Succeeded)
        //        {
        //            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //            var callbackUrl = Url.Action(
        //               "ConfirmEmail", "Auth",
        //               new { userId = user.Id, code = code },
        //               protocol: "https");
        //            try 
        //            {
        //                await EmailSender.SendEmailAsync(user.Email, user.FirstName,
        //                   "Confirm your account",
        //                   "Please confirm your account by clicking this link: <a href=\""
        //                                                   + callbackUrl + "\">link</a>");

        //            }
        //            catch (Exception e) 
        //            { 
        //                var err = e; 
        //            }
        //            //ViewBag.Link = callbackUrl;   // Used only for initial demo.
        //            //return View("DisplayEmail");
        //            return Ok("Se ha enviado un correo de confirmacion");
        //        }
        //    }
        //    return BadRequest();
        //}
        //[HttpPost()]
        //[Route("create")]
        //public async Task<ActionResult> Create([FromBody]CreateUserCommand model)
        //{

        //    var user = new ApplicationUser
        //    {
        //        UserName = model.Username,
        //        Email = model.Email,
        //        FirstName = model.FirstName,
        //        LastName = model.LastName
        //    };
        //    //var result = await _userManager.CreateAsync(user, model.Password);
        //    var result = await Mediator.Send(model);

        //    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //    var callbackUrl = Url.Action(
        //        "ConfirmEmail", "Auth",
        //        new { userId = user.Id, code = code },
        //        protocol: "https");
        //    try
        //    {
        //        await EmailSender.SendEmailAsync(user.Email, user.FirstName,
        //            "Confirm your account",
        //            "Please confirm your account by clicking this link: <a href=\""
        //                                            + callbackUrl + "\">link</a>");
        //    }
        //    catch (Exception e)
        //    {
        //        var err = e;
        //    }
        //    return Ok("Se ha enviado un correo de confirmacion");

        //}
    }
}
