using System.Collections;
using ChristmasLearningProject.Runtime.View;
using NUnit.Framework;
using UnityEngine;
using static ChristmasLearningProject.Tests.Runtime.Do;
using static ChristmasLearningProject.Tests.Runtime.MouseOperations;
using static UnityEngine.Object;

namespace ChristmasLearningProject.Tests.Runtime
{
    public static class Simulate
    {
        public static IEnumerator DeployCristalBoat(Vector2 departure, Vector2 destination)
        {
            Assert.IsNull(FindObjectOfType<LevelEditor>());

            yield return ClickOn<CristalBoatSelectionButton>();
            yield return ClickInWorld(departure);
            yield return ClickInWorld(destination);
        }

        public static IEnumerator DeployShieldBoat(Vector2 departure, Vector2 destination)
        {
            Assert.IsNull(FindObjectOfType<LevelEditor>());

            yield return ClickOn<ShieldBoatSelectionButton>();
            yield return ClickInWorld(departure);
            yield return ClickInWorld(destination);
        }
    }
}