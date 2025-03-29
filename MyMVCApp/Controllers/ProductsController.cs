using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMvcProject.Models;
using System.Linq;
using System.Threading.Tasks;

public class ProductsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProductsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Index Action with Pagination
    public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
    {
        var totalProducts = await _context.Products.CountAsync();
        var products = await _context.Products
            .OrderBy(p => p.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        ViewBag.TotalPages = (int)Math.Ceiling((double)totalProducts / pageSize);
        ViewBag.CurrentPage = page;

        return View(products);
    }

    // Search Action with Pagination
    public async Task<IActionResult> Search(string searchTerm, int page = 1, int pageSize = 10)
    {
        var query = _context.Products.Where(p => p.Name.Contains(searchTerm));

        var totalProducts = await query.CountAsync();
        var products = await query
            .OrderBy(p => p.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        ViewBag.TotalPages = (int)Math.Ceiling((double)totalProducts / pageSize);
        ViewBag.CurrentPage = page;

        return PartialView("_ProductTablePartial", products);
    }
}
