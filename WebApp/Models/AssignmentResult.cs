using System.Collections.Generic;

namespace Domain.Models
{
    /// <summary>
    /// Represents an asingment to call request
    /// </summary>
    public class AssignmentResult
    {
        /// <summary>
        /// Area of requested call
        /// </summary>
        public string Area { get; set; }
        /// <summary>
        /// Employee of requested area
        /// </summary>
        public string Employee { get; set; }

        public AssignmentResult(string area, string employeeName)
        {
            Area = area;
            Employee = employeeName;
        }
    }
}
