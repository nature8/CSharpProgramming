using System.ComponentModel.DataAnnotations.Schema;

using System.ComponentModel.DataAnnotations;

namespace MyMvcApp.Models{
    [Table("tblEmployees")]

    public class EmployeeModel {

    //[Key]

        public int EmployeeModelId{get;set;}

        public string EName{get;set;} = string.Empty;
        public string Job{get;set;} = string.Empty;
        public int Salary{get;set;}    

    }   
}