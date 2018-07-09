using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BCTH.Models;

namespace BCTH.Controllers
{
    public class HomeController : Controller
    {
        BCTHEntities db = new BCTHEntities();

        public ActionResult Index()
        {
            //comment de bo qua login
            if (Session["IsLogin"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       

        #region Xu ly login, logout ---------------------------------------
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(string user, string pwd, string type)
        {
            var lstMenu = db.MenuItems.ToList();

            if (user != "")
            {
                Session["IsLogin"] = 1;
                //Lay ra quyen xem menu
                //DataTable dtMenu = new DataTable();
                //dtMenu = db.Menus.Select(;

                List<MnuItem> menu = new List<MnuItem>();

                foreach (MenuItem item in lstMenu)
                {
                    MnuItem cur = new MnuItem();

                    cur.Id = item.Id.ToString();
                    cur.MenuName = item.Name;
                    cur.Url = item.Url;
                    cur.ParentId = item.ParentId.ToString();
                    cur.OrderIndex = item.OrderIndex.ToString();
                    cur.Icon = "";

                    menu.Add(cur);
                }

             
                Session["lstMenu"] = menu;
                Session["Username"] = user;
                //Session["FullName"] = user.FullName;
                //Store_Employee emp = db.Store_Employee.Where(a => a.EmployeeCode == userName).FirstOrDefault();
                //Session["StoreCode"] = (emp != null) ? emp.StoreCode : ""; ;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        #endregion ------------------------------------------------
    }
}