using System;
using System.Collections.Generic;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;

namespace LibraryManagementSystem.Services
{
    public class TransactionService
    {
        private readonly TransactionRepository _transactionRepository;

        public TransactionService()
        {
            _transactionRepository = new TransactionRepository();
        }

        // 🔹 ISSUE BOOK
        public void IssueBook(Transaction transaction)
        {
            if (transaction.BookID <= 0 || transaction.MemberID <= 0)
                throw new Exception("Invalid Book or Member ID.");

            transaction.IssueDate = DateTime.Now;

            // Due after 14 days
            transaction.DueDate = DateTime.Now.AddDays(14);

            transaction.Status = "Issued";

            _transactionRepository.IssueBook(transaction);

            Console.WriteLine("Book Issued Successfully.");
        }

        // 🔹 RETURN BOOK
        public void ReturnBook(int transactionId)
        {
            if (transactionId <= 0)
                throw new Exception("Invalid Transaction ID.");

            _transactionRepository.ReturnBook(transactionId, DateTime.Now);

            Console.WriteLine("Book Returned Successfully.");
        }

        // 🔹 VIEW ALL
        public List<Transaction> GetAllTransactions()
        {
            return _transactionRepository.GetAllTransactions();
        }

        // 🔹 DELETE
        public void DeleteTransaction(int transactionId)
        {
            if (transactionId <= 0)
                throw new Exception("Invalid Transaction ID.");

            _transactionRepository.DeleteTransaction(transactionId);

            Console.WriteLine("Transaction Deleted Successfully.");
        }
    }
}