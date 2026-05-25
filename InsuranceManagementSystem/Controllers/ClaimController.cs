using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsuranceManagementSystem.Data;
using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.Controllers
{
    [Authorize]
    public class ClaimController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ClaimController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Claim
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var claims = await _context.Claims
                .Include(c => c.Policy)
                .Where(c => c.UserId == user.Id)
                .OrderByDescending(c => c.ClaimDate)
                .ToListAsync();

            return View(claims);
        }

        // GET: Claim/Create
        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var policies = await _context.Policies
                .Where(p => p.UserId == user.Id && p.Status == "Active")
                .ToListAsync();

            ViewBag.Policies = policies;
            return View();
        }

        // POST: Claim/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Claim claim)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            claim.UserId = user.Id;
            claim.ClaimNumber = $"CLM-{DateTime.Now:yyyyMMdd}-{new Random().Next(1000, 9999)}";
            claim.ClaimDate = DateTime.Now;
            claim.Status = "Pending";
            claim.CreatedDate = DateTime.Now;

            _context.Claims.Add(claim);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Claim submitted successfully!";
            return RedirectToAction(nameof(Index));
        }

        // GET: Claim/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            var claim = await _context.Claims
                .Include(c => c.Policy)
                .FirstOrDefaultAsync(c => c.ClaimId == id && c.UserId == user.Id);

            if (claim == null)
            {
                return NotFound();
            }

            return View(claim);
        }
    }
}
