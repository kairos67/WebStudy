using AspnetNote.MVC6.DataContext;
using AspnetNote.MVC6.Models;
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

        [HttpPost]
        public IActionResult Login(User model )
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
                        .FirstOrDefault(u=>u.UserId.Equals(model.UserId) && 
                                        u.UserPassword.Equals(model.UserPassword));
                    if (user == null)
                    { 
                    }
                    else
                    {

                    }
                }
            }
            return View(model);
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
