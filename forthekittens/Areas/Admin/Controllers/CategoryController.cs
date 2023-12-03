using forthekittens.DataAccess.Data;
using forthekittens.DataAccess.Repository.IRepository;
using forthekittens.Models;
using Microsoft.AspNetCore.Mvc;

namespace forthekittens.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unit;


        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _unit.Category.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and Order cant be same");
            }
            if (ModelState.IsValid)
            {
                _unit.Category.Add(obj);
                _unit.Save();
                TempData["success"] = "Category Created Successully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryfromdb = _unit.Category.Get(u => u.Id == id);
            if (categoryfromdb == null)
            {
                return NotFound();
            }
            return View(categoryfromdb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and Order cant be same");
            }
            if (ModelState.IsValid)
            {
                _unit.Category.Update(obj);
                _unit.Save();
                TempData["success"] = "Category Updated Successully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }



        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryfromdb = _unit.Category.Get(u => u.Id == id);
            if (categoryfromdb == null)
            {
                return NotFound();
            }
            return View(categoryfromdb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryfromdb = _unit.Category.Get(u => u.Id == id);
            if (categoryfromdb == null)
            {
                return NotFound();
            }
            _unit.Category.Remove(categoryfromdb);
            _unit.Save();
            TempData["success"] = "Category Deleted Successully";
            return RedirectToAction("Index");
        }

        public IActionResult Tp() { return View(); }

        [HttpPost]
        public IActionResult Tp(string name, string message)
        {
            TempData["Name"] = name;
            TempData["Message"] = message;

            return RedirectToAction("Tp2");
        }

        public IActionResult Tp2()
        {
            ViewBag.Name = TempData["Name"] as string;
            ViewBag.Message = TempData["Message"] as string;

            return View();
        }
    }
}
