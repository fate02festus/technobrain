using System;
using System.IO;
using EmployeeHierarchy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeHierarchyTests
{

    [TestClass()]
    public class HierarchyTests
    {

        private Hierarchy _hierarchy;

        [TestInitialize]
        public void TestInitiliaze()
        {
            var data = GetData("test1.csv");
            _hierarchy = new Hierarchy(data);
        }

        /// <summary>
        /// Tests if the Employees are added to the graph
        /// </summary>
        [TestMethod()]
        public void AddTest()
        {

            Assert.IsTrue(_hierarchy.LstEmployees.Contains(new Employees
                {Id = "Employee2", ManagerId = "Employee1", Salary = 800}));
            Assert.IsTrue(_hierarchy.LstEmployees.Contains(new Employees
                {Id = "Employee4", ManagerId = "Employee2", Salary = 500}));
        }
        /// <summary>
        /// Tests if Employee have subordinates added
        /// Example is using Employee2 who has two subordinates
        /// </summary>
        [TestMethod]
        public void SubOrdinate_Not_NULL()
        {
            var subordinates = _hierarchy.GetSubordinates("Employee2");
            Assert.AreEqual(2, subordinates.Count);
        }

        /// <summary>
        /// As per the test data employee 5 has no subordinates
        /// </summary>
        [TestMethod]
        public void Employee5_has_No_SubOrdinates_Test()
        {
            var subordinates = _hierarchy.GetSubordinates("Employee5");
            Assert.AreEqual(0, subordinates.Count);
        }

        /// <summary>
        /// Tests if the Lookup function returns a Employee given a valid Employee ID
        /// </summary>
        [TestMethod]
        public void LookUpTest()
        {
            Employees emp = _hierarchy.LookUp("Employee1");
            Assert.IsNotNull(emp);
        }

        /// <summary>
        /// Tests if lookup returns null on non existence id
        /// </summary>
        [TestMethod]
        public void Lookup_Wrong_emp_id_Test()
        {
            Employees emp = _hierarchy.LookUp("Employee10");
            Assert.IsNull(emp);
        }

        string[] GetData(String path)
        {

            return File.ReadAllLines(path);
        }

        /// <summary>
        /// Tests if the correct budget is added  
        /// </summary>
        [TestMethod]
        public void GetBudgetTest()
        {
            Assert.AreEqual(1800, _hierarchy.getSalaryBudget("Employee2"));
            Assert.AreEqual(500, _hierarchy.getSalaryBudget("Employee3"));
            Assert.AreEqual(3800, _hierarchy.getSalaryBudget("Employee1"));
        }

        /// <summary>
        /// Using test2.csv which contains employee with non number salary and negative salary
        /// Invalid Salary Employees are not added and the Graph is empty fails to pass this check
        /// </summary>
        [TestMethod]
        public void Test_Invalid_Salary_Not_Added()
        {
            Hierarchy h2 = new Hierarchy(GetData("test2.csv"));
            Assert.IsFalse(h2.LstEmployees.Contains(new Employees
                { Id = "Employee5" }));
            Assert.IsFalse(h2.LstEmployees.Contains(new Employees
                { Id = "Employee2" }));

            Assert.AreEqual(0,h2.LstEmployees.Count);

        }
        /// <summary>
        /// Test3.csv contains two manager. The Graph should be Empty since manager should be one
        /// </summary>
        [TestMethod]
        public void Test_Manager_More_Than_Three()
        {
            Hierarchy h = new Hierarchy(GetData("test3.csv"));
            Assert.IsFalse(h.LstEmployees.Contains(new Employees
                { Id = "Employee5" }));
            Assert.IsFalse(h.LstEmployees.Contains(new Employees
                { Id = "Employee1" }));
            Assert.AreEqual(0, h.LstEmployees.Count);

        }
        /// <summary>
        /// Test4.csv contains one employee with negative salary. 
        /// </summary>
        [TestMethod]
        public void Test_Negative_Salary_Check()
        {
            Hierarchy h = new Hierarchy(GetData("test4.csv"));
            Assert.IsFalse(h.LstEmployees.Contains(new Employees
                { Id = "Employee5" }));
            Assert.AreEqual(0, h.LstEmployees.Count);
        }

        /// <summary>
        /// There is no manager that is not an employee, i.e. all managers are also listed in the employee column.
        /// test5.csv contain no manager record
        /// </summary>
        [TestMethod]
        public void No_Manager_Record()
        {
            Hierarchy h = new Hierarchy(GetData("test5.csv"));
            Assert.AreEqual(0,h.LstEmployees.Count);
        }

    }
}