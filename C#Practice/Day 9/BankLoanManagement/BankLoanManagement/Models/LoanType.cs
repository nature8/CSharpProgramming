namespace BankLoanManagement.API.Models
{

    public class LoanType
    {
        public int LoanTypeId { get; set; }

        public string LoanName { get; set; } = string.Empty;

        public decimal InterestRate { get; set; }

        public decimal MaxLoanAmount { get; set; }

        public int MaxTenureMonths { get; set; }

        // 1 LoanType -> Many Applications
        public ICollection<LoanApplication> LoanApplications { get; set; }
            = new List<LoanApplication>();
    }
}