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

    public static bool Check_Age(int age)
    {
        return age < 21;
    }

    public static bool Check_Credit_Limit(User user)
    {
        return user.HasCreditLimit && user.CreditLimit < 500;
    }
    
}