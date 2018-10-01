using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment3.Controllers
{
    public class EmployeeAdd
    {
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string Title { get; set; }

        public int? ReportsTo { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? HireDate { get; set; }

        [StringLength(70)]
        public string Address { get; set; }

        [StringLength(40)]
        public string City { get; set; }

        [StringLength(40)]
        public string State { get; set; }

        [StringLength(40)]
        public string Country { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        [StringLength(24)]
        public string Fax { get; set; }

        [StringLength(60)]
        public string Email { get; set; }
    }
    public class EmployeeBase : EmployeeAdd
    {
        public int EmployeeId { get; set; }
    }
   
    public class EmployeeWithAssociations : EmployeeBase
    {
        public EmployeeWithAssociations()
        {
            Employee1 = new List<EmployeeBase>();
            Customers = new List<CustomerBase>();
        }

        public string Employee2FirstName { get; set; }

        public string Employee2LastName { get; set; }

        public IEnumerable<EmployeeBase> Employee1 { get; set; }

        public IEnumerable<CustomerBase> Customers { get; set; }
    }
    public class EmployeeWithAssociations2 : EmployeeBase
    {
        public EmployeeWithAssociations2()
        {
            EmployeeSupervised = new List<EmployeeBase>();
            Customers = new List<CustomerBase>();
        }

        public string SupervisorFirstName { get; set; }

        public string SupervisorLastName { get; set; }

        public IEnumerable<EmployeeBase> EmployeeSupervised { get; set; }

        public IEnumerable<CustomerBase> Customers { get; set; }
    }

    public class EmployeeSupervisor
    {
        public int Employee { get; set; }

        public int Supervisor { get; set; }
    }

    public class SupervisorEmployees
    {
        public SupervisorEmployees()
        {
            Employees = new List<int>();
        }

        public int Supervisor { get; set; }

        public List<int> Employees { get; set; }
    }
}