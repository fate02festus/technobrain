using System;
using System.Collections;
using System.Runtime.Serialization;

namespace EmployeeHierarchy.CustomException
{
    /// <summary>
    /// Thrown when salary is negative or not a number
    /// </summary>
    class SalaryInvalid : Exception
    {
        public SalaryInvalid(string message) : base(message)
        {
        }
    }
}
