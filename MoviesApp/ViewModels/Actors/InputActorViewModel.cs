using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.ViewModels.Actors
{
    public class InputActorViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.Date)]

        public DateTime DataOfBirth { get; set; }
    }
}
