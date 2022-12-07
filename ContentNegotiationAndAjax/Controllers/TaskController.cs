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
        public IActionResult Index()
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

        // To check Ajax call 
        [HttpGet]
        public IActionResult Details(int id)
        {
            var employee = _db.TaskEmpl.Where(x => x.Id == id).FirstOrDefault();
            var AjaxCall = HttpContext.Request.Headers["X-Requested-With"].ToString();
            if (AjaxCall == "XMLHttpRequest")
            {
                return PartialView("_EmployeeDetails", employee);
            }
            return View(employee);
        }

        //Content Negotiation
        [HttpGet]
        public IActionResult Content()
        {
            var employees = _db.TaskEmpl.ToList();
            return Ok(employees);
        }
    }
}
