using System.ComponentModel.DataAnnotations;

namespace App.Models.Dto;

public class PersonDto
{
    public string? FirstName { get; set;}
    
    public string? LastName { get; set;}

    [Required]
    public bool IsEmployed { get; set;}

    public int? Employment{ get; set; }
}