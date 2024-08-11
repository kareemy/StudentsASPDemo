using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentsASPDemo.Models;

namespace StudentsASPDemo.Pages;

public class CreateModel : PageModel
{
    private readonly StudentDbContext _context;
    private readonly ILogger<CreateModel> _logger;
    [BindProperty]
    public Student Student {get; set;} = default!;

    public CreateModel(StudentDbContext context, ILogger<CreateModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
{
    // Perform server-side data validation
    // Required because client-side data validation cannot be guaranteed
    // If the model is invalid, return to the same page without modifying the db
    if (!ModelState.IsValid)
    {
        return Page();
    }

    // Server-side data validation succeeded. The Student property is guaranteed
    // to be populated with the user input.
    // Add the Student to the database.
    _context.Students.Add(Student);
    _context.SaveChanges(); // Save changes to the database.

    // Return to the Index page so we can see the results.
    return RedirectToPage("./Index");
}
}