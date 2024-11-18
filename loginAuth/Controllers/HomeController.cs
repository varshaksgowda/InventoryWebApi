using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using loginAuth.Data; // Assuming SessionModel is in this namespace

namespace loginAuth.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Create a new instance of SessionModel
            SessionModel sessionModel = new SessionModel();

            // Store the username in the session
            Session["UserName"] = User.Identity.Name;

            if (User.IsInRole("Admin"))
            {
                // Populate the session model for Admin users
                sessionModel.Role = "Admin";
                sessionModel.Address = "dsfdfsdfds";  // Fixed typo: changed 'Addess' to 'Address'
                sessionModel.Name = User.Identity.Name;

                // Store the session model and role in session
                Session["SessionModel"] = sessionModel;
                Session["Role"] = "Admin";

                // Optionally, set the ViewBag so it can be used in the view
                ViewBag.Role = "Admin";
            }
            else
            {
                // For non-admin users, store "Customer" in the session and ViewBag
                Session["Role"] = "Customer";
                ViewBag.Role = "Customer";
            }

            // Return the view (the session data will be available in the view)
            return View();
        }

        // About action redirects to the Index action
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            // Redirect to the Index action of the Home controller
            return RedirectToAction("Index", "Home");
        }

        // Contact action shows the contact page
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            // Return the contact view
            return View();
        }
    }
}
