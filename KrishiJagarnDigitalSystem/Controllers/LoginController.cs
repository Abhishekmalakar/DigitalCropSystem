using KrishiJagarnDigitalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KrishiJagarnDigitalSystem.Controllers
{
    public class LoginController : Controller
    {

        KrishiEntities db = new KrishiEntities();

        // GET: Login
        public ActionResult Index()
        {


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Models.UserRegistration userRegistration)
        {
            if (ModelState.IsValid)
            {
                using (KrishiEntities db = new KrishiEntities())
                {

                    var obj = db.UserRegistrations.Where(x => x.UserName.Equals(userRegistration.UserName) && x.Password.Equals(userRegistration.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.id.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                        return RedirectToAction("Index", "Home");
                    }

                    else
                    {
                        ModelState.AddModelError("", "The UserName or Password Incorrect");
                    }
                }
            }

            return View();
        }

    }
}