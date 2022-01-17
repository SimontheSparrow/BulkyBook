using BulkyBook.Data;
using BulkyBook.Data.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _context;

        public CategoryController(IUnitOfWork context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var objList = _context.Category.GetAll();
            return View(objList);
        }


        //get create category
        public IActionResult Create()
        {
           
            return View();
        }

        //post create category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _context.Category.Add(obj);
                _context.Save();
                TempData["success"] = "Category created";
                return RedirectToAction("Index", "Category");
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
            var obj = _context.Category.GetFirstOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        //post edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _context.Category.Update(obj);
                _context.Save();
                TempData["success"] = "Category Edited";

                return RedirectToAction("Index", "Category");
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
            var obj = _context.Category.GetFirstOrDefault(u=>u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //post delete
        [HttpPost]
        
        public IActionResult Delete(Category obj)
        {
            
                _context.Category.Remove(obj);
                _context.Save();
                TempData["success"] = "Category created";

                return RedirectToAction("Index", "Category");
            
            
        }
    }
}
