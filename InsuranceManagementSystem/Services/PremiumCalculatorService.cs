namespace InsuranceManagementSystem.Services
{
    public class PremiumCalculatorService
    {
        public decimal CalculateLifeInsurancePremium(int age, decimal coverageAmount, int termPeriod, string smokingStatus, string healthStatus)
        {
            decimal baseRate = 0.005m;
            decimal premium = (coverageAmount / 1000) * baseRate * termPeriod;

            // Age factor
            if (age > 50) premium *= 1.5m;
            else if (age > 40) premium *= 1.3m;
            else if (age > 30) premium *= 1.1m;

            // Smoking factor
            if (smokingStatus == "Smoker") premium *= 1.5m;

            // Health factor
            switch (healthStatus)
            {
                case "Excellent":
                    premium *= 0.9m;
                    break;
                case "Good":
                    premium *= 1.0m;
                    break;
                case "Fair":
                    premium *= 1.2m;
                    break;
                case "Poor":
                    premium *= 1.5m;
                    break;
            }

            return Math.Round(premium, 2);
        }

        public decimal CalculateMedicalInsurancePremium(int age, decimal coverageAmount, bool hasPreExistingConditions, int numberOfFamilyMembers)
        {
            decimal baseRate = 0.03m;
            decimal premium = coverageAmount * baseRate;

            // Age factor
            if (age > 60) premium *= 2.0m;
            else if (age > 45) premium *= 1.5m;
            else if (age > 30) premium *= 1.2m;

            // Pre-existing conditions factor
            if (hasPreExistingConditions) premium *= 1.4m;

            // Family members factor
            if (numberOfFamilyMembers > 1)
            {
                premium *= (1 + (numberOfFamilyMembers - 1) * 0.3m);
            }

            return Math.Round(premium, 2);
        }

        public decimal CalculateMotorInsurancePremium(decimal vehicleValue, string vehicleType, int vehicleAge)
        {
            decimal baseRate = 0.03m;
            decimal premium = vehicleValue * baseRate;

            // Vehicle type factor
            switch (vehicleType)
            {
                case "Two Wheeler":
                    premium *= 0.7m;
                    break;
                case "Car":
                    premium *= 1.0m;
                    break;
                case "SUV":
                    premium *= 1.3m;
                    break;
                case "Commercial":
                    premium *= 1.5m;
                    break;
            }

            // Vehicle age factor
            if (vehicleAge > 10) premium *= 1.5m;
            else if (vehicleAge > 5) premium *= 1.3m;
            else if (vehicleAge > 2) premium *= 1.1m;
            else premium *= 0.9m;

            return Math.Round(premium, 2);
        }

        public decimal CalculateHomeInsurancePremium(decimal propertyValue, string propertyType, string constructionType, int propertyAge, bool hasSecuritySystem)
        {
            decimal baseRate = 0.005m;
            decimal premium = propertyValue * baseRate;

            // Property type factor
            switch (propertyType)
            {
                case "Apartment":
                    premium *= 0.8m;
                    break;
                case "Independent House":
                    premium *= 1.0m;
                    break;
                case "Villa":
                    premium *= 1.2m;
                    break;
            }

            // Construction type factor
            switch (constructionType)
            {
                case "RCC":
                    premium *= 0.9m;
                    break;
                case "Brick":
                    premium *= 1.0m;
                    break;
                case "Wood":
                    premium *= 1.3m;
                    break;
            }

            // Property age factor
            if (propertyAge > 20) premium *= 1.4m;
            else if (propertyAge > 10) premium *= 1.2m;
            else if (propertyAge > 5) premium *= 1.1m;

            // Security system discount
            if (hasSecuritySystem) premium *= 0.9m;

            return Math.Round(premium, 2);
        }
    }
}
