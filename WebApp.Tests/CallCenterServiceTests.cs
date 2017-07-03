using System;
using System.Collections.Generic;
using Domain.Models;
using Microsoft.Extensions.Logging;
using WebApp.Services;
using Xunit;

namespace WebApp.Tests
{
    public class CallCenterServiceTests
    {
        /// <summary>
        /// Test if employee can register succesfully.
        /// </summary>
        [Fact]
        public void EmployeeCanBeRegistered()
        {
            var ccService = new CallCenterService(new LoggerStub<CallCenterService> ());
            var employee1 = new Employee
            {
                Name = "Employee1",
                Areas = new List<string> { "Area1", "Area2" }
            };
            ccService.Register(employee1);
            Assert.Equal(ccService.AvailableEmployees[0], employee1);
        }
        /// <summary>
        /// Test if employee areas are overwritten instead of adding new one.
        /// </summary>
        [Fact]
        public void EmployeeAreasAreOwerwritten()
        {
            var ccService = new CallCenterService(new LoggerStub<CallCenterService>());
            var employee1 = new Employee
            {
                Name = "Employee1",
                Areas = new List<string> { "Area1", "Area2" }
            };
            var employee2 = new Employee
            {
                Name = "Employee1",
                Areas = new List<string> { "Area3", "Area4" }
            };
            ccService.Register(employee1);
            ccService.Register(employee2);
            Assert.Equal(ccService.AvailableEmployees.Count, 1);
        }
        /// <summary>
        /// Test if employees are cleared on Reset() invoke.
        /// </summary>
        [Fact]
        public void EmployeeReset()
        {
            var ccService = new CallCenterService(new LoggerStub<CallCenterService>());
            var employee1 = new Employee
            {
                Name = "Employee1",
                Areas = new List<string> { "Area1", "Area2" }
            };
            ccService.Register(employee1);
            ccService.Reset();
            Assert.Equal(ccService.AvailableEmployees.Count, 0);
        }
        /// <summary>
        /// Test if service supports queue.
        /// </summary>
        [Fact]
        public void QueueSupportTest()
        {
            var ccService = new CallCenterService(new LoggerStub<CallCenterService>());
            var employee1 = new Employee
            {
                Name = "Employee1",
                Areas = new List<string> { "Area3", "Area4" }
            };
            var employee2 = new Employee
            {
                Name = "Employee2",
                Areas = new List<string> { "Area2", "Area4" }
            };
            var employee3 = new Employee
            {
                Name = "Employee3",
                Areas = new List<string> { "Area1", "Area4" }
            };

            ccService.Register(employee3);
            ccService.Register(employee1);
            ccService.Register(employee2);

            var asignments = ccService.Call(new []{ "Area1", "Area4", "Area3" });

            Assert.Equal(employee3.Name, asignments[0].Employee);
            Assert.Equal(employee1.Name, asignments[1].Employee);
            Assert.Equal(string.Empty, asignments[2].Employee);
        }
    }

    public class LoggerStub<CallCenterService> : ILogger, ILogger<CallCenterService>
    {
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {

        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }
    }
}
