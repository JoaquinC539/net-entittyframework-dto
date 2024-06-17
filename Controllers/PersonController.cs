using App.Models;
using App.Models.Dto;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController: ControllerBase
{
    private readonly PersonService _personService;

    public PersonController(PersonService personService)
    {
        _personService = personService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Person>> GetAll()
    {
        return Ok(_personService.GetAll());
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<Person> GetById([FromRoute] int id)
    {
        var person= _personService.GetById(id);

        if(person==null)
        {
            return NotFound();
        }
        return Ok(person);
    }
    [HttpPost]    
    public IActionResult Create([FromBody] PersonDto personDto)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest("Model not valid");
        }
        var personSave=_personService.Create(personDto);
        if(personSave==null)
        {
            return NotFound("Employment not found");
        }
        return CreatedAtAction(nameof(GetById),new {id=personSave.Id},personSave);
    }
    [HttpPut]
    [Route("{id}")]
    public IActionResult Update([FromRoute] int id,[FromBody] PersonDto personDto)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest();
        }
        var person = _personService.Update(id,personDto);
        if(person==null)
        {
            return NotFound();
        }
        return Ok(person);
    }    

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var person=_personService.Delete(id);
        if(person==null)
        {
            return NotFound();
        }
        return NoContent();
    }

}