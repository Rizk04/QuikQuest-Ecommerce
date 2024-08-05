using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using QuikQuest.Data;
using QuikQuest.Models;
using System.ComponentModel.DataAnnotations;

namespace QuikQuest.Controllers

{

    [Authorize]
    public class ProductsController : Controller
    {
        private readonly AppDbContext _db;
        public ProductsController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Product newProduct)
        {
            if (ModelState.IsValid)
            {

                _db.Products.Add(newProduct);
                _db.SaveChanges();
                return RedirectToAction("Shop");
            }
            
                return View();

        }
        public IActionResult Shop()
        {

            List<Product> ProdList = _db.Products.ToList();
            return View(ProdList);
        }
        public IActionResult About()
        {

            return View();
        }


        [HttpGet]

        public IActionResult Delete(int id)

        {
            if(id != null)
            {
                Product product = new Product();
                product.ProductId = id;
                _db.Products.Remove(product);
                _db.SaveChanges();
                return RedirectToAction("Shop");
            }

            return RedirectToAction("Shop");

        }
        [HttpGet]
        public IActionResult Edit(int? id)

        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? product = _db.Products.Find(id);
            if (product == null)
            {

                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            
            if (ModelState.IsValid)
            {
                _db.Products.Update(product);
                _db.SaveChanges();
                return RedirectToAction("Shop");
            }
            return View();

            
        }
        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            Product product = _db.Products.Find(id);
            return View(product);

        }
    }
}
