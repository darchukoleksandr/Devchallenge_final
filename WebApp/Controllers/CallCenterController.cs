using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    /// <summary>
    /// Main controller.
    /// </summary>
    [Route("/")]
    public class CallCenterController : Controller
    {
        private readonly ICallCenterService _callCenterService;
        /// <summary>
        /// Constructor with injectable varibales.
        /// </summary>
        /// <param name="callCenterService">Call center service variable.</param>
        public CallCenterController(ICallCenterService callCenterService)
        {
            _callCenterService = callCenterService;
        }
        /// <summary>
        /// Registers new employee.
        /// </summary>
        /// <param name="name">Name of the employee.</param>
        /// <param name="area">Areas of the employee.</param>
        /// <returns>WELCOME</returns>
        [HttpGet("register")]
        public IActionResult Register([FromQuery]string name, [FromQuery]string[] area)
        {
            var employeeToRegister = new Employee
            {
                Areas = new List<string>(area),
                Name = name
            };
            _callCenterService.Register(employeeToRegister);
            return Ok("WELCOME");
        }
        /// <summary>
        /// Assigns employees with required areas.
        /// </summary>
        /// <param name="area">Required areas.</param>
        /// <returns>Asignments for required calls.</returns>
        [HttpGet("call")]
        public IActionResult Call([FromQuery]string[] area)
        {
            var assignments = _callCenterService.Call(area);
            var result = new
            {
                totalAssignment = assignments.Count(assignment => !assignment.Employee.Equals(string.Empty)),
                assignments = assignments
            };
            return Ok(result);
        }
        /// <summary>
        /// Releases all registered employees.
        /// </summary>
        /// <returns>200 status code</returns>
        [HttpGet("reset")]
        public IActionResult Reset()
        {
            _callCenterService.Reset();
            return Ok();
        }
    }
}
