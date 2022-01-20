using BulkyBook.Data;
using BulkyBook.Data.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BulkyBook.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IWebHostEnvironment _hostEnviroment;

        public ProductController(IUnitOfWork context, IWebHostEnvironment hostEnviroment)
        {
            _context = context;
            _hostEnviroment = hostEnviroment;
        }

        public IActionResult Index()
        {
            return View();
        }



        //get upsert
        
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
                productVM.Product= _context.Product.GetFirstOrDefault(i => i.Id == id);
                return View(productVM);

            }


        }
        //post Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductVM obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnviroment.WebRootPath;
                if(file != null)
                {
                    string fileName= Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"Images\Products");
                    var extension= Path.GetExtension(file.FileName);

                    if(obj.Product.ImageUrl != null)
                    {
                        var oldImgPath= Path.Combine(wwwRootPath, obj.Product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImgPath))
                        {
                            System.IO.File.Delete(oldImgPath);
                        }
                    }
                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    obj.Product.ImageUrl = @"\Images\Products\" + fileName + extension;
                }
                if (obj.Product.Id == 0)
                {
                    _context.Product.Add(obj.Product);
                }
                else
                {
                    _context.Product.Update(obj.Product);
                }
                _context.Product.Add(obj.Product);
              
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


        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var objList = _context.Product.GetAll(includeProperties:"Category");
            return Json(new { data= objList });

        }

        #endregion
    }
}
