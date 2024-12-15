using System.Collections;
using ChristmasLearningProject.Runtime.View;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using static ChristmasLearningProject.Tests.Runtime.MouseOperations;
using Vector3 = System.Numerics.Vector3;

namespace ChristmasLearningProject.Tests.Runtime
{
    public class GameplayTests
    {
        [UnityTest]
        public IEnumerator Hide_WinScreen_OnStart()
        {
            yield return SceneManager.LoadSceneAsync("Level_0");

            Assert.IsNull(Object.FindObjectOfType<WinScreen>());
        }

        [UnityTest]
        public IEnumerator CristalBoat_IsNotDeployed_OnStart()
        {
            yield return SceneManager.LoadSceneAsync("Level_0");

            Assert.IsNull(Object.FindObjectOfType<CristalBoat>());
        }
        
        [UnityTest]
        public IEnumerator DeployCristalBoat_ByDefiningItsRoute()
        {
            yield return SceneManager.LoadSceneAsync("Level_0");

            var departurePoint = Vector2.one;
            yield return ClickInWorld(departurePoint);
            var destinationPoint = Vector2.zero;
            yield return ClickInWorld(destinationPoint);

            Assert.IsNotNull(Object.FindObjectOfType<CristalBoat>());
        }
    }
}