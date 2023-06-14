using MVC_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_PROJECT.Models.DetailsVM;
using System.IO;
using System.Data.Entity;

namespace MVC_PROJECT.Controllers
{
    // كنترول المنظم 
    public class OrganizingController : Controller
    {
        Context db = new Context();
        // GET: Add/Trips
        // إضافة رحلة  
        [HttpGet]
        public ActionResult AddTrip()
        {
            var obj = new MultibleData();
            obj.breaks = (from item in db.Breaks
                          select item).ToList();
            obj.Type = (from item in db.ClassificationTrips
                        select item).ToList();
            return View(obj);

        }
        // Post : Add/Image
        // إضافة رحلة
        [HttpPost]
        public ActionResult AddTrip(MultibleData model)
        {
            if (Session["UserId"] != null)
            {
                int session = (int)Session["UserId"];
                TripsDetails tripdetails = new TripsDetails
                {
                    Name_Region = model.Name_Region
                };
                Trips trip = new Trips
                {
                    ID_Organizer = session,
                    DateStart = model.DateStart,
                    DateEnd = model.DateEnd,
                    Descripition = model.Descripition,
                    Price = model.Price,
                    Start_Location = model.Start_Location,
                    Distance = model.Distance,
                    Number_of_passengers = model.Number_of_passengers,
                    T_Announcement_Time = DateTime.Now,
                    ID_Class = model.ID_Class
                };
               
                PhotoTrips img = new PhotoTrips()
                { Photo_Trips = "~/image/pexels-asad-photo-maldives-3601421.jpg" };
                //---------------------------------------------------------------------------
                TripsStation tripstation = new TripsStation
                {
                    NameBreak = model.NameBreak,
                    DescripitionStation = model.DescripitionStation,
                    Station_Start = model.Station_Start,
                    PhotoStation = "~/image/hotel1.jpg",
                    ID_Break = model.ID_Break
                };
                db.TripsDetails.Add(tripdetails);
                db.Trips.Add(trip);
                db.TripsStation.Add(tripstation);
                db.PhotoTrips.Add(img);
                db.SaveChanges();
                return RedirectToAction("AddTrip", "Organizing");
            }

            return RedirectToAction("LoginOrg", "Account");
        }
        public ActionResult ExampleAddTrip()
        {
            return View();
        }
        // Get : Denied Trip / Details 
        // استعراض الرحلات المرفوضة
        public ActionResult DeniedTrips()
        {
            if (Session["UserId"]!=null)
            {
                int c = Convert.ToInt32(Session["UserId"]);
                List<RefuseTrip> refuse = new List<RefuseTrip>();
                refuse = (from item in db.RefuseTrip
                          where item.Id_Org == c
                          select item).ToList();
                return View(refuse);
            }
            return RedirectToAction("LoginOrg", "Account");
        }
         // Get : Info Customer / Details
         // استعراض زبائن الرحلة الواحدة للزبون 
        public ActionResult InfoCustomer(int id)
        {
            var infocustomer = db.Trips.Single(i => i.ID_Trip == id).ID_Trip;
            if (infocustomer != 0)
            {
                List<TripsCustomer> customer = new List<TripsCustomer>();
                customer = (from item in db.TripsCustomer
                            where item.id_Trip == infocustomer
                            select item).ToList();
                return View(customer);
            }
            return RedirectToAction("LoginOrg", "Account");
        }
        // Get : Home Orgazinig / Details
        //بروفايل المُنظم مع معلوماته الشخصية
        public ActionResult HomeOrganizing()
        {
            if (Session["UserId"] != null)
            {
                List<Organizing> organizing = new List<Organizing>();
                organizing = (from item in db.Organizing
                               select item).ToList();
                return View(organizing);
            }
            return RedirectToAction("LoginOrg", "Account");
        } 
        // Get : Organizing / Edit Information 
        // تعديل معلومات المنظم 
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Organizing org = db.Organizing.Find(id);
            if (org==null)
            {
                return HttpNotFound();
            }
            return View(org);
        }
        // Post : Organizing / Edit Information
        // تعديل معلومات المنظم 
        [HttpPost]
        public ActionResult Edit(Organizing org)
        {
                db.Entry(org).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("HomeOrganizing", "Organizing");

        }
        // Get : EditTraval 
        // تعديل معلومات الرحلة 
        public ActionResult EditTravel(int id)
        {
            var trip = db.Trips.Find(id).ID_Trip;
            ViewBag.IdTrip = trip;
            return View();
        }
        // Post : EditTravel 
        // تعديل معلومات الرحلة 
        [HttpPost]
        public ActionResult EditTravel(DetailsTripsVM obj)
        {
            Trips trip = db.Trips.FirstOrDefault(x => x.ID_Trip == obj.ID_Trip);
            trip.DateEnd = obj.DateEnd;
            trip.Descripition = obj.Descripition;
            trip.Distance = obj.Distance;
            trip.Start_Location = obj.Start_Location;

            TripsStation trips1 = db.TripsStation.FirstOrDefault(x => x.ID_Trip == obj.ID_Trip);
            trips1.NameBreak = obj.NameBreak;
            trips1.Station_Start = obj.Station_Start;
            trips1.DescripitionStation = obj.DescripitionStation;

            db.Entry(trip).State = EntityState.Modified;
            
            db.Entry(trips1).State = EntityState.Modified;

            db.SaveChanges();

            return RedirectToAction("MyTrip", "Organizing");

        }
        //استعراض رحلات رحلات المنظم الخاصة 
        public ActionResult InfoTripOrg(int id)
        {
            var trip = (from item in db.Trips
                        where item.ID_Trip == id
                        select item).ToList();
            var tripstation = (from item in db.TripsStation
                               where item.ID_Trip == id
                               select item).ToList();
            ViewBag.DataTrips = trip;
            ViewBag.DataTripsStation = tripstation; 
            return View();
        }
        //Get : Organizing / InfoTrip 
        // و اللي حتطلع للزبون لمّا يبحث عن شي رحلة ، رحلات المنظم
        public ActionResult MyTrip()
        {
            if (Session["UserId"] != null)
            {
                List<Trips> trip = new List<Trips>(); ;
                trip = (from item in db.Trips
                        select item).ToList();
                return View(trip);
            }
            return RedirectToAction("LoginOrg", "Account");
        }
        // حذف سبب رفض الرحلة 
        public ActionResult Delete(int? id)
        {
            if (Session["UserId"] != null)
            {
                RefuseTrip refuse = db.RefuseTrip.Find(id);
                db.RefuseTrip.Remove(refuse);
                db.SaveChanges();
                return RedirectToAction("Delete", "Organizing");
            }
            return RedirectToAction("LoginOrg", "Account");
        }
    }
}