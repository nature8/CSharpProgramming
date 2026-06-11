using System;

namespace LibraryManagementSystem.Models
{
    public class Member
    {
        public int MemberID { get; set; }

        public string MemberName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
    }
}