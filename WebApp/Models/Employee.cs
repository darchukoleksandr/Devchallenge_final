using System.Collections.Generic;

namespace Domain.Models
{
    /// <summary>
    /// Represents the employee model
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Name of the employee
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Areas of the employee
        /// </summary>
        public List<string> Areas { get; set; }
    }
}
