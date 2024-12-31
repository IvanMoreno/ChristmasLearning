using ChristmasLearningProject.Runtime.Domain;
using NUnit.Framework;
using NUnit.Framework.Internal;
using UnityEngine;

public class BoatTests
{
    [Test]
    public void MoveBoatTowardsDestination()
    {
        var sut = Boat.Cristal();
        sut.SetRoute(Vector2.zero, Vector2.one);
        
        sut.Move(1);
        
        Assert.Greater(sut.Position.x, Vector2.zero.x);
        Assert.Greater(sut.Position.y, Vector2.zero.y);
    }

    [Test]
    public void MoveBoatTowardsNegativeDirection()
    {
        var sut = Boat.Cristal();
        sut.SetRoute(Vector2.zero, Vector2.one * -1);
        
        sut.Move(1);
        
        Assert.Less(sut.Position.x, Vector2.zero.x);
        Assert.Less(sut.Position.y, Vector2.zero.y);
    }

    [Test]
    public void StopAfterReachingDestination()
    {
        var sut = Boat.Cristal();
        sut.SetRoute(Vector2.zero, Vector2.one);
        
        sut.Move(10);
        
        Assert.AreEqual(Vector2.one, sut.Position);
    }

    [Test]
    public void MoveEvenly()
    {
        var sut = Boat.Cristal();
        sut.SetRoute(Vector2.zero, Vector2.one);
        
        sut.Move(0.01f);
        var firstStepDistance = sut.Position;
        sut.Move(0.01f);
        var secondStepDistance = sut.Position;
        
        Assert.AreEqual(firstStepDistance - Vector2.zero, secondStepDistance - firstStepDistance);
    }
}
