// using AztroWebApplication.Services;
// using AztroWebApplication.Models; // Assuming TaskService is in the Models namespace
// using Microsoft.AspNetCore.Mvc;
// namespace AztroWebApplication.Controllers
// {
//     public class TaskController : ControllerBase
//     {
//         private readonly TaskService taskService = new();

//         [HttpGet]
//         public IActionResult GetAllTasks()
//         {
//             var tasks = taskService.GetAllTasks();

//             return Ok(tasks);
//         }


//     }
// }