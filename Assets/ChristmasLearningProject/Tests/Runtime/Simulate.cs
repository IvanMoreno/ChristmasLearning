using System.Collections;
using ChristmasLearningProject.Runtime.Domain;
using ChristmasLearningProject.Runtime.View;
using NUnit.Framework;
using static ChristmasLearningProject.Tests.Runtime.Do;
using static ChristmasLearningProject.Tests.Runtime.MouseOperations;
using static UnityEngine.Object;

namespace ChristmasLearningProject.Tests.Runtime
{
    public static class Simulate
    {
        public static IEnumerator DeployCristalBoat(Route route)
        {
            Assert.IsNull(FindObjectOfType<LevelEditor>());

            yield return ClickOn<CristalBoatSelectionButton>();
            yield return ClickInWorld(route.Departure);
            yield return ClickInWorld(route.Destination);
        }

        public static IEnumerator DeployShieldBoat(Route route)
        {
            Assert.IsNull(FindObjectOfType<LevelEditor>());

            yield return ClickOn<ShieldBoatSelectionButton>();
            yield return ClickInWorld(route.Departure);
            yield return ClickInWorld(route.Destination);
        }
    }
}