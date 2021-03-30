using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRM.ERP.Data.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Department { get; set; }
        [Required] [EmailAddress] public string Email { get; set; }
        [Required] [Phone] public string Phone { get; set; }
        public bool IsManager { get; set; }
        public string Manager { get; set; }
    }
}
