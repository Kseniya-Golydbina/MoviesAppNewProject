using System;
using System.ComponentModel.DataAnnotations;
using MoviesApp.Filters;

namespace MoviesApp.Services.ActorService.Dto
{
    public class ActorDto
    {
        public int? Id { get; set; }

        [Required]
        [Validation(4)]
        public string FirstName { get; set; }

        [Required]
        [Validation(4)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [FiltersAge(7, 99)]
        public DateTime BirthOfDate { get; set; }
    }
}
