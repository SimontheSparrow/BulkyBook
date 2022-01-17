using BulkyBook.Data;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var objList = await _context.Categories.ToListAsync();
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
                _context.Categories.Add(obj);
                _context.SaveChanges();
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
            var obj = _context.Categories.Find(id);
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
                _context.Categories.Update(obj);
                _context.SaveChanges();
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
            var obj = _context.Categories.Find(id);
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
            
                _context.Categories.Remove(obj);
                _context.SaveChanges();
            TempData["success"] = "Category deleted";

            return RedirectToAction("Index", "Category");
            
            
        }
    }
}
