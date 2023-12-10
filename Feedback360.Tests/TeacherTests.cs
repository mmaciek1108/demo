using feedback360;


namespace Feedback360.Tests;

public class Tests
{
    [Test]
    public void WhenStatisticsCalled_ShouldReturnMax()
    {

        //arrange
        var user = new Teacher("Klara", "Szybka");
        user.AddGrade(1);
        user.AddGrade(5);
        user.AddGrade(2);

        var statistics = user.GetStatistics();


        //act
        var min = statistics.Min;


        //assert
        Assert.AreEqual(1, min);
    }
    [Test]
    public void WhenStatisticsCalled_ShouldReturnMin()
    {
        //arrange
        var user = new Teacher("Klara", "Szybka");
        user.AddGrade(6);
        user.AddGrade(2);
        user.AddGrade(3);

        var statistics = user.GetStatistics();


        //act
        var max = statistics.Max;


        //assert
        Assert.AreEqual(6, max);
    }

    [Test]
    public void WhenStatisticsCalled_ShouldReturnAverege()
    {
        //arrange
        var user = new Teacher("Anna", "Wolna");
        user.AddGrade(3);
        user.AddGrade(2);
        user.AddGrade(1);

        var statistics = user.GetStatistics();


        //act
        var ave = statistics.Average;


        //assert
        Assert.AreEqual(2, ave);
    }

    [Test]
    public void WhenStatisticsCalled_ShouldReturnAveregeLetter()
    {
        //arrange
        var user = new Teacher("Klara", "Szybka");
        user.AddGrade(3);
        user.AddGrade(2);
        user.AddGrade(1);

        var statistics = user.GetStatistics();


        //act
        var ave = statistics.AverageLetter;


        //assert
        Assert.AreEqual('C', ave);
    }
}