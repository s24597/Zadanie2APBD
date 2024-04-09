using System;

namespace LegacyApp
{
    public class UserService
    {
        public IClientRepository Repo = new ClientRepository();
        public IUserCreditService Service = new UserCreditService();
        
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (
                Validation.Check_Name_And_Surname(firstName, lastName) && 
                Validation.Check_Mail(email) &&
                Validation.Check_Age(Functionalities.Calculate_Age(dateOfBirth))
                )
            {
                return false;
            }

            var user = Functionalities.Create_User(Repo.GetById(clientId),dateOfBirth,email,firstName,lastName);

            switch (user.Client.GetType().ToString())
            {
                case "VeryImportantClient":
                    user.HasCreditLimit = false;
                    break;
                case "ImportantClient":
                    user.CreditLimit = Functionalities.Credit_Limitation(Service,user,true);
                    break;
                default:
                    user.HasCreditLimit = true;
                    user.CreditLimit = Functionalities.Credit_Limitation(Service,user,false);
                    break;
            }
            
            if (Validation.Check_Credit_Limit(user))
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }
    }
}
