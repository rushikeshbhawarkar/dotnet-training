class PartTimeStudent : Student
{
    private const double RatePerCredit = 350;

    public PartTimeStudent(int id, string name, string department) : base(id, name, department) { }

    public override double CalculateFee(int totalCredits)
    {
        return totalCredits * RatePerCredit;
    }
}