using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using KudVenkatEmploymentPortal.Interfaces;
using KudVenkatEmploymentPortal.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace KudVenkatEmploymentPortal.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public EmployeeController(IEmployeeRepository employeeRepository, IHostingEnvironment hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {

            return View(_employeeRepository.GetAllEmployees());
        }

        public IActionResult Details(int id)
        {
            var employee = _employeeRepository.GetEmployee(id);
            return View(employee);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel employee)
        {
            if (ModelState.IsValid)
            {
                string filename = ProcessImage(employee);
                Employee newEmployee = new Employee { Email = employee.Email, Dept = employee.Dept, Name = employee.Name, PhotoPath = filename };
                _employeeRepository.CreateEmployee(newEmployee);
            }
            return View("index", _employeeRepository.GetAllEmployees());
        }

        private string ProcessImage(EmployeeCreateViewModel employee)
        {
            string filename = string.Empty;
            if (employee.Photo != null)
            {
                string fileuploadfolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                filename = Guid.NewGuid().ToString() + "_image_" + employee.Photo.FileName;
                string filepath = Path.Combine(fileuploadfolder, filename);
                using (var filestream = new FileStream(filepath, FileMode.Create))
                {
                    employee.Photo.CopyTo(filestream);
                }
            }

            return filename;
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id > 0)
            {
                Employee editemployee = _employeeRepository.GetEmployee(id);
                EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel
                {
                    Id = editemployee.ID,
                    Name = editemployee.Name,
                    Email = editemployee.Email,
                    Dept = editemployee.Dept,
                    ExistingPhotoPath = editemployee.PhotoPath
                };
                return View(employeeEditViewModel);
            }
            else
            {
                return View("error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel editemployee)
        {
            if (ModelState.IsValid)
            {
                string newimage = null;
                if (editemployee.Photo != null)
                {
                    newimage = ProcessImage(editemployee);
                    if (editemployee.ExistingPhotoPath != null)
                    {
                        string oldFileName = Path.Combine(hostingEnvironment.WebRootPath, "images", editemployee.ExistingPhotoPath);
                        System.IO.File.Delete(oldFileName);
                    }
                }
                else
                {
                    newimage = editemployee.ExistingPhotoPath;
                }
                Employee employee = new Employee
                {
                    ID = editemployee.Id,
                    Name = editemployee.Name,
                    Email = editemployee.Email,
                    Dept = editemployee.Dept,
                    PhotoPath = newimage
                };
                _employeeRepository.UpdateEmployee(employee);
            }
            return View("index", _employeeRepository.GetAllEmployees());
        }
    }
}
