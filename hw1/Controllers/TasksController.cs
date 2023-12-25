using Microsoft.AspNetCore.Mvc;
using hw1.Models;
using hw1.Services;

namespace hw1.Controllers;

[ApiController]
[Route("[controller]")]
public class TasksController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Task1>> Get()
    {
        return TaskService.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Task1> Get(int id)
    {
        var Task1 = TaskService.GetById(id);
        if (Task1 == null)
            return NotFound();
        return Task1;
    }

    [HttpPost]
    public ActionResult Post(Task1 newTask)
    {
        var newId = TaskService.Add(newTask);

        return CreatedAtAction("Post", 
            new {id = newId}, TaskService.GetById(newId));
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id,Task1 newTask)
    {
        var result = TaskService.Update(id, newTask);
        if (!result)
        {
            return BadRequest();
        }
        return NoContent();
    }
}

