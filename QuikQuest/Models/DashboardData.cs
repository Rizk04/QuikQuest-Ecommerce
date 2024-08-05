using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuikQuest.Areas.Identity.Data;
using QuikQuest.Data;


namespace QuikQuest.Models
{

    public class DashboardData

    {
        private AppDbContext _db1;
        private AuthDbContext _db2;

        public DashboardData(AppDbContext db1, AuthDbContext db2)
        {
            _db1 = db1;
            _db2 = db2;
            ProductsCount = _db1.Products.Count();
            UsersCount = _db2.Users.Count();
            RolesCount = _db2.Roles.Count();
            QuestionsCount = _db1.Questions.Count();
            ReviewsCount = _db1.Reviews.Count();

        }

       

        public int ProductsCount;
        public int UsersCount;
        public int RolesCount;
        public int QuestionsCount;
        public int ReviewsCount;


    }
}
