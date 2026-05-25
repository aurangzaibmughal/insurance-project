using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InsuranceManagementSystem.Services;
using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.Controllers
{
    [Authorize]
    public class CalculatorController : Controller
    {
        private readonly PremiumCalculatorService _calculatorService;

        public CalculatorController(PremiumCalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CalculateLife(LifeInsuranceCalculatorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var premium = _calculatorService.CalculateLifeInsurancePremium(
                    model.Age,
                    model.CoverageAmount,
                    model.TermPeriod,
                    model.SmokingStatus,
                    model.HealthStatus
                );

                ViewBag.Premium = premium;
                ViewBag.InsuranceType = "Life";
                ViewBag.CoverageAmount = model.CoverageAmount;
            }

            return View("Index", model);
        }

        [HttpPost]
        public IActionResult CalculateMedical(MedicalInsuranceCalculatorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var premium = _calculatorService.CalculateMedicalInsurancePremium(
                    model.Age,
                    model.CoverageAmount,
                    model.HasPreExistingConditions,
                    model.NumberOfFamilyMembers
                );

                ViewBag.Premium = premium;
                ViewBag.InsuranceType = "Medical";
                ViewBag.CoverageAmount = model.CoverageAmount;
            }

            return View("Index", model);
        }

        [HttpPost]
        public IActionResult CalculateMotor(MotorInsuranceCalculatorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var premium = _calculatorService.CalculateMotorInsurancePremium(
                    model.VehicleValue,
                    model.VehicleType,
                    model.VehicleAge
                );

                ViewBag.Premium = premium;
                ViewBag.InsuranceType = "Motor";
                ViewBag.CoverageAmount = model.VehicleValue;
            }

            return View("Index", model);
        }

        [HttpPost]
        public IActionResult CalculateHome(HomeInsuranceCalculatorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var premium = _calculatorService.CalculateHomeInsurancePremium(
                    model.PropertyValue,
                    model.PropertyType,
                    model.ConstructionType,
                    model.PropertyAge,
                    model.HasSecuritySystem
                );

                ViewBag.Premium = premium;
                ViewBag.InsuranceType = "Home";
                ViewBag.CoverageAmount = model.PropertyValue;
            }

            return View("Index", model);
        }
    }
}
