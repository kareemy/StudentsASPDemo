using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentsASPDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentsASPDemo.Pages;

public class EditModel : PageModel
{
    private readonly StudentDbContext _context;
    private readonly ILogger<EditModel> _logger;

    // A Student property that will be edited
    // in a form, so [BindProperty] is needed
    [BindProperty]
    public Student Student {get; set;} = default!;

    public EditModel(StudentDbContext context, ILogger<EditModel> logger)
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

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Student).State = EntityState.Modified;
        _context.SaveChanges();

        return RedirectToPage("./Index");
    }
}