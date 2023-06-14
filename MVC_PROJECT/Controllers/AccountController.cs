using MVC_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_PROJECT.Controllers
{
    public class AccountController : Controller
    {
       private Context db = new Context();
        // GET: Account
        //تسجيل دخول الأدمن
        public ActionResult LoginAdmin()
        {
            Session["UserId"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult LoginAdmin(Admin admin)
        {
            
            Admin getUser = db.Admin.Where(x => x.email == admin.email && x.Password == admin.Password).FirstOrDefault();
            //Admin getUser = db.Admin.FirstOrDefault(x => x.email == admin.email && x.Password == admin.Password);
            if (getUser != null)
            {
                Session["UserId"] = db.Admin.Single(x => x.email == admin.email).ID_Admin;
                return RedirectToAction("HomeAdmin", "Admin");
            }
            else
            { return View(); }

        }
        //تسجيل دخول المنظم
        public ActionResult LoginOrg()
        {
            Session["UserId"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult LoginOrg(Organizing org)
        {

            Organizing getUser = db.Organizing.Where(x => x.EmailOrg == org.EmailOrg && x.PasswordOrg == org.PasswordOrg).FirstOrDefault();
            //Admin getUser = db.Admin.FirstOrDefault(x => x.email == admin.email && x.Password == admin.Password);
            if (getUser != null)
            {
                Session["UserId"] = db.Organizing.Single(x => x.EmailOrg == org.EmailOrg).ID_Organizer;
                return RedirectToAction("HomeOrganizing", "Organizing",Session["UserId"]);
            }
            else
            { return View(); }

        }
        //تسجيل دخول الزبون
        public ActionResult LoginCustomer()
        {
            Session["UserId"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult LoginCustomer(Customers customer)
        {
            
            Customers getUser = db.Customers.Where(x => x.EmailCustomer == customer.EmailCustomer && x.PasswordCustomer == customer.PasswordCustomer).FirstOrDefault();
            //Admin getUser = db.Admin.FirstOrDefault(x => x.email == admin.email && x.Password == admin.Password);
            if (getUser != null)
            {
                Session["UserId"] = db.Customers.Single(x => x.EmailCustomer == customer.EmailCustomer).ID_Customer;
                return RedirectToAction("Index","Home");
            }
            else
            return View();

        }
        //واجهة إنشاء حساب زبون
        public ActionResult RegisterCustomer()
        {
            Session["UserId"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult RegisterCustomer(Customers customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            Session["UserId"] = customer.ID_Customer;
            return RedirectToAction("Index","Home");
        }
        //واجهة  إنشاء حساب منظم
        public ActionResult RegisterOrg()
        {
            Session["UserId"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult RegisterOrg(Organizing org)
        {
            if (ModelState.IsValid)
            {
                db.Organizing.Add(org);
                db.SaveChanges();
                Session["UserId"] = org.ID_Organizer;
                return RedirectToAction("HomeOrganizing", "Organizing");
            }
            //ModelState.AddModelError("", "Invalid login attempt.");
            return View();
        }

    }
}