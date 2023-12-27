using System.Threading.Tasks.Dataflow;
using Employee_Crud.Models;
using Employee_Crud.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Crud.Controllers
{
    public class EmployeeController : Controller
    {
        public EmployeeController()
        {
            
        }
        //private object empDataAccessLayer;
        DAL dal = new DAL();
        // GET: EmployeeController
        public IActionResult Index()
        {
            ModelState.Clear();
            var result = dal.GetDataList();
            return View(result);
        }

        // GET: EmployeeController/Details/5
        public IActionResult Details(int id)
        {
            return View(dal.GetDataList().Find(ur => ur.Employee_Id == id));
        }

        // GET: EmployeeController/Create
        public IActionResult Create(EmployeeModel ur)
        {
            try
            {
                if (dal.InsertData(ur))
                {
                    ViewBag.Message = "Data saved";
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //GET : User/Edit/5
        public IActionResult Edit(int id)
        {
            return View(dal.GetDataList().Find(ur => ur.Employee_Id == id));
        }

        // POST : User/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, EmployeeModel ur)
        {
            try
            {
                if (dal.UpdateData(ur))
                {
                    ViewBag.Message = "Data Updated";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //GET : User/Delete/5
        public IActionResult Delete(int id)
        {
            return View(dal.GetDataList().Find(ur => ur.Employee_Id == id));
        }
        // POST : User/Delete/5
        [HttpPost]
        public IActionResult Delete(int id, EmployeeModel ur)
        {
            try
            {
                if (dal.DeleteData(ur))
                {
                    ViewBag.Message = "Data Deleted";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}