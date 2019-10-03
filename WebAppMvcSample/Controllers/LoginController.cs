using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppLib;
using WebAppMvcSample.Models;

namespace WebAppMvcSample.Controllers
{
    public class LoginController : Controller
    {
        private readonly Logger logger = Logger.GetInstance(nameof(LoginController));
        private readonly LoginModel model = new LoginModel();

        public IActionResult Index()
        {
            logger.StartMethod(MethodBase.GetCurrentMethod().Name);

            model.UserId = "testUser";
            model.Password = "testPass";

            model.LableUserId = "ユーザーID";
            model.LablePassword = "パスワード";
            model.LableLoginButton = "ログイン";

            logger.EndMethod(MethodBase.GetCurrentMethod().Name);
            return View(model);
        }

        [HttpPost]
        public ActionResult Post()
        {
            logger.StartMethod(MethodBase.GetCurrentMethod().Name);

            logger.EndMethod(MethodBase.GetCurrentMethod().Name);
            return View(model);
        }
    }
}
