using MVC_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_PROJECT.Models.DetailsVM;


namespace MVC_PROJECT.Controllers
{
    // كنترول الأدمن
    public class AdminController : Controller
    {
        
       private Context db = new Context();
        // ميثود لجلب جميع الشكاوي
        private List<Complaints> GetComplaint()
        {
            return (db.Complaints.OrderByDescending(x=>x.DateComplaint).ToList());
        }
        // GET: Admin/HomeAdmin/Details REgion
        //إستعراض واجهة الأدمن الرئيسية, مع إستعراض جدول المناطق المضافة من قبل الأدمن
        [HttpGet]
        public ActionResult HomeAdmin()
        {
            if (Session["UserId"] != null)
            {
                List<TripsDetails> tripsDetails = new List<TripsDetails>();
                tripsDetails = (from item in db.TripsDetails
                                select item).ToList();
                return View(tripsDetails);
            }
            return RedirectToAction("LoginAdmin", "Account");
        }
        // Post: Admin/HomeAdmin/Add Region
        // إضافة منطقة جديدة في جدول المناطق
        [HttpPost]
        public ActionResult HomeAdmin(TripsDetails regoin)
        {
            if (ModelState.IsValid)
            {
                db.TripsDetails.Add(regoin);
                db.SaveChanges();
                return RedirectToAction("HomeAdmin");
            }
            return View();
        }
        //Get : Edit/Admin/Edit Region
        //المنطقة المراد تعديلها ID إرسال 
        public ActionResult EditAdmin(int id)
        {

            TripsDetails trip = db.TripsDetails.Find(id);
            
            if (trip == null)
            {
                return HttpNotFound();

            }
            return View(trip);
        }
      
        //Psot : Edit/Admin
        // تعديل اسم المنطقة   
        [HttpPost]
        public ActionResult EditAdmin(TripsDetails obj)
        {
           
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("HomeAdmin","Admin");
            
           
        }
        [HttpGet] 
        //Get : Delete/Admin/Delete Region 
        // حذف المنطقة من جدول المناطق
        public ActionResult Delete(int? id)
        {
            TripsDetails trip = db.TripsDetails.Find(id);
            if (trip==null)
            {
                return HttpNotFound();
            }
            db.TripsDetails.Remove(trip);
            db.SaveChanges();
            return RedirectToAction("HomeAdmin","Admin");
        }
        //Get : Problem/Details  
        // عرض الشكاوي المرسلة من قبل الزبون
        [HttpGet]
        public ActionResult Problem()
        {
           NoticationVM obj = new NoticationVM();
            obj.complaint = GetComplaint(); 
            return View(obj);
        }
        //Psot : Problem/Replay
        //  الرد على الشكاوي و ارسالها للزبون بقائمة الاشعارات بالواجهة الرئيسية
        [HttpPost]
        public ActionResult Problem([Bind(Include = "ReplyText,ID_To")]NoticationVM obj)
        {
            Notification Note = new Notification();
            Note.ReplyText = obj.ReplyText;
            Note.Id_To = obj.Id_To;
            db.Notification.Add(Note);
            db.SaveChanges();
            return RedirectToAction("Problem","Admin");
        }
        //Get : Travels/Details
        // عرض االرحلات المعلقة 
        //الرحلات المُعلّقة
        [HttpGet]
        public ActionResult Travels()
        {
            RefuseTripsVM trip = new RefuseTripsVM();
            trip.trips = (from item in db.Trips
                          select item).ToList();
            return View(trip);
        }
        //Post : Travels/Admin/Replay
        // رفض الرحلة من قبل الأدمن و إرسالها إلى صفحة الرحلات المرفوضة الخاصة بالمنظم
        [HttpPost]
        public ActionResult Travels([Bind (Include = "TextRefuse,Id_Org,Id_t")]RefuseTripsVM obj)
        {
            RefuseTrip refuse = new RefuseTrip();
            refuse.reason_refuse = obj.TextRefuse;
            refuse.Id_Org = obj.ID_Org;
            refuse.Id_T = obj.Id_t;
            db.RefuseTrip.Add(refuse);
            db.SaveChanges();
            return RedirectToAction("Travels", "Admin");
        }

        [HttpGet]
        public ActionResult AddBreak()
        {
            List<Breaks> BreakType = new List<Breaks>();
            BreakType = (from item in db.Breaks
                         select item).ToList();
            return View(BreakType);
        }
        [HttpPost]
        public ActionResult AddBreak(Breaks BreakType)
        {
            if (ModelState.IsValid)
            {
                db.Breaks.Add(BreakType);
                db.SaveChanges();
                return RedirectToAction("AddBreak");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditBreak(int id)
        {
            var trip = db.Breaks.Find(id);
            
            if (trip == null)
            {
                return HttpNotFound();

            }
            return View(trip);
        }

        //Post : EditBreak/Admin
        [HttpPost]
        public ActionResult EditBreak(Breaks obj)
        {

            if (ModelState.IsValid)
            {
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AddBreak", "Admin");
            }
            return RedirectToAction("AddBreak","Admin");
        }
        [HttpGet]
        public ActionResult DeleteBreak(int? id)
        {
            Breaks trip = db.Breaks.Find(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            db.Breaks.Remove(trip);
            db.SaveChanges();
            return RedirectToAction("AddBreak", "Admin");
        }
    }
}