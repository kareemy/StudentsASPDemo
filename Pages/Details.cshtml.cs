using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentsASPDemo.Models;

namespace StudentsASPDemo.Pages;

public class DetailsModel : PageModel
{
    private readonly StudentDbContext _context;
    private readonly ILogger<DetailsModel> _logger;
    // A Student property to store the details about the
    // particular student.
    // This DOES NOT need [BindProperty] because we are just
    // displaying the data, not reading it in from a form.
    public Student Student {get; set;} = default!;

    public DetailsModel(StudentDbContext context, ILogger<DetailsModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult OnGet(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var student = _context.Students.Find(id);
        if (student == null)
        {
            return NotFound();
        }
        else
        {
            Student = student;
        }
        return Page();
    }
}