namespace BankLoanManagement.API.Models
{
    public class Loan
    {
        public int LoanId { get; set; }

        public int ApplicationId { get; set; }

        public decimal ApprovedAmount { get; set; }

        public decimal InterestRate { get; set; }

        public int TenureMonths { get; set; }

        public decimal EMIAmount { get; set; }

        public decimal TotalInterest { get; set; }

        public decimal TotalPayment { get; set; }

        public DateTime ApprovedDate { get; set; }

        public LoanApplication LoanApplication { get; set; } = null!;

        public ICollection<LoanEMI> LoanEMIs { get; set; }
            = new List<LoanEMI>();
    }
}