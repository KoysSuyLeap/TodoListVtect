using Microsoft.AspNetCore.Mvc;
using TodoListVtect.Models;

namespace TodoListVtect.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
       public static List<TodoListModel> TodoLists = new List<TodoListModel>();

        [HttpGet("[action]/{id}")]
        public IActionResult Get(string id)
        {
            var todoItem = TodoLists.FirstOrDefault(m=>m.Id==id);
            if (todoItem != null)
            {
                return Ok(todoItem);
            }
            return BadRequest("There Have no to-do Item");
        }

        [HttpGet("[action]")]
        public IActionResult Gets()
        {     
            if (TodoLists != null)
            {
                return Ok(TodoLists);
            }
            return BadRequest("There Have no to-do Item");
        }

        [HttpPost("[action]")]
        public ActionResult Add([FromBody] TodoListModel item)
        {
            if (item == null)
            {
                return BadRequest("The To-do Item Couldn't Null");
            }
            else if (item.Todo=="")
            {
                return BadRequest("Please Input Value To-do Name");
            }
            var todoItem = new TodoListModel 
            {
                Id = DateTime.Now.ToUniversalTime().AddHours(7).ToString("yyyyMMDDHHmmss"),
                IsCompleted = item.IsCompleted,
                CreatedAt= DateTime.Now.ToUniversalTime().AddHours(7).ToString(),
                Todo=item.Todo
            };
            TodoLists.Add(todoItem);
            return Ok(todoItem);

        }

        [HttpPost("[action]")]
        public ActionResult Update([FromBody] TodoListModel item)
        {
            if (item == null)
            {
                return BadRequest("The To-do Item Couldn't Null");
            }
            else if (item.Id == null)
            {
                return BadRequest("Your Item Have no Id");
            }
            else if (item.Todo == "")
            {
                return BadRequest("Your Item Have no To-do Name");
            }
            else if (item.CreatedAt == null)
            {
                return BadRequest("Your Item Have no Create At");
            }
            var todoItem = TodoLists.FirstOrDefault(m=>m.Id==item.Id);
            if (todoItem == null) 
            {
                return BadRequest("There Have no Item Your Provide");
            }
            todoItem.IsCompleted = item.IsCompleted;
            todoItem.Todo=item.Todo;
            return Ok();

        }

        [HttpDelete("[action]/{id}")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return BadRequest("Your Item Have no Id");
            }
            var todoItem = TodoLists.FirstOrDefault(m => m.Id == id);
            if (todoItem == null)
            {
                return BadRequest("There Have no Item Your Provide");
            }
            TodoLists.Remove(todoItem);
            return Ok();

        }
    }
}
