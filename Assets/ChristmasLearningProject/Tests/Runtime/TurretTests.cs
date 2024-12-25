using System.Collections;
using ChristmasLearningProject.Runtime.View;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using static ChristmasLearningProject.Tests.Runtime.Do;
using static ChristmasLearningProject.Tests.Runtime.LevelBuilder;
using static ChristmasLearningProject.Tests.Runtime.MouseOperations;
using static UnityEngine.Object;

namespace ChristmasLearningProject.Tests.Runtime
{
    public class TurretTests
    {
        [UnityTest]
        public IEnumerator Hide_GameOverScreen_OnStart()
        {
            yield return FromLevelEditor().Build();
            
            Assert.IsNull(FindObjectOfType<GameOverScreen>());
        }

        [UnityTest]
        public IEnumerator WhenTurretKills_CristalBoat_GameOver()
        {
            yield return FromLevelEditor().WithTurretAt(Vector2.one).Build();

            yield return DeployCristalBoat(Vector2.one * 2, Vector2.one);

            Assert.IsNotNull(FindObjectOfType<GameOverScreen>());
        }

        [UnityTest]
        public IEnumerator ShieldBoat_BlocksTurretAttack_WhenInFrontOfCristalBoat()
        {
            yield return FromLevelEditor().WithShieldBoatEnabled().WithTurretAt(Vector2.one).Build();

            yield return DeployShieldBoat(Vector2.one * 2, Vector2.one);
            yield return DeployCristalBoat(Vector2.one * 3, Vector2.one * 2);

            Assert.IsNull(FindObjectOfType<GameOverScreen>());
        }

        static IEnumerator DeployCristalBoat(Vector2 departure, Vector2 destination)
        {
            Assert.IsNull(FindObjectOfType<LevelEditor>());

            yield return ClickOn<CristalBoatSelectionButton>();
            yield return ClickInWorld(departure);
            yield return ClickInWorld(destination);
        }

        static IEnumerator DeployShieldBoat(Vector2 departure, Vector2 destination)
        {
            Assert.IsNull(FindObjectOfType<LevelEditor>());

            yield return ClickOn<ShieldBoatSelectionButton>();
            yield return ClickInWorld(departure);
            yield return ClickInWorld(destination);
        }
    }
}