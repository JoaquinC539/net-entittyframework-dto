using App.Models;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmploymentController:ControllerBase
{
    private readonly EmploymentService _employmentService;

    public EmploymentController(EmploymentService employmentService)
    {
        _employmentService = employmentService;
    }
    [HttpGet]
    public  ActionResult<IEnumerable<Employment>> GetEmployments()
    {
       return Ok(_employmentService.GetAll());
    }
    [HttpGet]
    [Route("{id}")]
    public ActionResult<Employment> GetById([FromRoute] int id)
    {
        var employment = _employmentService.GetById(id);
        if(employment == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(employment);
        }
    }
    [HttpPost]
    public IActionResult Create ([FromBody] Employment employment)
    {
        if(employment == null )
        {
            return BadRequest();
        }
        var employmentSave=_employmentService.Create(employment);
        if(employmentSave == null)
        {
            return BadRequest();
        }

        // return Ok(employmentSave);
        return CreatedAtAction(nameof(GetById),new {id=employmentSave.Id},employmentSave);
        
    }
    [HttpPut]
    [Route("{id}")]
    public IActionResult Update([FromBody] Employment employment,[FromRoute] int id)
    {
        if(employment == null )
        {
            return BadRequest();
        }
        var employmentUpdate=_employmentService.Update(id,employment);
        if( employmentUpdate == null)
        {
            return NotFound();
        }
        return Ok(employmentUpdate);
    }
    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var employmentDelete=_employmentService.Delete(id);
        if(employmentDelete == null){
            return NotFound();
        }
        return NoContent();
    }

}