    using Microsoft.AspNetCore.Mvc;

namespace TodoListVtect.Controllers
{
    public class TodoListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
