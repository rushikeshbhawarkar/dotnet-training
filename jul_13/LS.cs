// L - Liskob Substitution Principle
// a deriver class should be able to replace its base class 
// without changing programs correctness
// class ki changes aaise karo ki vo parent ki originiality ko tode na .....
// ofcourse class can perform its own function but 
// it should not voilate parent class function or function which it inherited from parent

class Bird
{
    public void Fly()
    {
        Console.WriteLine("Flying");
    }
}
// class Penguin : Bird
// {
//     //public override void Fly()
//     {
//         throw new Exception("Can't Fly");
//     }
// }