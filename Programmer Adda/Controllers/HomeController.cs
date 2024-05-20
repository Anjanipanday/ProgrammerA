using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Programmer_Adda.Models;

namespace Programmer_Adda.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        pddbEntities db = new pddbEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Aboutus()
        {
            return View();
        }
        public ActionResult Becamemember()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Becamemember(Registration reg,Login lg)
        {
            try
            {
                HttpPostedFileBase file = Request.Files["pic"];
                reg.profile=file.FileName.ToString();
                reg.regdt=DateTime.Now.ToString();
                db.Registrations.Add(reg);
                db.SaveChanges();
                file.SaveAs(Server.MapPath("../Content/profiles/"+file.FileName.ToString()));
                Response.Write("<script>alert('Registration completed successfully')</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Registration  not completed')</script>");
            }
            return View();
        }
        public ActionResult Disscussionform()
        {
           List<UploadError> ue = db.UploadErrors.ToList();
            return View(ue);
        }
        [HttpGet]
        public ActionResult Enquiry()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Enquiry(Enquiry eq)
        {
            try
            {
                eq.edt = DateTime.Now.ToString();
                db.Enquiries.Add(eq);
                db.SaveChanges();
                Response.Write("<script>alert('Thanks for Enquiry')</script>");
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Enquiry not comepleted')</script>"); 
            }
            return View();
        }
        public ActionResult Review()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Review(Review rv)
        {
            try
            {
                rv.rdt = DateTime.Now.ToString();
                db.Reviews.Add(rv);
                db.SaveChanges();
                Response.Write("<script>alert('Thanks for Review')</script>");
            }
            catch(Exception ex)
            {
            Response.Write("<script>alert('Review  is not completed')</script>");
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login lg)
        {
            try
            {

                var res = db.Logins.Where(x => x.userid == lg.userid && x.passwd == lg.passwd).SingleOrDefault();
                if (res.userid == lg.userid && res.passwd == lg.passwd)
                {
                    Session["user"] = lg.userid;
                    Response.Write("<script>alert('Welcome to AdminZone');window.location.href='/Admin/Index'</script>");
                }
                else
                {
                    Response.Write("<script>alert('Invalid Userid or passwd')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Invalid Userid or passwd')</script>");
            }
            return View();
        }
        public ActionResult UploadQuiry()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadQuiry(UploadError ue)
        {
            HttpPostedFileBase file = Request.Files["file"];
            try
            {
                ue.ufile = file.FileName.ToString();
                ue.udit = DateTime.Now.ToString();
                file.SaveAs(Server.MapPath("../Content/Errors/" + file.FileName.ToString()));
                db.UploadErrors.Add(ue);
                db.SaveChanges();
                Response.Write("<script>alert('Your quiry is uploaded')</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Your quiry is not uploaded')</script>");
            }
            return View();
        }
        public JsonResult mydata(string comment, string status,Comment cm)
        {
            string msg = "";
            try
            {
                cm.comments = comment;
                cm.status = int.Parse(status);
                cm.cdt = DateTime.Now.ToString();
                db.Comments.Add(cm);
                db.SaveChanges();
                msg = "done";
            }
            catch (Exception ex)
            {
                msg = "not done";
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        public JsonResult displayData(string status)
        {
            int st = int.Parse(status);
             List<Comment> Lst = db.Comments.ToList();
            return Json(Lst, JsonRequestBehavior.AllowGet);
        }
    }

}