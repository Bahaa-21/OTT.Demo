using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_PROJECT.Models;
using System.Dynamic;
using MVC_PROJECT.Models.DetailsVM;
using System.Data.Entity;

namespace MVC_PROJECT.Controllers
{
    
    public class HomeController : Controller
    {
        private Context db = new Context();
        // GET: Home
        //الواجهة الرئيسية 

            // استعراض الرحلات الذي ذهب اليها الزبون ضمن  My Travel
        [HttpGet]
        public ActionResult Index()
        { 
            ViewBag.MyTrips = null;
            if (Session["UserId"] != null)
            {
                int UserID = (int)Session["UserId"];
                List<Trips> myTrips = db.Trips.Where(e => e.DateEnd < DateTime.Now && e.TripsCustomer.Any(x => x.id_Customer == UserID)).ToList();
                ViewBag.MyTrips = myTrips;
                ViewBag.AllTrips = db.Trips.Where(e => e.DateEnd > DateTime.Now).ToList();
                return View();
            }
            ViewBag.AllTrips = db.Trips.Where(e => e.DateEnd > DateTime.Now).ToList();
            return View();
        }

        //لحساب فترة الرحلة && لحساب درجة التقييم 
        [HttpGet]
        public ActionResult InfoTrip(int id)
        {
            var trip1 = db.Trips.SingleOrDefault(x => x.ID_Trip == id);
            if (trip1 != null)
            {
                var trips = (from item in db.Trips
                             where item.ID_Trip == id
                             select item).ToList();
                var tripstation = (from item in db.TripsStation
                                   where item.ID_Trip == trip1.ID_Trip
                                   select item).ToList();
                ViewBag.ID = id;
                ViewBag.Station = tripstation ;
                ViewBag.Data = trips;
                return View();
            }
            //Trips trip = db.Trips.Find(id);
            ViewBag.duration = (trip1.DateEnd - trip1.DateStart).TotalDays;
            // لعرض نسبة التقييم 
            if (trip1.Evalution.Count > 0)
            {
                ViewBag.Rate = trip1.Evalution.Sum(e => e.Evaluation_Score) / trip1.Evalution.Count;
            }
            else
            {
                ViewBag.Rate = 0;
            }
           
            return RedirectToAction("Index", "Home");
        }

        //تقييم الرحلات من قبل الزبون 
        [HttpGet]
        public ActionResult RateTrip(int id)
        {
            Trips trip = db.Trips.Find(id);
            if (trip == null)
            {
                return Redirect("/404");
            }
            if (trip.Evalution.Count > 0)
            {
                ViewBag.Rate = trip.Evalution.Sum(e => e.Value) / trip.Evalution.Count;
            }
            else
            {
                ViewBag.Rate = 0;
            }
            return View(trip);
        }
        [HttpPost]
        public ActionResult RateTrip(Evalution model)
        {
            model.Id_Customer = (int)Session["UserId"];
            db.Evalution.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Problem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Problem([Bind(Include = "DescraptionComplaint")]Complaints Obj)
        {
            int customerId = Convert.ToInt32(Session["UserId"]);
            if (customerId == 0)
            {
                return RedirectToAction("LoginCustomer", "Account");
            }
            if (ModelState.IsValid)
            {
                Obj.ID_Customer = customerId;
                Obj.DateComplaint = System.DateTime.Now;
                db.Complaints.Add(Obj);
                db.SaveChanges();
                return RedirectToAction("Index" ,"Home");
            }
            return View();
        }
        //البحث مع برمجة استعراض رحلات
        public ActionResult Search()
        {
            var trips = db.Trips.Include(x => x.ClassificationTrips).ToList();
            return View(trips);
        }
        public IEnumerable<Trips> convert(List<Trips> t)
        {
            return t;
        }
        
        public ActionResult Team()
        {
            return View();
        }
        public ActionResult Details()
        {
            return View();
        }
        public ActionResult logout()
        {
            Session["UserId"] = null;

            return RedirectToAction("Index", "Home");
        }
    }
}