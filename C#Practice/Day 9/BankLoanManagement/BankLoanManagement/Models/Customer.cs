using System.Collections.Generic;

namespace BankLoanManagement.API.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string MobileNumber { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string PANNumber { get; set; } = string.Empty;

        public decimal AnnualIncome { get; set; }

        // One Customer -> Many Loan Applications
        public ICollection<LoanApplication> LoanApplications { get; set; }
            = new List<LoanApplication>();
    }
}