using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repository;

namespace LibraryManagementSystem.Repositories
{
    public class TransactionRepository
    {
        //  ISSUE BOOK
        public void IssueBook(Transaction transaction)
        {
            using SqlConnection connection = DbConnection.GetConnection();

            string query = @"
                    INSERT INTO Transactions
                    (BookID, MemberID, IssueDate, DueDate, Status)
                    VALUES
                    (@BookID, @MemberID, @IssueDate, @DueDate, @Status)";

            using SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.Add("@BookID", SqlDbType.Int).Value = transaction.BookID;
            cmd.Parameters.Add("@MemberID", SqlDbType.Int).Value = transaction.MemberID;
            cmd.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = transaction.IssueDate;
            cmd.Parameters.Add("@DueDate", SqlDbType.DateTime).Value = transaction.DueDate;
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = transaction.Status;

            connection.Open();
            cmd.ExecuteNonQuery();
        }

        //  RETURN BOOK
        public void ReturnBook(int transactionId, DateTime returnDate)
        {
            using SqlConnection connection = DbConnection.GetConnection();

            string query = @"
                UPDATE Transactions
                SET ReturnDate = @ReturnDate,
                    Status = 'Returned'
                WHERE TransactionID = @TransactionID";

            using SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.Add("@TransactionID", SqlDbType.Int).Value = transactionId;
            cmd.Parameters.Add("@ReturnDate", SqlDbType.DateTime).Value = returnDate;

            connection.Open();
            cmd.ExecuteNonQuery();
        }

        // 🔹 GET ALL
        public List<Transaction> GetAllTransactions()
        {
            List<Transaction> list = new List<Transaction>();

            using SqlConnection connection = DbConnection.GetConnection();

            string query = "SELECT * FROM Transactions";

            SqlCommand cmd = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Transaction
                {
                    TransactionID = Convert.ToInt32(reader["TransactionID"]),
                    BookID = Convert.ToInt32(reader["BookID"]),
                    MemberID = Convert.ToInt32(reader["MemberID"]),
                    IssueDate = Convert.ToDateTime(reader["IssueDate"]),
                    ReturnDate = reader["ReturnDate"] == DBNull.Value
                        ? null
                        : Convert.ToDateTime(reader["ReturnDate"]),
                    Status = reader["Status"].ToString()
                });
            }

            return list;
        }

        // 🔹 DELETE
        public void DeleteTransaction(int transactionId)
        {
            using SqlConnection connection = DbConnection.GetConnection();

            string query = "DELETE FROM Transactions WHERE TransactionID = @TransactionID";

            using SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.Add("@TransactionID", SqlDbType.Int).Value = transactionId;

            connection.Open();
            cmd.ExecuteNonQuery();
        }
    }
}