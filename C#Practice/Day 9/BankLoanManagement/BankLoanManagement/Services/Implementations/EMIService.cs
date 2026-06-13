using BankLoanManagement.API.Models;
using BankLoanManagement.API.Repositories.Interfaces;
using BankLoanManagement.API.Services.Interfaces;

namespace BankLoanManagement.API.Services.Implementations
{
    public class EMIService : IEMIService
    {
        private readonly IEMIRepository _emiRepository;

        public EMIService(IEMIRepository emiRepository)
        {
            _emiRepository = emiRepository;
        }

        public async Task<IEnumerable<LoanEMI>> GetAllEMIsAsync()
        {
            return await _emiRepository.GetAllAsync();
        }

        public async Task<LoanEMI?> GetEMIByIdAsync(int id)
        {
            return await _emiRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<LoanEMI>> GetEMIsByCustomerIdAsync(int customerId)
        {
            return await _emiRepository.GetByCustomerIdAsync(customerId);
        }

        public async Task GenerateEMIScheduleAsync(
            int loanId,
            decimal emiAmount,
            int tenureMonths)
        {
            var emiList = new List<LoanEMI>();

            DateTime firstDueDate = DateTime.Now.AddMonths(1);

            for (int i = 1; i <= tenureMonths; i++)
            {
                emiList.Add(new LoanEMI
                {
                    LoanId = loanId,
                    InstallmentNumber = i,
                    DueDate = firstDueDate.AddMonths(i - 1),
                    EMIAmount = emiAmount,
                    PaymentStatus = "Pending",
                    PaidDate = null
                });
            }

            await _emiRepository.AddRangeAsync(emiList);
        }

        public async Task<bool> PayEMIAsync(int emiId)
        {
            var emi = await _emiRepository.GetByIdAsync(emiId);

            if (emi == null)
                return false;

            if (emi.PaymentStatus == "Paid")
                throw new Exception("EMI already paid.");

            emi.PaymentStatus = "Paid";
            emi.PaidDate = DateTime.Now;

            await _emiRepository.UpdateAsync(emi);

            return true;
        }
    }
}