using Microsoft.AspNetCore.Mvc;
using SwitchBook.Data;
using System.Linq;

namespace SwitchBook.Controllers
{
    public class MyOrdersController : Controller
    {
        private ApplicationDbContext _db;
        public MyOrdersController(ApplicationDbContext context)
        {
            _db = context;
        }
        //public IActionResult Index()
        //{
            
            
        //}
    }
}
