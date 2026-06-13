using System.ComponentModel.DataAnnotations;

namespace BankLoanManagement.API.Models
{
    public class LoanEMI
    {
        [Key]
        public int EMIId { get; set; }

        public int LoanId { get; set; }

        public int InstallmentNumber { get; set; }

        public DateTime DueDate { get; set; }

        public decimal EMIAmount { get; set; }

        public DateTime? PaidDate { get; set; }

        public string PaymentStatus { get; set; } = "Pending";

        // Many EMI -> One Loan
        public Loan Loan { get; set; } = null!;
    }
}
