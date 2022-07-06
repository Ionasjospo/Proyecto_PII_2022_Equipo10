using NUnit.Framework;

namespace Library.Test;

public class CreateNewMatchTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CreateNewMatch1vs1()
    {
        UserList.Instance.addNewUser("Luis Suarez", "91899");
        UserList.Instance.FindUserById("91899").NewMatch(false);
        
        bool verifier = false;
        foreach (Match match in MatchList.Instance.HistoricMatches)
        {
            if (match.PlayerA1.User.Name == UserList.Instance.FindUserById("91899").Name)
            {
                verifier = true;
            }
            
        }
        Assert.IsTrue(verifier);
    }

    [Test]
    public void CreateNewMatch2vs2()
    {
        UserList.Instance.addNewUser("Matador", "918");
        UserList.Instance.FindUserById("918").NewMatch(false);

        bool verifier = false;
        foreach (Match match in MatchList.Instance.HistoricMatches)
        {
            if (match.PlayerA1.User.Name == UserList.Instance.FindUserById("918").Name)
            {
                verifier = true;
            }
        }
        Assert.IsTrue(verifier);
        
    }

}