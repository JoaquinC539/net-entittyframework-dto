using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Contexts;

public class PersonContext: DbContext
{
    public PersonContext (DbContextOptions<PersonContext> options):base(options)
    {}
    public DbSet<Employment> Employments =>Set<Employment>(); 
    public DbSet<Person> Persons =>Set<Person>();
    
}