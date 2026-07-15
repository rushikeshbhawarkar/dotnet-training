using System;
using System.ComponentModel;
public class UserAuth
{
    private string username = "admin";
    private string password ="admin123";
    
    public string Uname
    {
        get
        {
            return username;
        }
        set;
        
    }
    public string Passcode
    {
        get
        {
            return password;
        }
        set;
        
    }



}