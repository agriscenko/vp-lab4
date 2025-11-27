using Lab2.DataAccess.Interfaces;

namespace Lab2.DataAccess.Services;

public class DepartmentRepositoryService : IDepartmentRepository
{
    private readonly DepartmentDbContext _db;

    public DepartmentRepositoryService(DepartmentDbContext db)
    {
        _db = db;
        _db.Database.EnsureCreated();
    }

    public IEnumerable<Department> GetAll()
    {
        return _db.Departments.ToList();
    }

    public int Add(Department department)
    {
        _db.Departments.Add(department);
        _db.SaveChanges();

        return department.Id;
    }

    public Department GetById(int departmentId)
    {
        var department = _db.Departments.FirstOrDefault(d => d.Id == departmentId);

        if (department == null)
        {
            throw new ArgumentException("Department not found.");
        }

        return department;
    }

    public Department Update(Department department)
    {
        var existingDepartment = _db.Departments.FirstOrDefault(d => d.Id == department.Id);

        if (existingDepartment == null)
        {
            throw new ArgumentException("Department not found.");
        }

        existingDepartment.Name = department.Name;
        existingDepartment.Code = department.Code;
        existingDepartment.FloorNumber = department.FloorNumber;
        existingDepartment.PhoneNumber = department.PhoneNumber;
        existingDepartment.Email = department.Email;
        existingDepartment.IsHiring = department.IsHiring;
        existingDepartment.LastAuditDateTime = department.LastAuditDateTime;
        existingDepartment.Description = department.Description;

        _db.SaveChanges();

        return existingDepartment;
    }

    public void Delete(int departmentId)
    {
        var existingDepartment = _db.Departments.FirstOrDefault(d => d.Id == departmentId);

        if (existingDepartment == null)
        {
            throw new ArgumentException("Department not found.");
        }

        _db.Departments.Remove(existingDepartment);
        _db.SaveChanges();
    }

    public IEnumerable<Employee> GetEmployees(int departmentId)
    {
        var employees = _db.Employees.Where(e => e.DepartmentId == departmentId);

        if (!employees.Any())
        {
            throw new ArgumentException("Department not found.");
        }

        return employees.ToArray();
    }

    public Employee GetEmployeeById(int employeeId)
    {
        var employee = _db.Employees.FirstOrDefault(e => e.Id == employeeId);

        if (employee == null)
        {
            throw new ArgumentException("Employee not found.");
        }

        return employee;
    }

    public int AddEmployee(Employee employee)
    {
        _db.Employees.Add(employee);
        _db.SaveChanges();

        return employee.Id;
    }

    public Employee UpdateEmployee(Employee employee)
    {
        var existingEmployee = _db.Employees.FirstOrDefault(e => e.Id == employee.Id);

        if (existingEmployee == null)
        {
            throw new ArgumentException("Employee not found.");
        }

        existingEmployee.FirstName = employee.FirstName;
        existingEmployee.LastName = employee.LastName;
        existingEmployee.DateOfBirth = employee.DateOfBirth;
        existingEmployee.PhoneNumber = employee.PhoneNumber;
        existingEmployee.Email = employee.Email;
        existingEmployee.Position = employee.Position;
        existingEmployee.HireDate = employee.HireDate;
        existingEmployee.Salary = employee.Salary;
        existingEmployee.PerformanceScore = employee.PerformanceScore;
        existingEmployee.IsOnLeave = employee.IsOnLeave;
        existingEmployee.DepartmentId = employee.DepartmentId;

        _db.SaveChanges();

        return existingEmployee;
    }

    public void DeleteEmployee(int employeeId)
    {
        var existingEmployee = _db.Employees.FirstOrDefault(e => e.Id == employeeId);

        if (existingEmployee == null)
        {
            throw new ArgumentException("Employee not found.");
        }

        _db.Employees.Remove(existingEmployee);
        _db.SaveChanges();
    }


    public LeaveRequest GetLeaveRequestById(int leaveRequestId)
    {
        var leaveRequest = _db.LeaveRequests.FirstOrDefault(lr => lr.Id == leaveRequestId);

        if (leaveRequest == null)
        {
            throw new ArgumentException("Leave request not found.");
        }

        return leaveRequest;
    }

    public int AddLeaveRequest(LeaveRequest leaveRequest)
    {
        _db.LeaveRequests.Add(leaveRequest);
        _db.SaveChanges();

        return leaveRequest.Id;
    }

    public LeaveRequest UpdateLeaveRequest(LeaveRequest leaveRequest)
    {
        var existingLeaveRequest = _db.LeaveRequests.FirstOrDefault(lr => lr.Id == leaveRequest.Id);

        if (existingLeaveRequest == null)
        {
            throw new ArgumentException("Leave request not found.");
        }

        existingLeaveRequest.Type = leaveRequest.Type;
        existingLeaveRequest.StartDateTime = leaveRequest.StartDateTime;
        existingLeaveRequest.EndDateTime = leaveRequest.EndDateTime;
        existingLeaveRequest.RequestDateTime = leaveRequest.RequestDateTime;
        existingLeaveRequest.Comments = leaveRequest.Comments;
        existingLeaveRequest.ApprovedById = leaveRequest.ApprovedById;
        existingLeaveRequest.ApprovalDateTime = leaveRequest.ApprovalDateTime;
        existingLeaveRequest.ApprovalComments = leaveRequest.ApprovalComments;
        existingLeaveRequest.EmployeeId = leaveRequest.EmployeeId;

        _db.SaveChanges();

        return existingLeaveRequest;
    }

    public void DeleteLeaveRequest(int leaveRequestId)
    {
        var existingLeaveRequest = _db.LeaveRequests.FirstOrDefault(lr => lr.Id == leaveRequestId);

        if (existingLeaveRequest == null)
        {
            throw new ArgumentException("Leave request not found.");
        }

        _db.LeaveRequests.Remove(existingLeaveRequest);
        _db.SaveChanges();
    }
}
