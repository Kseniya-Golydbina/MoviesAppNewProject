using System;
using System.ComponentModel.DataAnnotations;
using MoviesApp.Filters;

namespace MoviesApp.ViewModels.Actors
{
    public class InputActorViewModel
    {
        [Validation(4)]
        public string FirstName { get; set; }

        [Validation(4)]
        public string LastName { get; set; }

        public DateTime Birthday { get; set; }
    }
}
