using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using spHostelManagement.Models;
using spHostelManagement.DBOperations;

namespace spHostelManagement.Controllers
{
    public class HomeController : Controller
    {


         
        public ActionResult GetAllStdDetails()
        {

            spStudentRepository StdRepo = new spStudentRepository();
            ModelState.Clear();
            return View(StdRepo.GetAllStudents());
        }

        
        public ActionResult AddStudent()
        {
            return View();
        }

           
        [HttpPost]
        public ActionResult AddStudent(spStudentModel std)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    spStudentRepository StdRepo = new spStudentRepository();

                    if (StdRepo.AddStudent(std))
                    {
                        ViewBag.Message = "Student details added successfully";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult EditStdDetails(int id)
        {
            spStudentRepository StdRepo = new spStudentRepository();



            return View(StdRepo.GetAllStudents().Find(Std => Std.Id == id));

        }

          
        [HttpPost]

        public ActionResult EditStdDetails(int id, spStudentModel obj)
        {
            try
            {
                spStudentRepository StdRepo = new spStudentRepository();

                StdRepo.UpdateStudent(obj);
                return RedirectToAction("GetAllStdDetails");
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult DeleteStd(int id)
        {
            try
            {
                spStudentRepository StdRepo = new spStudentRepository();
                if (StdRepo.DeleteStudent(id))
                {
                    ViewBag.AlertMsg = "Student details deleted successfully";

                }
                return RedirectToAction("GetAllStdDetails");

            }
            catch
            {
                return View();
            }
        }







    }
}