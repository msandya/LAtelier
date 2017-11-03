using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using ITI.KDO.WebApp.Services;
using ITI.KDO.WebApp.Models.AccountViewModels;
using ITI.KDO.DAL;
using ITI.KDO.WebApp.Authentification;

namespace ITI.KDO.WebApp.Controllers
{
    public class AccountController : Controller
    {
        readonly UserServices _userService;
        readonly TokenService _tokenService;
        readonly Random _random;

        public AccountController(UserServices userService, TokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
            _random = new Random();
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult ModifyPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ModifyPassword(ModifyPasswordViewModel model)
        {
            Console.WriteLine("Modify Password");
            if (ModelState.IsValid)
            {
                User user = _userService.FindUser(model.Mail, model.OldPassword);
                Console.WriteLine("User is authenticated {0}", user != null);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid mail or password attempt.");
                    return View(model);
                }
                if (model.NewPassword != model.NewPasswordConfirm)
                {
                    ModelState.AddModelError(string.Empty, "New passwords are not match.");
                    return View(model);
                }
                _userService.UpdateUserPassword(user.UserId, model.NewPassword);
                return RedirectToAction(nameof(Authenticated));
            }
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login( LoginViewModel model )
        {
            Console.WriteLine("Login");
            if (ModelState.IsValid)
            {
                User user = _userService.FindUser(model.Mail,model.Password);
                Console.WriteLine("User is authenticated {0}", user != null);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
                await SignIn(user.Mail, user.UserId.ToString());
                return RedirectToAction(nameof(Authenticated));
            }
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_userService.FindUserByMail(model.Mail) != null )
                {
                    ModelState.AddModelError(string.Empty, "An account with this mail already exists.");
                    return View(model);
                }
                _userService.CreatePasswordUser(model);
                User user = _userService.FindUserByMail(model.Mail);
                await SignIn(user.Mail, user.UserId.ToString());
                return RedirectToAction(nameof(Authenticated));
            }
            return View(model);
        }

        [HttpGet]
        [Authorize(ActiveAuthenticationSchemes = CookieAuthentication.AuthenticationScheme)]
        public async Task<IActionResult> LogOff()
        {
            await HttpContext.Authentication.SignOutAsync(CookieAuthentication.AuthenticationScheme);
            ViewData["NoLayout"] = true;
            return View();
        }

        [HttpGet]
        [Authorize(ActiveAuthenticationSchemes = CookieAuthentication.AuthenticationScheme)]
        public IActionResult Authenticated()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            string mail = User.FindFirst(ClaimTypes.Email).Value;
            Token token = _tokenService.GenerateToken(userId, mail);
            ViewData["BreachPadding"] = GetBreachPadding();
            ViewData["Token"] = token;
            ViewData["Mail"] = mail;
            ViewData["NoLayout"] = true;
            return View();
        }



        async Task SignIn(string mail, string userId)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim( ClaimTypes.Email, mail, ClaimValueTypes.String ),
                new Claim( ClaimTypes.NameIdentifier, userId.ToString(), ClaimValueTypes.String )
            };
            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthentication.AuthenticationType, ClaimTypes.Email, string.Empty);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            await HttpContext.Authentication.SignInAsync(CookieAuthentication.AuthenticationScheme, principal);
        }

        string GetBreachPadding()
        {
            byte[] data = new byte[_random.Next(64, 256)];
            _random.NextBytes(data);
            return Convert.ToBase64String(data);
        }

    }
}