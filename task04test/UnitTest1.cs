using Xunit;
using Moq;

public class SpaceshipTests
{
    [Fact]
    public void Cruiser_ShouldHaveCorrectStats()
    {
        ISpaceship cruiser = new Cruiser();
        Assert.Equal(50, cruiser.Speed);
        Assert.Equal(100, cruiser.FirePower);
    }

    [Fact]
    public void Fighter_ShouldHaveCorrectStats()
    {
        ISpaceship cruiser = new Fighter();
        Assert.Equal(100, cruiser.Speed);
        Assert.Equal(50, cruiser.FirePower);
    }

    [Fact]
    public void Fighter_ShouldBeFasterThanCruiser()
    {
        var fighter = new Fighter();
        var cruiser = new Cruiser();
        Assert.True(fighter.Speed > cruiser.Speed);
    }

    [Fact]
    public void Fighter_ShouldBeWeakerThanCruiser()
    {
        var fighter = new Fighter();
        var cruiser = new Cruiser();
        Assert.True(fighter.FirePower < cruiser.FirePower);
    }

    [Fact]
    public void Ships_ShouldExecuteMoveForwardWithoutErrors()
    {
        ISpaceship fighter = new Fighter();
        ISpaceship cruiser = new Cruiser();

        fighter.MoveForward();
        cruiser.MoveForward();

        Assert.True(true);
    }

    [Fact]
    public void Ships_ShouldExecuteRotateWithoutErrors()
    {
        ISpaceship fighter = new Fighter();
        ISpaceship cruiser = new Cruiser();

        fighter.Rotate(20);
        cruiser.Rotate(20);

        Assert.True(true);
    }

    [Fact]
    public void Ships_ShouldExecuteFireWithoutErrors()
    {
        ISpaceship fighter = new Fighter();
        ISpaceship cruiser = new Cruiser();

        fighter.Fire();
        cruiser.Fire();

        Assert.True(true);
    }
}
