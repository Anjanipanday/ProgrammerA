using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Programmer_Adda.Models;
namespace Programmer_Adda.Controllers
{
    public class AdminController : Controller
    {
        // GET: /Admin/
        pddbEntities db = new pddbEntities();
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {

            }
            else
            {
                Response.Write("<script>alert('Frist login here here then goto next Zone');window.location.href='../Home/Login'</script>");
            }
            return View();
        }
        public ActionResult MembersMgmt()
        {
            List<Registration> Lst = null;
            if (Session["user"] != null)
            {
                Lst = db.Registrations.ToList();
            }
            else
            {
                Response.Write("<script>alert('Frist login here here then goto next Zone');window.location.href='../Home/Login'</script>");
            }
            return View(Lst);
        }
        public ActionResult EnquiryMgmt()
        {
            List<Enquiry> Lst = null;
            if (Session["user"] != null)
            {
                Lst = db.Enquiries.ToList();
            }
            else
            {
                Response.Write("<script>alert('Frist login here here then goto next Zone');window.location.href='../Home/Login'</script>");
            }
            return View(Lst);
        }
        public ActionResult ReviewMgmt()
        {
            List<Review> Lst = null;
            if (Session["user"] != null)
            {
                Lst = db.Reviews.ToList();
            }
            else
            {
                Response.Write("<script>alert('Frist login here here then goto next Zone');window.location.href='../Home/Login'</script>");
            }
            return View(Lst);
        }
        public ActionResult AddProgrammer()
        {
            if (Session["user"] != null)
            {

            }
            else
            {
                Response.Write("<script>alert('Frist login here here then goto next Zone');window.location.href='../Home/Login'</script>");
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddProgrammer(Programmer pg)
        {
            try
            {
                db.Programmers.Add(pg);
                db.SaveChanges();
                Response.Write("<script>alert('New Programmer Added')</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Programmer not Added')</script>");
            }
            return View();
        }
        public ActionResult ProgrammerMgmt()
        {
            List<Programmer> Lst = null;
            if (Session["user"] != null)
            {
                Lst = db.Programmers.ToList();
            }
            else
            {
                Response.Write("<script>alert('Frist login here here then goto next Zone');window.location.href='../Home/Login'</script>");
            }
            return View(Lst);
        }
        public ActionResult ChangePassword()
        {
            if (Session["user"] != null)
            {
                
            }
            else
            {
                Response.Write("<script>alert('Frist login here here then goto next Zone');window.location.href='../Home/Login'</script>");
            }
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(string oldpasswd,string newpasswd,string confirmpasswd)
        {
            if (newpasswd == confirmpasswd)
            {
                string email = Session["user"].ToString(); 
                Login lg = db.Logins.Where(x=>x.passwd==oldpasswd && x.userid==email).SingleOrDefault();
                lg.passwd = newpasswd;
                db.SaveChanges();
                Response.Write("<script>alert('Your Password Changed')</script>");
            }
            else
            {
                Response.Write("<script>alert('Plese Confirm Password')</script>");
            }
            return View();
        }
        public ActionResult Logout()
        {
            if (Session["user"] != null)
            {
                Session.Abandon();
            }
            else
            {
                Response.Write("<script>alert('Frist login here here then goto next Zone');window.location.href='../Home/Login'</script>");
            }
            return View();
        }
	}
}