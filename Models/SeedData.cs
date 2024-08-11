using Microsoft.EntityFrameworkCore;

namespace StudentsASPDemo.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new StudentDbContext(serviceProvider.GetRequiredService<DbContextOptions<StudentDbContext>>());

        if (context.Students.Any()) 
        {
            return;
        }

        context.Students.AddRange(
            new Student { FirstName = "Alice", LastName = "Johnson", Major = "Computer Science", Age = 20 },
            new Student { FirstName = "Bob", LastName = "Smith", Major = "Mathematics", Age = 22 },
            new Student { FirstName = "Carol", LastName = "Davis", Major = "Physics", Age = 21 },
            new Student { FirstName = "David", LastName = "Garcia", Major = "Engineering", Age = 23 },
            new Student { FirstName = "Eve", LastName = "Martinez", Major = "Biology", Age = 19 }
        );

        context.SaveChanges();
    }
}