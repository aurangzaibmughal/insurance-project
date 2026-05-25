namespace InsuranceManagementSystem.Models
{
    public class DashboardViewModel
    {
        public string UserName { get; set; } = string.Empty;
        public int TotalPolicies { get; set; }
        public int ActivePolicies { get; set; }
        public int PendingPolicies { get; set; }
        public decimal TotalPayments { get; set; }
        public int PendingPayments { get; set; }
        public List<Policy> RecentPolicies { get; set; } = new();
        public List<Payment> RecentPayments { get; set; } = new();
    }
}
