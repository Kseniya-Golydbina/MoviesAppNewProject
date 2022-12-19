using System;
using System.ComponentModel.DataAnnotations;
using MoviesApp.Filters;

namespace MoviesApp.ViewModels.Actors
{
    public class InputActorViewModel
    {
        [ValidationOfActors]
        public string FirstName { get; set; }

        [ValidationOfActors]
        public string LastName { get; set; }

        [DataType(DataType.Date)]

        public DateTime DataOfBirth { get; set; }
    }
}
