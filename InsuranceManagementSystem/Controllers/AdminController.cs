using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsuranceManagementSystem.Data;
using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var totalUsers = await _context.Users.CountAsync();
            var totalPolicies = await _context.Policies.CountAsync();
            var pendingPolicies = await _context.Policies.CountAsync(p => p.Status == "Pending");
            var approvedPolicies = await _context.Policies.CountAsync(p => p.Status == "Approved");
            var totalLoans = await _context.Loans.CountAsync();
            var pendingLoans = await _context.Loans.CountAsync(l => l.Status == "Pending");
            var totalRevenue = await _context.Payments.SumAsync(p => (decimal?)p.Amount) ?? 0;

            ViewBag.TotalUsers = totalUsers;
            ViewBag.TotalPolicies = totalPolicies;
            ViewBag.PendingPolicies = pendingPolicies;
            ViewBag.ApprovedPolicies = approvedPolicies;
            ViewBag.TotalLoans = totalLoans;
            ViewBag.PendingLoans = pendingLoans;
            ViewBag.TotalRevenue = totalRevenue;

            return View();
        }

        public async Task<IActionResult> Users()
        {
            var users = await _context.Users
                .OrderByDescending(u => u.CreatedDate)
                .ToListAsync();

            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> ToggleUserStatus(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.IsActive = !user.IsActive;
                await _userManager.UpdateAsync(user);
                TempData["Success"] = $"User status updated successfully.";
            }

            return RedirectToAction(nameof(Users));
        }

        public async Task<IActionResult> Policies()
        {
            var policies = await _context.Policies
                .Include(p => p.User)
                .OrderByDescending(p => p.ApplicationDate)
                .ToListAsync();

            return View(policies);
        }

        [HttpPost]
        public async Task<IActionResult> ApprovePolicy(int policyId)
        {
            var policy = await _context.Policies.FindAsync(policyId);
            if (policy != null && policy.Status == "Pending")
            {
                policy.Status = "Approved";
                policy.ApprovalDate = DateTime.Now;
                await _context.SaveChangesAsync();
                TempData["Success"] = "Policy approved successfully.";
            }

            return RedirectToAction(nameof(Policies));
        }

        [HttpPost]
        public async Task<IActionResult> RejectPolicy(int policyId, string reason)
        {
            var policy = await _context.Policies.FindAsync(policyId);
            if (policy != null && policy.Status == "Pending")
            {
                policy.Status = "Rejected";
                policy.RejectionReason = reason;
                await _context.SaveChangesAsync();
                TempData["Success"] = "Policy rejected.";
            }

            return RedirectToAction(nameof(Policies));
        }

        public async Task<IActionResult> Loans()
        {
            var loans = await _context.Loans
                .Include(l => l.User)
                .Include(l => l.Policy)
                .OrderByDescending(l => l.ApplicationDate)
                .ToListAsync();

            return View(loans);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveLoan(int loanId)
        {
            var loan = await _context.Loans.FindAsync(loanId);
            if (loan != null && loan.Status == "Pending")
            {
                loan.Status = "Approved";
                loan.ApprovalDate = DateTime.Now;
                await _context.SaveChangesAsync();
                TempData["Success"] = "Loan approved successfully.";
            }

            return RedirectToAction(nameof(Loans));
        }

        [HttpPost]
        public async Task<IActionResult> RejectLoan(int loanId, string reason)
        {
            var loan = await _context.Loans.FindAsync(loanId);
            if (loan != null && loan.Status == "Pending")
            {
                loan.Status = "Rejected";
                loan.RejectionReason = reason;
                await _context.SaveChangesAsync();
                TempData["Success"] = "Loan rejected.";
            }

            return RedirectToAction(nameof(Loans));
        }

        public async Task<IActionResult> Reports()
        {
            var policyStats = await _context.Policies
                .GroupBy(p => p.PolicyType)
                .Select(g => new { PolicyType = g.Key, Count = g.Count() })
                .ToListAsync();

            var monthlyRevenue = await _context.Payments
                .Where(p => p.PaymentDate >= DateTime.Now.AddMonths(-6))
                .GroupBy(p => new { p.PaymentDate.Year, p.PaymentDate.Month })
                .Select(g => new {
                    Month = $"{g.Key.Year}-{g.Key.Month:D2}",
                    Revenue = g.Sum(p => p.Amount)
                })
                .ToListAsync();

            ViewBag.PolicyStats = policyStats;
            ViewBag.MonthlyRevenue = monthlyRevenue;

            return View();
        }
    }
}
