namespace LeaveManagement
{
    public class PermanentEmployee : Employee
    {
        public PermanentEmployee(int id, string _name, string _department, double _leavebalance)
        {
            EmployeeId = id;
            Name = _name;
            Department = _department;
            LeaveBalance = _leavebalance; 
        }

        public override void SetLeaveBalance()
        {
            LeaveBalance = 24; 
        }
    }
}