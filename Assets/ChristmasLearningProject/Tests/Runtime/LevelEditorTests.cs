using System.Collections;
using System.Collections.Generic;
using ChristmasLearningProject.Runtime.View;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using static ChristmasLearningProject.Tests.Runtime.Do;
using static ChristmasLearningProject.Tests.Runtime.MouseOperations;

namespace ChristmasLearningProject.Tests.Runtime
{
    public class LevelEditorTests
    {
        [UnitySetUp]
        public IEnumerator SetUp()
        {
            yield return SceneManager.LoadSceneAsync("LevelEditor");
        }
        
        [UnityTest]
        public IEnumerator ShieldBoat_IsNotAvailable_ByDefault()
        {
            yield return StartGame();

            Assert.IsNull(Object.FindObjectOfType<ShieldBoatSelectionButton>());
        }

        [UnityTest]
        public IEnumerator EnableShieldBoatSelection_DuringLevelEdition()
        {
            yield return ClickOn<EnableShieldBoatButton>();
            yield return StartGame();
            
            Assert.IsNotNull(Object.FindObjectOfType<ShieldBoatSelectionButton>());
        }

        [UnityTest]
        public IEnumerator DeploymentIsNotPossible_DuringLevelEdition()
        {
            yield return ClickInWorld(Vector2.down);
            yield return ClickInWorld(Vector2.one);
            
            Assert.IsNull(Object.FindObjectOfType<CristalBoat>());
        }

        [UnityTest]
        public IEnumerator HideLevelEditorButtons_DuringPlaymode()
        {
            yield return StartGame();
            
            Assert.IsNull(Object.FindObjectOfType<EnableShieldBoatButton>());
        }

        [UnityTest]
        public IEnumerator ThereIs_NoTurret_ByDefault()
        {
            yield return StartGame();
            
            Assert.IsNull(Object.FindObjectOfType<Turret>());
        }

        [UnityTest]
        public IEnumerator PlaceTurret()
        {
            yield return ClickInWorld(Vector2.zero);
            
            Assert.IsNotNull(Object.FindObjectOfType<Turret>());
        }
        
        [UnityTest]
        public IEnumerator TurretPlacement_IsDisabled_InPlaymode()
        {
            yield return StartGame();

            yield return ClickInWorld(Vector2.zero);
            
            Assert.IsNull(Object.FindObjectOfType<Turret>());
        }

        static IEnumerator StartGame() => ClickOn<ConfirmLevelEditionButton>();
    }
}