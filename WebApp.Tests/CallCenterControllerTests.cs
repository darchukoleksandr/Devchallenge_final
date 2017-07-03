using System;
using Microsoft.AspNetCore.Mvc;
using WebApp.Controllers;
using WebApp.Services;
using Xunit;

namespace WebApp.Tests
{
    public class CallCenterControllerTests
    {
        /// <summary>
        /// Test if employee can register succesfully.
        /// </summary>
        [Fact]
        public void EmployeeCanBeRegistered()
        {
            var ccService = new CallCenterService(new LoggerStub<CallCenterService> ());
            var ccController = new CallCenterController(ccService);
            
            ccController.Register("Employee1", new []{ "Area1", "Area2" });
            Assert.Equal(ccService.AvailableEmployees.Count, 1);
        }
    }
}
