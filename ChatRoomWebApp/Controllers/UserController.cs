using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using ChatRoomLibrary.Models.WS;
using ChatRoomWebApp.Models.ViewModels;
using ChatRoomWebApp.Tools;
using ChatRoomLibrary.Models.Request;
using ChatRoomLibrary.Tools;
using ChatRoomLibrary.Models.Response;

namespace ChatRoomWebApp.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            LoginRequest loginRequest = new LoginRequest();
            loginRequest.Email = model.Email;
            loginRequest.Password = EncryptTool.GetSHA256(model.Password);

            ConfigTool configTool = new ConfigTool();

            Reply oReply = 
                configTool.Execute<LoginRequest>(ConfigUrlTool.Url.Login, "post", loginRequest);

            UserResponse userResponse =
                JsonConvert.DeserializeObject<UserResponse>(JsonConvert.SerializeObject(oReply.Data));

            if (oReply.Result == 1)
            {
                Session["User"] = userResponse;
                return RedirectToAction("Index", "Chat");
            }

            ViewBag.Error = "Datos incorrectos";
            return View(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            RegisterViewModel model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            UserRequest oUser = new UserRequest();
            oUser.Email = model.Email;
            oUser.Password = EncryptTool.GetSHA256(model.Password);
            oUser.Firstname = model.Firstname;
            oUser.Lastname = model.Lastname;

            ConfigTool configTool = new ConfigTool();
            Reply oReply =
                configTool.Execute<UserRequest>(ConfigUrlTool.Url.Register, "post", oUser);

            if (oReply.Result == 1)
            {
                return RedirectToAction("Confirm", "User");
            }

            ViewBag.Message = "Ocurrió un problema, intenta de nuevo";
            return View();
        }

        public ActionResult Confirm()
        {
            return View();
        }
    }
}