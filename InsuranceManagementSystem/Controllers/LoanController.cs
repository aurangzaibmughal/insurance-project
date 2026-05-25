using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsuranceManagementSystem.Data;
using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.Controllers
{
    [Authorize]
    public class LoanController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoanController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var loans = await _context.Loans
                .Include(l => l.Policy)
                .Where(l => l.UserId == userId)
                .OrderByDescending(l => l.ApplicationDate)
                .ToListAsync();

            return View(loans);
        }

        public async Task<IActionResult> Apply(int policyId)
        {
            var userId = _userManager.GetUserId(User);
            var policy = await _context.Policies
                .FirstOrDefaultAsync(p => p.PolicyId == policyId && p.UserId == userId && p.Status == "Approved");

            if (policy == null)
            {
                return NotFound();
            }

            // Check if there's already a pending or approved loan for this policy
            var existingLoan = await _context.Loans
                .FirstOrDefaultAsync(l => l.PolicyId == policyId && (l.Status == "Pending" || l.Status == "Approved"));

            if (existingLoan != null)
            {
                TempData["Error"] = "You already have a loan application for this policy.";
                return RedirectToAction(nameof(Index));
            }

            var model = new LoanApplicationViewModel
            {
                PolicyId = policy.PolicyId,
                PolicyNumber = policy.PolicyNumber,
                PolicyType = policy.PolicyType,
                PolicyValue = policy.CoverageAmount,
                InterestRate = 10.5m
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Apply(LoanApplicationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var policy = await _context.Policies
                    .FirstOrDefaultAsync(p => p.PolicyId == model.PolicyId && p.UserId == userId && p.Status == "Approved");

                if (policy == null)
                {
                    return NotFound();
                }

                // Validate loan amount (max 80% of policy value)
                var maxLoanAmount = policy.CoverageAmount * 0.8m;
                if (model.LoanAmount > maxLoanAmount)
                {
                    ModelState.AddModelError("LoanAmount", $"Loan amount cannot exceed 80% of policy value (₹{maxLoanAmount:N0})");
                    return View(model);
                }

                // Calculate EMI
                var monthlyEMI = CalculateEMI(model.LoanAmount, model.InterestRate, model.TenureMonths);

                var loan = new Loan
                {
                    UserId = userId!,
                    PolicyId = model.PolicyId,
                    LoanAmount = model.LoanAmount,
                    PolicyValue = policy.CoverageAmount,
                    InterestRate = model.InterestRate,
                    TenureMonths = model.TenureMonths,
                    ApplicationDate = DateTime.Now,
                    Status = "Pending",
                    MonthlyEMI = monthlyEMI
                };

                _context.Loans.Add(loan);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Your loan application has been submitted successfully!";
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var userId = _userManager.GetUserId(User);
            var loan = await _context.Loans
                .Include(l => l.Policy)
                .FirstOrDefaultAsync(l => l.LoanId == id && l.UserId == userId);

            if (loan == null)
            {
                return NotFound();
            }

            return View(loan);
        }

        [HttpPost]
        public IActionResult CalculateEMI([FromBody] LoanCalculationRequest request)
        {
            var emi = CalculateEMI(request.LoanAmount, request.InterestRate, request.TenureMonths);
            return Json(new { monthlyEMI = emi });
        }

        private decimal CalculateEMI(decimal principal, decimal annualRate, int months)
        {
            if (months == 0) return 0;

            var monthlyRate = (double)(annualRate / 12 / 100);
            var emi = (double)principal * monthlyRate * Math.Pow(1 + monthlyRate, months) / (Math.Pow(1 + monthlyRate, months) - 1);
            return Math.Round((decimal)emi, 2);
        }
    }

    public class LoanCalculationRequest
    {
        public decimal LoanAmount { get; set; }
        public decimal InterestRate { get; set; }
        public int TenureMonths { get; set; }
    }
}
