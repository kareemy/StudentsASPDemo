using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentsASPDemo.Models;

namespace StudentsASPDemo.Pages;

public class IndexModel : PageModel
{
    // Add: Property for database context
    private readonly StudentDbContext _context; // Replaces the "db" variable from before
    private readonly ILogger<IndexModel> _logger;
    public List<Student> Students {get; set;} = default!;    

    public IndexModel(StudentDbContext context, ILogger<IndexModel> logger)
    {
        _context = context; // Set database context - this is part 2 of dependency injection
        _logger = logger;
    }

    public void OnGet()
    {
        Students = _context.Students.ToList();
    }
}
