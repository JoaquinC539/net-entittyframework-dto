using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table("Persons")]
public class Person
{
    public int Id { get; set;}

    [Required]
    [MaxLength(100)]
    public string? FirstName { get; set;}

    [Required]
    [MaxLength(100)]
    public string? LastName { get; set;}


    [Required]    
    public bool IsEmployed { get; set;}

    public Employment? Employment{ get; set; }
}