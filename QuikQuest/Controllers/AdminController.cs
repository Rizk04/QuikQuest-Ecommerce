using Microsoft.AspNetCore.Mvc;
using Humanizer;
using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;
using QuikQuest.Areas.Identity.Data;
using QuikQuest.Data;
using QuikQuest.Models;
using System;
using System.Security.Claims;
namespace QuikQuest.Controllers
{
    public class AdminController : Controller
    {
        public AppDbContext _db1;
        public AuthDbContext _db2;
        public AdminController(AppDbContext db1, AuthDbContext db2)
        {
            _db1 = db1;
            _db2 = db2;
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
           DashboardData data = new DashboardData(_db1, _db2);

            return View(data);
        }
    }
}
