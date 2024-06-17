using App.Contexts;
using App.Models;
using App.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace App.Services;

public class PersonService
{
    private readonly PersonContext _personContext;

    public PersonService(PersonContext personContext)
    {
        _personContext = personContext;
    }
    public IEnumerable<Person> GetAll()
    {
        return _personContext.Persons
        .Include(p => p.Employment)
        .ToList();
    }
    public Person? GetById(int id)
    {
        return _personContext.Persons
        .Include(p => p.Employment)
        .SingleOrDefault(p => p.Id == id);
    }
    public Person? Create(PersonDto personDto)
    {
        Person person = new Person
        {
            FirstName = personDto.FirstName,
            LastName = personDto.LastName,
            IsEmployed = personDto.IsEmployed,
        };
        if (personDto.IsEmployed)
        {
            var employment = _personContext.Employments.Find(personDto.Employment);
            if (employment == null)
            {
                return null;
            }
            person.Employment = employment;
        }
        _personContext.Persons.Add(person);
        _personContext.SaveChanges();
        return person;
    }
    public Person? Update(int id, PersonDto personDto)
    {
        var person = _personContext.Persons.Find(id);
        if (person == null)
        {
            return null;
        }
        person.FirstName = personDto.FirstName;
        person.LastName = personDto.LastName;
        person.IsEmployed = personDto.IsEmployed;
        if (person.IsEmployed)
        {
            var employment = _personContext.Employments.Find(personDto.Employment);
            if (employment == null)
            {
                return null;
            }
            person.Employment = employment;
        }
        else{
            
            person.Employment =null;
        }
        
        _personContext.SaveChanges();
        return person;


    }
    public Person? Delete(int id)
    {
        var person = _personContext.Persons.Find(id);
        if (person == null)
        {
            return null;
        }
        _personContext.Persons.Remove(person);
        _personContext.SaveChanges();
        return person;
    }
}