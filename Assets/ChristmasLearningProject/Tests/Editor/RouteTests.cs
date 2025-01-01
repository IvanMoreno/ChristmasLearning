using ChristmasLearningProject.Runtime.Domain;
using NUnit.Framework;
using UnityEngine;

namespace ChristmasLearningProject.Tests.Editor
{
    public class RouteTests
    {
        [Test]
        public void ReachDeparture()
        {
            Assert.IsTrue(new Route(Vector2.zero, Vector2.one).ReachedDepartureAt(Vector2.zero));
            Assert.IsTrue(new Route(Vector2.zero, Vector2.one).ReachedDepartureAt(Vector2.one * -1));
            Assert.IsFalse(new Route(Vector2.zero, Vector2.one).ReachedDepartureAt(Vector2.one));
        }
        
        [Test]
        public void ReachDepartureGoingInANegativeDirection()
        {
            Assert.IsFalse(new Route(Vector2.one, Vector2.zero).ReachedDepartureAt(Vector2.zero));
        }
    }
}