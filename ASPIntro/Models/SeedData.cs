
using ASPIntro.Data;
using Microsoft.EntityFrameworkCore;
namespace ASPIntro.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ASPIntroContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<ASPIntroContext>>()))
        {
            if (context == null || context.Filme == null)
            {
                throw new ArgumentNullException("Null RazorPagesFilmeContext");
            }

            // Look for any Filmes.
            if (context.Filme.Any())
            {
                return;   // DB has been seeded
            }

            context.Filme.AddRange(
                new Filme
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Price = 7.99M,
                    Rating= "7.8"
                },

                new Filme
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Price = 8.99M,
                    Rating = "9.8"
                },

                new Filme
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Price = 9.99M,
                    Rating = "8.8"
                },

                new Filme
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Price = 3.99M,
                    Rating = "8"
                }
            );
            context.SaveChanges();
        }
    }
}