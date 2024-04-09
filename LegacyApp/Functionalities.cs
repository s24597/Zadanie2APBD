using System;

namespace LegacyApp;

public class Functionalities
{
    public static int Calculate_Age(DateTime birthday)
    {
        var now = DateTime.Now;
        var age = now.Year - birthday.Year;
        if (now.Month < birthday.Month || (now.Month == birthday.Month && now.Day < birthday.Day)) return age--;
        return age;
    }

    public static User Create_User(Client client,DateTime dateOfBirth,string email,string firstName,string lastName)
    {
        return new User()
        {
            Client = client,
            DateOfBirth = dateOfBirth,
            EmailAddress = email,
            FirstName = firstName,
            LastName = lastName
        };
    }

    public static int Credit_Limitation(IUserCreditService service,User user,bool Is_Important)
    {
        using (var userCreditService = service)
        {
            if (Is_Important)
            {
              return userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth) * 2;
            }
            
            return userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
        }
    }
    
}