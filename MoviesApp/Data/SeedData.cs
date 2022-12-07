using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoviesApp.Models;

namespace MoviesApp.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            Console.WriteLine("Seeding Database");
            using (var context = new MoviesContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MoviesContext>>()))
            {
                // Look for any movies.
                if (context.Movies.Any())
                {
                    context.Movies.AddRange(
                        new Movie
                        {
                            Title = "When Harry Met Sally",
                            ReleaseDate = DateTime.Parse("1989-2-12"),
                            Genre = "Romantic Comedy",
                            Price = 7.99M
                        },


                        new Movie
                        {
                            Title = "Ghostbusters ",
                            ReleaseDate = DateTime.Parse("1984-3-13"),
                            Genre = "Comedy",
                            Price = 8.99M
                        },

                        new Movie
                        {
                            Title = "Ghostbusters 2",
                            ReleaseDate = DateTime.Parse("1986-2-23"),
                            Genre = "Comedy",
                            Price = 9.99M
                        },

                        new Movie
                        {
                            Title = "Rio Bravo",
                            ReleaseDate = DateTime.Parse("1959-4-15"),
                            Genre = "Western",
                            Price = 3.99M
                        }
                    );

                    context.SaveChanges();
                }
                // Look for any actors.

                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(
                        new Actor
                        {
                            FirstName = "Sherlock",
                            LastName = "Holmes",
                            DataOfBirth = new DateTime(1977, 1, 6)
                        },
                        new Actor
                        {
                            FirstName = "Eurus",
                            LastName = "Holmes",
                            DataOfBirth = new DateTime(1983, 5, 7)
                        },
                        new Actor
                        {
                            FirstName = "James",
                            LastName = "Moriarty",
                            DataOfBirth = new DateTime(1975, 10, 11)
                        },
                        new Actor
                        {
                            FirstName = "Irene",
                            LastName = "Adler",
                            DataOfBirth = new DateTime(1985, 7, 1)
                        },
                        new Actor
                        {
                            FirstName = "Gohn",
                            LastName = "Watson",
                            DataOfBirth = new DateTime(1988, 4, 1)
                        }
                    );

                    context.SaveChanges();
                }
            }
        }
    }
}