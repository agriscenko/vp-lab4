namespace Lab2.DataAccess.Interfaces;

public interface IDepartmentRepository
{
    IEnumerable<Department> GetAll();

    int Add(Department department);

    Department GetById(int departmentId);

    Department Update(Department department);

    void Delete(int departmentId);

    IEnumerable<Employee> GetEmployees(int departmentId);

    Employee GetEmployeeById(int employeeId);

    int AddEmployee(Employee employee);

    Employee UpdateEmployee(Employee employee);

    void DeleteEmployee(int employeeId);

    LeaveRequest GetLeaveRequestById(int leaveRequestId);

    int AddLeaveRequest(LeaveRequest leaveRequest);

    LeaveRequest UpdateLeaveRequest(LeaveRequest leaveRequest);

    void DeleteLeaveRequest(int leaveRequestId);
}
