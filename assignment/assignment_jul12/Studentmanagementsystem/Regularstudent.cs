
class RegularStudent : Student
{
    private const double RatePerCredit = 500;

    public RegularStudent(int id, string name, string department) : base(id, name, department) { }

    public override double CalculateFee(int totalCredits)
    {
        return totalCredits * RatePerCredit;
    }
}