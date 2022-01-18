using BulkyBook.Data;
using BulkyBook.Data.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.Controllers
{
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _context;

        public CoverTypeController(IUnitOfWork context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var objList = _context.CoverType.GetAll();
            return View(objList);
        }


        //get create CoverType
        public IActionResult Create()
        {
           
            return View();
        }

        //post create CoverType
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _context.CoverType.Add(obj);
                _context.Save();
                TempData["success"] = "CoverType created";
                return RedirectToAction("Index", "CoverType");
            }
            return View(obj);
        }


        //get edit
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _context.CoverType.GetFirstOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        //post edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _context.CoverType.Update(obj);
                _context.Save();
                TempData["success"] = "CoverType Edited";

                return RedirectToAction("Index", "CoverType");
            }
            return View(obj);
        }

        //get delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _context.CoverType.GetFirstOrDefault(u=>u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //post delete
        [HttpPost]
        
        public IActionResult Delete(CoverType obj)
        {
            
                _context.CoverType.Remove(obj);
                _context.Save();
                TempData["success"] = "CoverType created";

                return RedirectToAction("Index", "CoverType");
            
            
        }
    }
}
