using BankLoanManagement.API.DTOs.LoanApplication;
using BankLoanManagement.API.Models;
using BankLoanManagement.API.Repositories.Interfaces;
using BankLoanManagement.API.Services.Interfaces;

namespace BankLoanManagement.API.Services.Implementations
{
    public class LoanApplicationService : ILoanApplicationService
    {
        private readonly ILoanApplicationRepository _applicationRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ILoanTypeRepository _loanTypeRepository;
        private readonly ILoanRepository _loanRepository;
        private readonly IEMIService _emiService;

        public LoanApplicationService(
            ILoanApplicationRepository applicationRepository,
            ICustomerRepository customerRepository,
            ILoanTypeRepository loanTypeRepository,
            ILoanRepository loanRepository,
            IEMIService emiService)
        {
            _applicationRepository = applicationRepository;
            _customerRepository = customerRepository;
            _loanTypeRepository = loanTypeRepository;
            _loanRepository = loanRepository;
            _emiService = emiService;
        }

        private decimal CalculateEMI(
            decimal principal,
            decimal annualInterestRate,
            int tenureMonths)
        {
            double p = (double)principal;
            double r = (double)annualInterestRate / 12 / 100;
            double n = tenureMonths;

            double emi =
                p * r * Math.Pow(1 + r, n) /
                (Math.Pow(1 + r, n) - 1);

            return (decimal)Math.Round(emi, 2);
        }

        public async Task<IEnumerable<LoanApplicationResponseDto>> GetAllApplicationsAsync()
        {
            var applications = await _applicationRepository.GetAllAsync();

            return applications.Select(a => new LoanApplicationResponseDto
            {
                ApplicationId = a.ApplicationId,
                CustomerId = a.CustomerId,
                LoanTypeId = a.LoanTypeId,
                RequestedAmount = a.RequestedAmount,
                TenureMonths = a.TenureMonths,
                Purpose = a.Purpose,
                ApplicationDate = a.ApplicationDate,
                Status = a.Status
            });
        }

        public async Task<LoanApplicationResponseDto?> GetApplicationByIdAsync(int id)
        {
            var application = await _applicationRepository.GetByIdAsync(id);

            if (application == null)
                return null;

            return new LoanApplicationResponseDto
            {
                ApplicationId = application.ApplicationId,
                CustomerId = application.CustomerId,
                LoanTypeId = application.LoanTypeId,
                RequestedAmount = application.RequestedAmount,
                TenureMonths = application.TenureMonths,
                Purpose = application.Purpose,
                ApplicationDate = application.ApplicationDate,
                Status = application.Status
            };
        }

        public async Task<LoanApplicationResponseDto> CreateApplicationAsync(
            LoanApplicationCreateDto dto)
        {
            var customer =
                await _customerRepository.GetByIdAsync(dto.CustomerId);

            if (customer == null)
                throw new Exception("Customer not found.");

            var loanType =
                await _loanTypeRepository.GetByIdAsync(dto.LoanTypeId);

            if (loanType == null)
                throw new Exception("Loan type not found.");

            var application = new LoanApplication
            {
                CustomerId = dto.CustomerId,
                LoanTypeId = dto.LoanTypeId,
                RequestedAmount = dto.RequestedAmount,
                TenureMonths = dto.TenureMonths,
                Purpose = dto.Purpose,
                ApplicationDate = DateTime.Now,
                Status = "Pending"
            };

            await _applicationRepository.AddAsync(application);

            return new LoanApplicationResponseDto
            {
                ApplicationId = application.ApplicationId,
                CustomerId = application.CustomerId,
                LoanTypeId = application.LoanTypeId,
                RequestedAmount = application.RequestedAmount,
                TenureMonths = application.TenureMonths,
                Purpose = application.Purpose,
                ApplicationDate = application.ApplicationDate,
                Status = application.Status
            };
        }

        public async Task<bool> UpdateApplicationAsync(
            int id,
            LoanApplicationCreateDto dto)
        {
            var application =
                await _applicationRepository.GetByIdAsync(id);

            if (application == null)
                return false;

            application.CustomerId = dto.CustomerId;
            application.LoanTypeId = dto.LoanTypeId;
            application.RequestedAmount = dto.RequestedAmount;
            application.TenureMonths = dto.TenureMonths;
            application.Purpose = dto.Purpose;

            await _applicationRepository.UpdateAsync(application);

            return true;
        }

        public async Task<bool> DeleteApplicationAsync(int id)
        {
            var application =
                await _applicationRepository.GetByIdAsync(id);

            if (application == null)
                return false;

            await _applicationRepository.DeleteAsync(application);

            return true;
        }

        public async Task<bool> ApproveLoanAsync(int applicationId)
        {
            var application =
                await _applicationRepository
                .GetApplicationWithDetailsAsync(applicationId);

            if (application == null)
                return false;

            // Rule 4
            if (application.Status == "Approved")
                throw new Exception("Loan already approved.");

            // Rule 5
            if (application.Status == "Rejected")
                throw new Exception("Rejected loan cannot be approved.");

            // Rule 1
            if (application.Customer.AnnualIncome <= 300000)
                throw new Exception(
                    "Customer income below minimum requirement.");

            // Rule 2
            if (application.RequestedAmount >
                application.LoanType.MaxLoanAmount)
                throw new Exception(
                    "Loan amount exceeds limit.");

            // Rule 3
            if (application.TenureMonths >
                application.LoanType.MaxTenureMonths)
                throw new Exception(
                    "Tenure exceeds maximum limit.");

            application.Status = "Approved";

            await _applicationRepository.UpdateAsync(application);

            decimal emi = CalculateEMI(
                application.RequestedAmount,
                application.LoanType.InterestRate,
                application.TenureMonths);

            decimal totalPayment =
                emi * application.TenureMonths;

            decimal totalInterest =
                totalPayment - application.RequestedAmount;

            var loan = new Loan
            {
                ApplicationId = application.ApplicationId,
                ApprovedAmount = application.RequestedAmount,
                InterestRate = application.LoanType.InterestRate,
                TenureMonths = application.TenureMonths,
                EMIAmount = emi,
                TotalInterest = totalInterest,
                TotalPayment = totalPayment,
                ApprovedDate = DateTime.Now
            };

            loan = await _loanRepository.AddAsync(loan);

            await _emiService.GenerateEMIScheduleAsync(
                loan.LoanId,
                loan.EMIAmount,
                loan.TenureMonths);

            return true;
        }

        public async Task<bool> RejectLoanAsync(int applicationId)
        {
            var application =
                await _applicationRepository.GetByIdAsync(applicationId);

            if (application == null)
                return false;

            if (application.Status == "Approved")
                throw new Exception(
                    "Approved loan cannot be rejected.");

            application.Status = "Rejected";

            await _applicationRepository.UpdateAsync(application);

            return true;
        }
    }
}