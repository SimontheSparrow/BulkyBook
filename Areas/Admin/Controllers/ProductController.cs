using BulkyBook.Data;
using BulkyBook.Data.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BulkyBook.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _context;

        public ProductController(IUnitOfWork context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var objList = _context.Product.GetAll();
            return View(objList);
        }




        //get edit
        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new ProductVM()
            {
                Product = new(),
                CategoryList = _context.Category.GetAll().Select(i=> new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                CoverTypeList = _context.CoverType.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            if (id == null || id == 0)
            {
                /*ViewBag.CategoryList = CategoryList;
                ViewBag.CoverType = CoverType;*/

                return View(productVM);
            }
            else
            {

            }
          

            return View(productVM);
        }
        //post edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _context.Product.Update(obj);
                _context.Save();
                TempData["success"] = "Product Edited";

                return RedirectToAction("Index", "Product");
            }
            return View(obj);
        }

        //get delete
       /* public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _context.Product.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //post delete
        [HttpPost]
        
        public IActionResult Delete(Product obj)
        {
            
                _context.Product.Remove(obj);
                _context.Save();
                TempData["success"] = "Product created";

                return RedirectToAction("Index", "Product");
            
            
        }*/
    }
}
