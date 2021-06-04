using AspnetNote.MVC6.DataContext;
using AspnetNote.MVC6.Models;
using AspnetNote.MVC6.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetNote.MVC6.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// login
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserList()
        {

            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                // not log in
                return RedirectToAction("Login", "Account");
            }
            using (var db = new AspnetNoteDbContext())
            {
                var list = db.Users.ToList();
                return View(list);
            }

        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            //ID, pwd
            if (ModelState.IsValid)
            {
                using (var db = new AspnetNoteDbContext())
                {
                    //Linq
                    //=> a go to b
                    //var user = db.Users
                    //    .FirstOrDefault(u=>u.UserId == model.UserId && u.UserPassword == model.UserPassword);
                    var user = db.Users
                        .FirstOrDefault(u => u.UserId.Equals(model.UserId) &&
                                        u.UserPassword.Equals(model.UserPassword));
                    if (user != null)
                    {
                        // success login
                        //HttpContext.Session.SetInt32(Key, value);
                        HttpContext.Session.SetInt32("USER_LOGIN_KEY", user.UserNo);

                        return RedirectToAction("LoginSuccess", "Home"); //move success page                                                
                    }
                }
                // fail login
                ModelState.AddModelError(string.Empty, "ID or Password is worong!");
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("USER_LOGIN_KEY");
            return RedirectToAction("Index", "Home");
            //HttpContext.Session.Clear(); all clear
        }
        /// <summary>
        /// register
        /// </summary>
        /// <returns></returns>

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                // Java try(sqlsession){} catch(){}

                //c#
                using (var db = new AspnetNoteDbContext())
                {
                    db.Users.Add(model); //in memory
                    db.SaveChanges(); //save sql, commit
                }
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
