class ScholarshipStudent : Student
{
    private const double RatePerCredit = 500;
    private const double DiscountPercent = 50; // 50% discount

    public ScholarshipStudent(int id, string name, string department) : base(id, name, department) { }

    public override double CalculateFee(int totalCredits)
    {
        double baseFee = totalCredits * RatePerCredit;
        return baseFee - (baseFee * DiscountPercent / 100);
    }
}