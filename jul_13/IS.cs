//I ---> Interface Segeration Principle
// client should not be forced to methods they do not require
// OR client should not be forced to depend upon interfaces that they do not use
//in simple everyday term keep your interface small, specific and focused
//

interface Basics
{
    void work ();
    void walk ();
    void eat();
}
interface Basics_2
{
    void eatbyhuman();
}

class Human : Basics,Basics_2
{
    public void work()
    {
        
    }
    public void walk()
    {
        
    }
    public void eat()
    {
        
    }
    public void eatbyhuman()
    {
        
    }
}

class Robot : Basics
{
    public void work()
    {
        
    }
    public void walk()
    {
        
    }
    public void eat()
    {
        
    }
    //// here robot cannot eat so you cannot force the robot to eat 
    /// hence the interface segregation principle is voilated
    /// solution to it is create a seperate interface name eat and assign it to human only
    /// and remove eat from basics_1
}