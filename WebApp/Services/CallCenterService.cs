using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.Extensions.Logging;

namespace WebApp.Services
{
    public class CallCenterService : ICallCenterService
    {
        private readonly ILogger _logger;
        public List<Employee> AvailableEmployees { get; } = new List<Employee>();

        public CallCenterService(ILogger<CallCenterService> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Registers new employee.
        /// </summary>
        /// <param name="employeeToRegister"></param>
        public void Register(Employee employeeToRegister)
        {
            var existedEmployee = AvailableEmployees.FirstOrDefault(employee => 
                employee.Name.Equals(employeeToRegister.Name,
                StringComparison.OrdinalIgnoreCase));

            if (existedEmployee == null)
            {
                AvailableEmployees.Add(employeeToRegister);
                _logger.LogInformation("Registered new employee.", employeeToRegister);
                return;
            }

            existedEmployee.Areas = employeeToRegister.Areas;
            _logger.LogInformation("Registered new areas for employee.", employeeToRegister.Areas);
        }
        /// <summary>
        /// Assigns employees with required areas.
        /// </summary>
        /// <param name="areas">Required areas.</param>
        /// <returns></returns>
        public AssignmentResult[] Call(string[] areas)
        {
            var result = new AssignmentResult[areas.Length];

            for (var i = 0; i < areas.Length; i++)
            {
                var neededEmployee = AvailableEmployees.FirstOrDefault(employee => employee.Areas.Contains(areas[i]));
                var employeeName = neededEmployee?.Name ?? string.Empty;
                result[i] = new AssignmentResult(areas[i], employeeName);
                AvailableEmployees.Remove(neededEmployee);
            }

            _logger.LogInformation("Asigned employees.", result);
            return result;
        }
        /// <summary>
        /// Releases all registered employees by clearing the AvailableEmployees list.
        /// </summary>
        public void Reset()
        {
            _logger.LogInformation("Employees reseted.");
            AvailableEmployees.Clear();
        }
    }
}
