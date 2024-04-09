using LegacyApp;

namespace Tests;

public class Tests
{
    
    [Test]
    public void enforce_first_validation_error()
    {
        var test = new UserService();
        var result1 = test.AddUser(null, "Doe", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);
        Console.WriteLine(result1);
        var result2 = test.AddUser("John", "Doe", "johndoe&gmail.com", DateTime.Parse("1982-03-21"), 1);
        Console.WriteLine(result2);
        var result3 = test.AddUser("John", "Doe", "johndoe@gmail.com", DateTime.Parse("2024-03-21"), 1);
        Console.WriteLine(result3);
        Assert.That((result1 && result2 && result3), Is.EqualTo(false));
    }
    
    [Test]
    public void go_through_the_program()
    {
        // W tej części powinna być klasa mock do testu, ale ze względu na to, że samo połączenie jest już symulowane to nie zmieniam parametrów
        
        var test = new UserService();
        var result = test.AddUser("John", "Doe", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);
        Assert.That(result, Is.EqualTo(true));
    }
    
    [Test]
    public void behave_like_a_important_client()
    {
        var test = new UserService();
        var result = test.AddUser("John", "Smith", "smith@gmail.pl", DateTime.Parse("1999-04-11"), 3);
        Assert.That(result, Is.EqualTo(true));
    }
    
    [Test]
    public void behave_like_a_very_important_client()
    {
        var test = new UserService();
        var result = test.AddUser("Krzysztof", "Malewski", "malewski@gmail.pl", DateTime.Parse("1970-05-10"), 2);
        Assert.That(result, Is.EqualTo(true));
    }
    
    [Test]
    public void wrong_client_id()
    {
        var test = new UserService();
        try
        {
            test.AddUser("Krzysztof", "Malewski", "malewski@gmail.pl", DateTime.Parse("1970-05-10"), 420);
        }
        catch (Exception e)
        {
            Assert.Pass();
        }
    }
    
    [Test]
    public void wrong_client_name()
    {
        var test = new UserService();
        try
        {
            test.AddUser("Krzysztof", "XpomyłkaX", "malewski@gmail.pl", DateTime.Parse("1970-05-10"), 1);
        }
        catch (Exception e)
        {
            Assert.Pass();
        }
    }

    [Test]
    public void credit_limit_exceeded()
    {
        var test = new UserService();
        var result = test.AddUser("Janusz", "Kowalski", "kowalski@wp.pl", DateTime.Parse("1949-09-02"), 1);
        Assert.That(result, Is.EqualTo(false));
    }
    
}