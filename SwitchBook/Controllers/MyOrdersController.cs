using Microsoft.AspNetCore.Mvc;
using SwitchBook.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SwitchBook.Models;

namespace SwitchBook.Controllers
{
    public class MyOrdersController : Controller
    {
        private ApplicationDbContext _db;
        public MyOrdersController(ApplicationDbContext context)
        {
            _db = context;
        }
        public async Task<IActionResult> Index()
        {
            var myBooks= _db.Books.Where(x=>x.OwnerId == _db.Users.First(p=>p.UserName==User.Identity.Name).Id);
            var orderRequest = await _db.Orders.Where(x=>myBooks.Select(b=>b.Id).Contains(x.FirstBookId) && x.IsConfirm ==false).ToListAsync();
            var b1 = await _db.Books.Where(x=>orderRequest.Select(b=>b.FirstBookId).Contains(x.Id)).ToListAsync();
            var b2 = await _db.Books.Where(x=>orderRequest.Select(b=>b.LastBookId).Contains(x.Id)).ToListAsync();

            var books1 = _db.Books;  

            return Ok(b1);
        }
    }
}
