using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsuranceManagementSystem.Data;
using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.Controllers
{
    [Authorize]
    public class PolicyController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public PolicyController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> MyPolicies()
        {
            var userId = _userManager.GetUserId(User);
            var policies = await _context.Policies
                .Include(p => p.LifeInsurance)
                .Include(p => p.MedicalInsurance)
                .Include(p => p.MotorInsurance)
                .Include(p => p.HomeInsurance)
                .Where(p => p.UserId == userId)
                .OrderByDescending(p => p.ApplicationDate)
                .ToListAsync();

            return View(policies);
        }

        public IActionResult Apply(string? type)
        {
            ViewBag.PolicyType = type;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApplyLife(PolicyApplicationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var policyNumber = GeneratePolicyNumber("LIFE");

                var policy = new Policy
                {
                    UserId = userId!,
                    PolicyNumber = policyNumber,
                    PolicyType = "Life",
                    CoverageAmount = model.CoverageAmount,
                    PremiumAmount = model.PremiumAmount,
                    StartDate = DateTime.Now.AddDays(7),
                    EndDate = DateTime.Now.AddYears(model.TermPeriod),
                    Status = "Pending",
                    ApplicationDate = DateTime.Now
                };

                _context.Policies.Add(policy);
                await _context.SaveChangesAsync();

                var lifeInsurance = new LifeInsurance
                {
                    PolicyId = policy.PolicyId,
                    Age = model.Age,
                    TermPeriod = model.TermPeriod,
                    SmokingStatus = model.SmokingStatus!,
                    HealthStatus = model.HealthStatus!,
                    Occupation = model.Occupation,
                    BeneficiaryName = model.BeneficiaryName,
                    BeneficiaryRelation = model.BeneficiaryRelation
                };

                _context.LifeInsurances.Add(lifeInsurance);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Your life insurance application has been submitted successfully!";
                return RedirectToAction(nameof(MyPolicies));
            }

            return View("Apply", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApplyMedical(MedicalPolicyApplicationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var policyNumber = GeneratePolicyNumber("MED");

                var policy = new Policy
                {
                    UserId = userId!,
                    PolicyNumber = policyNumber,
                    PolicyType = "Medical",
                    CoverageAmount = model.CoverageAmount,
                    PremiumAmount = model.PremiumAmount,
                    StartDate = DateTime.Now.AddDays(7),
                    EndDate = DateTime.Now.AddYears(1),
                    Status = "Pending",
                    ApplicationDate = DateTime.Now
                };

                _context.Policies.Add(policy);
                await _context.SaveChangesAsync();

                var medicalInsurance = new MedicalInsurance
                {
                    PolicyId = policy.PolicyId,
                    Age = model.Age,
                    HasPreExistingConditions = model.HasPreExistingConditions,
                    PreExistingConditionDetails = model.PreExistingConditionDetails,
                    NumberOfFamilyMembers = model.NumberOfFamilyMembers,
                    BloodGroup = model.BloodGroup,
                    Height = model.Height,
                    Weight = model.Weight
                };

                _context.MedicalInsurances.Add(medicalInsurance);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Your medical insurance application has been submitted successfully!";
                return RedirectToAction(nameof(MyPolicies));
            }

            return View("Apply", model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var userId = _userManager.GetUserId(User);
            var policy = await _context.Policies
                .Include(p => p.LifeInsurance)
                .Include(p => p.MedicalInsurance)
                .Include(p => p.MotorInsurance)
                .Include(p => p.HomeInsurance)
                .FirstOrDefaultAsync(p => p.PolicyId == id && p.UserId == userId);

            if (policy == null)
            {
                return NotFound();
            }

            return View(policy);
        }

        private string GeneratePolicyNumber(string prefix)
        {
            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            var random = new Random().Next(1000, 9999);
            return $"{prefix}{timestamp}{random}";
        }
    }
}
