using System.Collections;
using ChristmasLearningProject.Runtime.View;
using NUnit.Framework;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
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
    }
}