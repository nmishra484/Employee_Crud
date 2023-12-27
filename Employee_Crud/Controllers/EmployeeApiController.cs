using Employee_Crud.Models;
using Employee_Crud.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Crud.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeApiController : Controller
    {
        DAL dal = new DAL();
        // GET: EmployeeApiController
        public IActionResult Index()
        {
            ModelState.Clear();
            return Ok(dal.GetDataList());
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            return Ok(dal.GetDataList().Find(ur => ur.Employee_Id == id));
        }
        //GET:User/Create
        public IActionResult Create()
        {
            return Ok(dal.GetDataList());
        }
        //Post : User/create
        [HttpPost]
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
                return Ok();
            }
        }
        //GET : User/Edit/5
        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            return Ok(dal.GetDataList().Find(ur => ur.Employee_Id == id));
            // return Ok("success");
        }

        // POST : User/Edit/5
        [HttpPut("{id}")]
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
                return Ok();
            }
        }

        //GET : User/Delete/5
        [HttpGet("{id}")]
        public IActionResult Delete(int id, EmployeeModel ur)
        {
            //UserRegModel req = new UserRegModel();
            // req.id = request.id;
            return Ok(dal.GetDataList().Find(ur => ur.Employee_Id == id));
        }
        // POST : User/Delete/5
        [HttpDelete("{id}")]
        public IActionResult Delete(EmployeeModel ur)
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
                return Ok();
            }
        }
    }
}
