//O ---> Open Close Principle
//Software should be Open for Extension but closed for Modification


class OCP
{
    public void Process(Payment p)
    {
        p.Pay();
    }
    static void Main()
    {
        OCP c = new OCP();
        c.Process(new CreditCard());
    }
}