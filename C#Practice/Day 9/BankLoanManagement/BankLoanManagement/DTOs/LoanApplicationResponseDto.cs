namespace BankLoanManagement.API.DTOs.LoanApplication
{
    public class LoanApplicationResponseDto
    {
        public int ApplicationId { get; set; }

        public int CustomerId { get; set; }

        public int LoanTypeId { get; set; }

        public decimal RequestedAmount { get; set; }

        public int TenureMonths { get; set; }

        public string Purpose { get; set; } = string.Empty;

        public DateTime ApplicationDate { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}