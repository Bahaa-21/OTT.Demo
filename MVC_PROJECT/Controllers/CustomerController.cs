using MVC_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_PROJECT.Controllers
{
    public class CustomerController : Controller
    {
        private Context db = new Context();
        // Customer/Join Trip  
        // الانضمام الى رحلة
        public ActionResult JoinTrip(int Id)
        {
            TripsCustomer tripcustomer = new TripsCustomer();
            if (Session["UserId"]!=null)
            {
                int session = (int)Session["UserId"];

                var join = db.Trips.Find(Id);
                if (join != null)
                {
                    var tc = db.TripsCustomer.SingleOrDefault(s=>s.id_Customer == session);
                    if (tc != null || tc == null)
                    {
                        var t = db.Customers.Find(session);
                        tripcustomer.id_Customer = t.ID_Customer;
                        tripcustomer.id_Trip = Id;
                        tripcustomer.Participation_Date = DateTime.Now;
                        tripcustomer.Participation_State = false;
                        db.TripsCustomer.Add(tripcustomer);
                        db.SaveChanges();
                        return RedirectToAction("Index","Home");
                    }
                   // ViewBag.Message = string.Format("Hello {0} .// تم انضمامك إلى هذه الرحلة من قبل ",tc.Customers.UserNameC);
                    return RedirectToAction ("Index","Home");
                }
                return HttpNotFound();
            }
            return RedirectToAction("LoginCustomer", "Account");
        }
        // خريطة الموقع
        public ActionResult Map()
        {
            return View();
        }

    }
}