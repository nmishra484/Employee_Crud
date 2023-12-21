using System.Threading.Tasks.Dataflow;
using Employee_Crud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Crud.Controllers
{
    public class EmployeeController : Controller
    {
        //private object empDataAccessLayer;
        DAL dal = new DAL();
        // GET: EmployeeController
        public ActionResult Index()
        {
            ModelState.Clear();
            return View(dal.GetDataList());
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View(dal.GetDataList().Find(ur => ur.id == id));
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
            return View(dal.GetDataList().Find(ur => ur.id == id));
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
        public ActionResult Delete(int id)
        {
            return View(dal.GetDataList().Find(ur => ur.id == id));
        }
        // POST : User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EmployeeModel ur)
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