namespace LegacyApp;

public class Validation
{
    public static bool Check_Name_And_Surname(string firstName, string lastName)
    {
        return string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName);
    }
    
    public static bool Check_Mail(string email)
    {
        return !email.Contains("@") && !email.Contains(".");
    }
    
}