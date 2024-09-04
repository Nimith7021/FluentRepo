using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OneToOneFluentDemo.Data;
using OneToOneFluentDemo.Models;

namespace OneToOneFluentDemo.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var users = session.Query<User>().ToList();
                return View(users);
            }
        }

        public ActionResult Create() { 
        
            return View();
        }

        [HttpPost]

        public ActionResult Create(User user) {

            using (var session = NHibernateHelper.CreateSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    user.Address.User = user;
                    session.Save(user);
                    transaction.Commit();
                    return RedirectToAction("Index");
                }
            }
        }

        public ActionResult Edit(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var user = session.Query<User>().FirstOrDefault(u=>u.Id==id);
                return View(user);
            }
        }

        [HttpPost]

        public ActionResult Edit(User user)
        {

            using (var session = NHibernateHelper.CreateSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    user.Address.User = user;
                    session.Update(user);
                    transaction.Commit();
                    return RedirectToAction("Index");
                }
            }
        }

        public ActionResult Delete(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var user = session.Query<User>().FirstOrDefault(u => u.Id == id);
                return View(user);
            }
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteUser(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var user = session.Query<User>().FirstOrDefault(u => u.Id == id);
                    session.Delete(user);
                    transaction.Commit();
                    return RedirectToAction("Index");
                }
            }
        }
    }
}