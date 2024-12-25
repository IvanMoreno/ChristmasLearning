using System.Collections;
using ChristmasLearningProject.Runtime.View;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using static ChristmasLearningProject.Tests.Runtime.Do;
using static ChristmasLearningProject.Tests.Runtime.MouseOperations;
using static UnityEngine.Object;

namespace ChristmasLearningProject.Tests.Runtime
{
    public class TurretTests
    {
        [UnitySetUp]
        public IEnumerator SetUp()
        {
            yield return SceneManager.LoadSceneAsync("LevelEditor");
        }

        [Test]
        public void Hide_GameOverScreen_OnStart()
        {
            Assert.IsNull(FindObjectOfType<GameOverScreen>());
        }

        [UnityTest]
        public IEnumerator WhenTurretKills_CristalBoat_GameOver()
        {
            yield return PlaceTurretAt(Vector2.one);
            yield return ClickOn<ConfirmLevelEditionButton>();

            yield return DeployCristalBoat(Vector2.one * 2, Vector2.one);
            
            Assert.IsNotNull(FindObjectOfType<GameOverScreen>());
        }
        
        [UnityTest]
        public IEnumerator ShieldBoat_BlocksTurretAttack_WhenInFrontOfCristalBoat()
        {
            yield return PlaceTurretAt(Vector2.one);
            yield return ClickOn<EnableShieldBoatButton>();
            yield return ClickOn<ConfirmLevelEditionButton>();

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

        static IEnumerator PlaceTurretAt(Vector2 worldPoint)
        {
            Assert.IsNotNull(FindObjectOfType<LevelEditor>());
            
            return ClickInWorld(worldPoint);
        }
    }
}