using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentsASPDemo.Models;

namespace StudentsASPDemo.Pages;

public class DeleteModel : PageModel
{
    private readonly StudentDbContext _context;
    private readonly ILogger<DeleteModel> _logger;

    [BindProperty]
    public Student Student {get; set;} = default!;

    public DeleteModel(StudentDbContext context, ILogger<DeleteModel> logger)
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

    public IActionResult OnPost(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var student = _context.Students.Find(id);
        if (student != null)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
        }

        return RedirectToPage("./Index");
    }
}