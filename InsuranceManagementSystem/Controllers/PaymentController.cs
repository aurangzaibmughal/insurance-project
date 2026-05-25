using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsuranceManagementSystem.Data;
using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public PaymentController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Pay(int policyId)
        {
            var userId = _userManager.GetUserId(User);
            var policy = await _context.Policies
                .FirstOrDefaultAsync(p => p.PolicyId == policyId && p.UserId == userId && p.Status == "Approved");

            if (policy == null)
            {
                return NotFound();
            }

            var model = new PaymentViewModel
            {
                PolicyId = policy.PolicyId,
                PolicyNumber = policy.PolicyNumber,
                PolicyType = policy.PolicyType,
                PremiumAmount = policy.PremiumAmount
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProcessPayment(PaymentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var policy = await _context.Policies
                    .FirstOrDefaultAsync(p => p.PolicyId == model.PolicyId && p.UserId == userId);

                if (policy == null)
                {
                    return NotFound();
                }

                var payment = new Payment
                {
                    UserId = userId!,
                    PolicyId = model.PolicyId,
                    Amount = model.Amount,
                    PaymentDate = DateTime.Now,
                    PaymentMethod = model.PaymentMethod!,
                    TransactionId = GenerateTransactionId(),
                    Status = "Completed",
                    Remarks = model.Remarks
                };

                _context.Payments.Add(payment);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Payment processed successfully!";
                return RedirectToAction(nameof(History));
            }

            return View("Pay", model);
        }

        public async Task<IActionResult> History()
        {
            var userId = _userManager.GetUserId(User);
            var payments = await _context.Payments
                .Include(p => p.Policy)
                .Where(p => p.UserId == userId)
                .OrderByDescending(p => p.PaymentDate)
                .ToListAsync();

            return View(payments);
        }

        private string GenerateTransactionId()
        {
            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            var random = new Random().Next(100000, 999999);
            return $"TXN{timestamp}{random}";
        }
    }
}
