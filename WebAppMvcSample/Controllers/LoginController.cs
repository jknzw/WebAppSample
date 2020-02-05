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
        public ActionResult Click(LoginModel model)
        {
            logger.StartMethod(MethodBase.GetCurrentMethod().Name);
            try
            {
                if (model.Password.Equals("kamuo"))
                {
                    return View("MenuView", model);
                }
            }
            catch (Exception ex)
            {
                logger.WriteException(MethodBase.GetCurrentMethod().Name, ex);
            }
            finally
            {
                logger.EndMethod(MethodBase.GetCurrentMethod().Name);
            }
            return View("Index",model);
        }
    }
}
