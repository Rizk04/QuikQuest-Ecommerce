using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuikQuest.Areas.Identity.Data;
using QuikQuest.Data;
using QuikQuest.Models;
using System;
using System.Security.Claims;

namespace QuikQuest.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<QuikQuestUser> _userManager;


        public CartController(AppDbContext db, UserManager<QuikQuestUser> usermanager)
        {
            _db = db;
            _userManager = usermanager;

        }
        public async Task<IActionResult> Index()
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cart = _db.Carts
        .Include(c => c.Products)
        .FirstOrDefault(c => c.UserId == userid);

            var allProducts = _db.Products
    .FromSqlRaw($"SELECT p.* FROM Products p INNER JOIN CartProducts cp ON p.ProductId = cp.ProductId WHERE cp.CartId = {cart.CartId}")
    .ToList();
           


            var products = cart.Products;


            return View(allProducts);
        }

        [HttpPost]
        public async Task<IActionResult> Add(int id)


        {

            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cart = await _db.Carts.FirstOrDefaultAsync(c => c.UserId == userid);
            if (cart == null)
            {
                return NotFound();
            }
            var product = _db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            if (cart == null)
    {
        return NotFound();
    }
            product.Carts.Add(cart);
            cart.Products.Add(product);
            
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
             
    var product = _db.Products.Find(id);

    
    if (product == null)
    {
        return NotFound();
    }

    
    var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
    var cart = await _db.Carts
        .Include(c => c.Products)  
        .FirstOrDefaultAsync(c => c.UserId == userid);
    if (cart == null)
    {
        return NotFound();
    }

    cart.Products.Remove(product);
    product.Carts.Remove(cart);
    await _db.SaveChangesAsync();
    return RedirectToAction("Index");


        }
    }
}
