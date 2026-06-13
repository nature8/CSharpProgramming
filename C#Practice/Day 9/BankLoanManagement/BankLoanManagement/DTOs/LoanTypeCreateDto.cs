namespace BankLoanManagement.API.DTOs.LoanType
{
    public class LoanTypeCreateDto
    {
        public string LoanName { get; set; } = string.Empty;

        public decimal InterestRate { get; set; }

        public decimal MaxLoanAmount { get; set; }

        public int MaxTenureMonths { get; set; }
    }
}