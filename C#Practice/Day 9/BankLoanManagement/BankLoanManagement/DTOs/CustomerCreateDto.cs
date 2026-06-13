namespace BankLoanManagement.API.DTOs.Customer
{
    public class CustomerCreateDto
    {
        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string MobileNumber { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string PANNumber { get; set; } = string.Empty;

        public decimal AnnualIncome { get; set; }
    }
}