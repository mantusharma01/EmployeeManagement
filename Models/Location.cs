using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public partial class Location
    {
        public int LocationId { get; set; }
        public string LocationData { get; set; } = null!;
    }
}
