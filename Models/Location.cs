using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public partial class Location
    {
        public Location()
        {
            Employees = new HashSet<Employee>();
        }

        public int LocationId { get; set; }
        public string LocationData { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
