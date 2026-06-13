using System.ComponentModel.DataAnnotations;

namespace BankLoanManagement.API.Models
{

    public class LoanApplication
    {
        [Key]
        public int ApplicationId { get; set; }

        public int CustomerId { get; set; }

        public int LoanTypeId { get; set; }

        public decimal RequestedAmount { get; set; }

        public int TenureMonths { get; set; }

        public string Purpose { get; set; } = string.Empty;

        public DateTime ApplicationDate { get; set; }

        public string Status { get; set; } = "Pending";

        // Many Applications -> One Customer
        public Customer Customer { get; set; } = null!;

        // Many Applications -> One LoanType
        public LoanType LoanType { get; set; } = null!;

        // One Application -> One Loan
        public Loan? Loan { get; set; }
    }
}