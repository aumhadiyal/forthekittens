using forthekittens.DataAccess.Repository;
using forthekittens.DataAccess.Repository.IRepository;
using forthekittens.Models;
using forthekittens.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileProviders;

namespace forthekittens.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unit;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unit,IWebHostEnvironment webHostEnvironment)
        {
            _unit = unit;
            _webHostEnvironment = webHostEnvironment;

        }
        public IActionResult Index()
        {
            List<Product> products = _unit.Product.GetAll().ToList();

            return View(products);
        }
        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new()
            {
                CategoryList = _unit.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = new Product()
            };
            if(id==null || id==0)
            {
                //create
                return View(productVM);
            }
            else
            { 
                //edit
                productVM.Product = _unit.Product.Get(u => u.Id == id);
                return View(productVM);
            }
        }
        [HttpPost]
        public IActionResult Upsert(ProductVM productVM,IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwrootpath = _webHostEnvironment.WebRootPath;
                if(file!=null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);    
                    string productPath = Path.Combine(wwwrootpath,@"images\product");
                    if(!string.IsNullOrEmpty(productVM.Product.ImageUrl))
                    {
                        var oldImagePath = Path.Combine(wwwrootpath, productVM.Product.ImageUrl.TrimStart('\\'));
                        if(System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }

                    }
                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    productVM.Product.ImageUrl = @"\images\product\" + fileName;
                }
                _unit.Product.Add(productVM.Product);
                _unit.Save();
                TempData["success"] = "Product Created Successully";
                return RedirectToAction("Index", "Product");
            }
            else
            {
                productVM.CategoryList = _unit.Category.GetAll().Select(u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    });
                return View(productVM);
            }
        }

       
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? Productfromdb = _unit.Product.Get(u => u.Id == id);
            if (Productfromdb == null)
            {
                return NotFound();
            }
            return View(Productfromdb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? Productfromdb = _unit.Product.Get(u => u.Id == id);
            if (Productfromdb == null)
            {
                return NotFound();
            }
            _unit.Product.Remove(Productfromdb);
            _unit.Save();
            TempData["success"] = "Product Deleted Successully";
            return RedirectToAction("Index");
        }
    }
}
