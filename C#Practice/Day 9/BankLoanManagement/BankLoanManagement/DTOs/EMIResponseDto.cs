namespace BankLoanManagement.API.DTOs.EMI
{
    public class EMIResponseDto
    {
        public int EMIId { get; set; }

        public int LoanId { get; set; }

        public int InstallmentNumber { get; set; }

        public DateTime DueDate { get; set; }

        public decimal EMIAmount { get; set; }

        public DateTime? PaidDate { get; set; }

        public string PaymentStatus { get; set; } = string.Empty;
    }
}