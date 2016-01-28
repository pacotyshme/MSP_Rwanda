using MSP_Rwanda.TableModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.Data.SqlClient();

namespace MSP_Rwanda.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ////ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            //return View(ViewBag);
           
            List<StudentModel> students = new List<StudentModel>();
                        //here MyContactBookEntities is our datacontext
            using (techsocialEntities dc=new techsocialEntities())
                        {
                            var v = (from a in dc.Students
                                     //join b in dc.Country on a.CountryID equals b.CountryID
                                     //join c in dc.Universities on a.UniversityID equals c.UniversityID
                                     select new StudentModel
                                     {
                                          StudentID=a.StudentID, 
                                          StudentFName =a.StudentFName,
                                          StudentLName = a.StudentLName, 
                                          ContactNumber = a.ContactNumber,
                                          EmailID = a.EmailID,
                                          ProfilePic = a.ProfilePic,
                                          
                                     }).ToList();
                            students = v;
        }
        return View(students);
    }
        public ActionResult Add()
        {
            //fetch country data 
            List<Country> AllCountry = new List<Country>();
            //List<State> states = new List<State>();
            // Here MyContactBookEntities is our DbContext
            using (techsocialEntities dc = new techsocialEntities())
            {
                AllCountry = dc.Countries.OrderBy(a => a.CountryName).ToList();
                //Not need to fetch state as we dont know which country will user select here
            }

            ViewBag.Country = new SelectList(AllCountry, "CountryID", "CountryName");
            //ViewBag.State = new SelectList(states, "StateID", "StateName");

            return View();
        }

        public JsonResult GetStates(int countryID)
        {
            using (techsocialEntities dc =new techsocialEntities())
            {
                //We will off Lazy Loading
                var State = (from a in dc.States
                             where a.CountryID.Equals(countryID)
                             orderby a.StateName
                             select a).ToList();
                return new JsonResult { Data = State, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        
}
}
