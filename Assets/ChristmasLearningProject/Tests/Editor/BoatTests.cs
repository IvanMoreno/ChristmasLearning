using ChristmasLearningProject.Runtime.Domain;
using NUnit.Framework;
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
}
