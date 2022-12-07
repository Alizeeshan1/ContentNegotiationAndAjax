using ContentNegotiationAndAjax.Data;
using ContentNegotiationAndAjax.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContentNegotiationAndAjax.Controllers
{
    public class TaskController : Controller
    {
        private readonly ApplicationDbConetxt _db;

        public TaskController(ApplicationDbConetxt db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Index(string? str)
        {
            var employees = _db.TaskEmpl.ToList();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TaskEmployee emp)
        {
            _db.TaskEmpl.Add(emp);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Details(String? id)
        {
            var employee = _db.TaskEmpl.Where(x => x.Id == Convert.ToInt32(id)).FirstOrDefault();
            var AjaxCall = HttpContext.Request.Headers["Ajax-Call-With"].ToString();
            if (AjaxCall == "XMLHttpRequest")
            {
                //return new string[] { "Return to partial View" };
                return PartialView("_EmployeeDetails", employee);
            }
            return View(employee);
        }
    }
}
