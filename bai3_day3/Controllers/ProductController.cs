using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using bai3_day3.Models; //để không cần chữ models.Product khi sử dụng class Product
namespace bai3_day3.Controllers
{
    public class ProductController : Controller
    {
        //Giả lập CSDL
        public static List<Product> products = new List<Product>()
        {
            new Product(){Id=1, Name="Product 1", Price=10.0m, Description="Description 1", CategoryId=1},
            new Product(){Id=2, Name="Product 2", Price=20.0m, Description="Description 2", CategoryId=2},
            new Product(){Id=3, Name="Product 3", Price=30.0m, Description="Description 3", CategoryId=3},
        };

        // GET: ProductController
        public ActionResult Index()
        {
            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var detailProduct = products.FirstOrDefault(p => p.Id == id);
            if (detailProduct == null)
            {
                return NotFound();
            }
            return View(detailProduct);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            product.Id = products.Count + 1;
            products.Add(product);
            return RedirectToAction(nameof(Index));
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var editProduct = products.FirstOrDefault(p => p.Id == id);
            if (editProduct == null)
            {
                return NotFound();
            }
            return View(editProduct);
        }

        // POST: ProductController/Edit/5
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

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var deleteProduct = products.FirstOrDefault(p => p.Id == id);
            if (deleteProduct == null)
            {
                return NotFound();
            }
            return View(deleteProduct);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            products.RemoveAll(p => p.Id == id);
            return RedirectToAction(nameof(Index));
        }
    }
}
