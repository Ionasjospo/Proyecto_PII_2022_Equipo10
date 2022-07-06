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
        User lucho = new User("Luis Suarez","03");
        lucho.NewMatch(false);
        bool verifier = false;
        foreach (Match match in MatchList.Instance.HistoricMatches)
        {
            if (match.PlayerA1.User.Name == lucho.Name)
            {
                verifier = true;
            }

        }
        Assert.IsTrue(verifier);
    }


    [Test]
    public void CreateNewMatch2vs2()
    {
        User edi = new User("Edi Cavani","04");
        edi.NewMatch(true);


        bool verifier = false;
        foreach (Match match in MatchList.Instance.HistoricMatches)
        {
            if (match.PlayerA1.User.Name == edi.Name)
            {
                verifier = true;
            }
        }
        Assert.IsTrue(verifier);
        
    }
}