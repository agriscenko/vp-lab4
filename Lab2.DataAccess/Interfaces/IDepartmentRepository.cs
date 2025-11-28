namespace Lab2.DataAccess.Interfaces;

public interface IDepartmentRepository
{
    // Department

    IEnumerable<Department> GetAll();

    Department GetById(int departmentId);

    int Add(Department department);

    Department Update(Department department);

    void Delete(int departmentId);

    IEnumerable<Employee> GetEmployees(int departmentId);

    // Employee

    Employee GetEmployeeById(int employeeId);

    int AddEmployee(Employee employee);

    Employee UpdateEmployee(Employee employee);

    void DeleteEmployee(int employeeId);

    IEnumerable<LeaveRequest> GetEmployeeLeaveRequests(int employeeId);

    // Leave request

    LeaveRequest GetLeaveRequestById(int leaveRequestId);

    int AddLeaveRequest(LeaveRequest leaveRequest);

    LeaveRequest UpdateLeaveRequest(LeaveRequest leaveRequest);

    void DeleteLeaveRequest(int leaveRequestId);
}
