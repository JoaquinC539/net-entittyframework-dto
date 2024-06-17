using App.Contexts;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Services;

public class EmploymentService
{
    private readonly PersonContext _personContext;

    public EmploymentService(PersonContext context)
    {
        _personContext = context;
    }

    public IEnumerable<Employment> GetAll()
    {
        return _personContext.Employments
        .AsNoTracking()
        .ToList();
    }

    public Employment? GetById(int id)
    {
        return _personContext.Employments
        .AsNoTracking()
        .SingleOrDefault(e=>e.Id == id);
    }

    public Employment? Create(Employment employment)
    {
        _personContext.Employments.Add(employment);
        _personContext.SaveChanges();
        return employment;
    }
    public Employment? Update(int id, Employment employment)
    {

        var employmentOriginal = _personContext.Employments.Find(id);
        if(employmentOriginal != null)
        {
            employmentOriginal.Name=employment.Name;
            _personContext.SaveChanges();
            return employmentOriginal;
        }
        return null;
    }
    public Employment? Delete(int id)
    {
        var employment = _personContext.Employments.Find(id);
        if(employment==null)
         {
            return null;
         }
        _personContext.Employments.Remove(employment);        
        _personContext.SaveChanges();
        return employment;
    }
}