using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsuranceManagementSystem.Data;
using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DashboardController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var viewModel = new DashboardViewModel
            {
                TotalPolicies = await _context.Policies.CountAsync(p => p.UserId == user.Id),
                ActivePolicies = await _context.Policies.CountAsync(p => p.UserId == user.Id && p.Status == "Active"),
                PendingPolicies = await _context.Policies.CountAsync(p => p.UserId == user.Id && p.Status == "Pending"),
                TotalPayments = await _context.Payments.Where(p => p.UserId == user.Id).SumAsync(p => (decimal?)p.Amount) ?? 0,
                PendingPayments = await _context.Payments.CountAsync(p => p.UserId == user.Id && p.Status == "Pending"),
                RecentPolicies = await _context.Policies
                    .Where(p => p.UserId == user.Id)
                    .OrderByDescending(p => p.StartDate)
                    .Take(5)
                    .ToListAsync(),
                RecentPayments = await _context.Payments
                    .Where(p => p.UserId == user.Id)
                    .OrderByDescending(p => p.PaymentDate)
                    .Take(5)
                    .ToListAsync(),
                UserName = $"{user.FirstName} {user.LastName}"
            };

            return View(viewModel);
        }
    }
}
