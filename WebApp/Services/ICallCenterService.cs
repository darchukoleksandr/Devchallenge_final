using System.Collections.Generic;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface ICallCenterService
    {
        void Register(Employee employeeToRegister);
        AssignmentResult[] Call(string[] areas);
        void Reset();
    }
}
