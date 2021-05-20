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
        /// <summary>
        /// register
        /// </summary>
        /// <returns></returns>
        //[HttpPost]
        //public IActionResult Login() 
        //{ 
        //}
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
                    db.SaveChanges(); //save sql
                }
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
