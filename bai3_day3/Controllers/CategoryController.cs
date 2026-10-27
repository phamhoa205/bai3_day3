using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using bai3_day3.Models; //để không cần chữ models.Category khi sử dụng class Category

namespace bai3_day3.Controllers
{
    public class CategoryController : Controller
    {
        //Giả lập CSDL
        public static List<Category> categories = new List<Category>()
        {
            new Category(){Id=1, Name="Category 1"},
            new Category(){Id=2, Name="Category 2"},
            new Category(){Id=3, Name="Category 3"}, //không có model.category vì dùng using bai3_day3.Models;
        };

        // GET: CategoryController
        [HttpGet]
        public ActionResult Index()
        {

            return View(categories); // truyền danh sách categories vào view
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var detailCategory = categories.FirstOrDefault(c => c.Id == id);
            if (detailCategory == null)
            {
                return NotFound();
            }
            return View(detailCategory);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            category.Id = categories.Count + 1; 
            categories.Add(category);
            return RedirectToAction(nameof(Index));
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var editCategory = categories.FirstOrDefault(c => c.Id == id);
            if (editCategory == null)
            {
                return NotFound();
            }
            return View(editCategory);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var deleteCategory = categories.FirstOrDefault(c => c.Id == id);
            if (deleteCategory == null)
            {
                return NotFound();
            }
            return View(deleteCategory);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            categories.RemoveAll(c => c.Id == id);
            return RedirectToAction(nameof(Index));
        }
    }
}
