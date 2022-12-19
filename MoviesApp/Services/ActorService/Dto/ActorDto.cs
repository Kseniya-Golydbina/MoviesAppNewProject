using System;
using System.ComponentModel.DataAnnotations;
using MoviesApp.Filters;

namespace MoviesApp.Services.Dto;

public class ActorDto
{
    public int? Id { get; set; }

    [Required]
    [Validation(4)]
    public string Firstname { get; set; }


    [Required]
    [Validation(4)]
    public string Lastname { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [FiltersAge(7, 99)]
    public DateTime Birthdate { get; set; }
}