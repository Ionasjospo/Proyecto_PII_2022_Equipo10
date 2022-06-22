using NUnit.Framework;

namespace Library.Test;

public class CreateNewUser
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CreateNewUserTest()
    {
        UserList.Instance.addNewUser("Sergio");
        bool verifier = false;
        foreach (User user in UserList.Instance.Users)
        {
            if (user.Name == "Sergio")
            {
                verifier = true;
            }
        }

        Assert.IsTrue(verifier);
    }
}
    