
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using EmployeesEntry.Models;
using System;
namespace EmployeesEntry.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeDbContext db = new EmployeeDbContext();

        public ActionResult Index()
        {
          
            return View();
        }

        public ActionResult Create(int? EmpId,int? pid,int? lid,string mts)
        {
            try
            {
                ViewBag.lid = lid;
                ViewBag.pid = pid;
                ViewBag.mts = mts;
                ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "LocationName");
                ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "PositionName");

                var employee = db.Employees.Find(EmpId);

                return View(employee);
            }
            catch (Exception exception)
            {
                ViewBag.exceptionMsg = exception.Message;
            }
          
         
        
           
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,EmployeeName,PresentAddress,ParmanentAddress,LocationId,PositionId,CurrentSalary,Gender,Phone,IsUserOfSystem,MaritalStatus,DateOfBirth,JoiningDate")] Employee employee,int? EmpId)
        {
          
            if (ModelState.IsValid)
            {

                try
                {
                    if (EmpId != null)
                    {
                        var employeeUpdateObj = db.Employees.Find(EmpId);
                        employeeUpdateObj.EmployeeName = employee.EmployeeName;
                        employeeUpdateObj.PresentAddress = employee.PresentAddress;
                        employeeUpdateObj.ParmanentAddress = employee.ParmanentAddress;
                        employeeUpdateObj.LocationId = employee.LocationId;
                        employeeUpdateObj.PositionId = employee.PositionId;
                        employeeUpdateObj.Gender = employee.Gender;
                        employeeUpdateObj.Phone = employee.Phone;
                        employeeUpdateObj.CurrentSalary = employee.CurrentSalary;
                        employeeUpdateObj.IsUserOfSystem = employee.IsUserOfSystem;
                        employeeUpdateObj.DateOfBirth = employee.DateOfBirth;
                        employeeUpdateObj.JoiningDate = employee.JoiningDate;
                        employeeUpdateObj.MaritalStatus = employee.MaritalStatus;
                        db.Entry(employeeUpdateObj).State = EntityState.Modified;
                        db.SaveChanges();
                        ViewBag.UpdatedMsg = "Record Updated successfully";

                    }
                    else
                    {

                        var checkIsEmployeeAlreadyExist = db.Employees.Any(p => p.Phone.Equals(employee.Phone));
                        if (!checkIsEmployeeAlreadyExist)
                        {
                            db.Employees.Add(employee);
                            db.SaveChanges();
                            ViewBag.SavedMsg = "Record Saved successfully";
                        }
                        else
                        {
                            ModelState.AddModelError("", "A record with this phone already exist.");
                        }

                    }
                }
                catch (Exception exception)
                {
                    ViewBag.exceptionMsg = exception.Message;
                }


                finally
                {
                    ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "LocationName", employee.LocationId);
                    ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "PositionName", employee.PositionId);

                }


            }
       
           
            return View(employee);
        }

        public JsonResult DeleteEmployee(int id)
        {
            string res = string.Empty;
            try
            {
                var objDel = db.Employees.Find(id);
                db.Entry(objDel).State = EntityState.Deleted;
                db.SaveChanges();
                res = "data deleted successfully";
            }
            catch
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetEmployees()
        {


            var employees = db.Employees.Include(e => e.Location).Include(e => e.Position).Select(c=> new {c.EmployeeId,c.EmployeeName,c.Phone,c.Location.LocationName,c.PositionId,c.LocationId,c.MaritalStatus }).ToList();

            return Json(employees, JsonRequestBehavior.AllowGet);



        }
      


    }
}
