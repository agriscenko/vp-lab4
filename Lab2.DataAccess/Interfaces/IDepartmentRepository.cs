namespace Lab2.DataAccess.Interfaces;

public interface IDepartmentRepository
{
    // Department

    IEnumerable<Department> GetAll();

    Department GetById(int departmentId);

    IEnumerable<Department> GetByName(string departmentName);

    IEnumerable<Department> GetByFloorNumber(int floorNumber);

    IEnumerable<Department> GetByIsHiring(bool isHiring);

    int Add(Department department);

    Department Update(Department department);

    void Delete(int departmentId);

    IEnumerable<Employee> GetEmployees(int departmentId);

    // Employee

    IEnumerable<Employee> GetAllEmployees();

    Employee GetEmployeeById(int employeeId);

    IEnumerable<Employee> GetEmployeesByFirstName(string employeeFirstName);

    int AddEmployee(Employee employee);

    Employee UpdateEmployee(Employee employee);

    void DeleteEmployee(int employeeId);

    IEnumerable<LeaveRequest> GetEmployeeLeaveRequests(int employeeId);

    // Leave request

    IEnumerable<LeaveRequest> GetAllLeaveRequests();

    LeaveRequest GetLeaveRequestById(int leaveRequestId);

    IEnumerable<LeaveRequest> GetLeaveRequestsByType(string leaveRequestType);

    int AddLeaveRequest(LeaveRequest leaveRequest);

    LeaveRequest UpdateLeaveRequest(LeaveRequest leaveRequest);

    void DeleteLeaveRequest(int leaveRequestId);
}
