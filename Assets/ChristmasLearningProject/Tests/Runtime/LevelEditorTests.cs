using System.Collections;
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
        [UnityTest]
        public IEnumerator ShieldBoat_IsNotAvailable_ByDefault()
        {
            yield return SceneManager.LoadSceneAsync("LevelEditor");
            yield return ClickOn<ConfirmLevelEditionButton>();

            Assert.IsNull(Object.FindObjectOfType<ShieldBoatSelectionButton>());
        }

        [UnityTest]
        public IEnumerator EnableShieldBoatSelection_DuringLevelEdition()
        {
            yield return SceneManager.LoadSceneAsync("LevelEditor");

            yield return ClickOn<EnableShieldBoatButton>();
            yield return ClickOn<ConfirmLevelEditionButton>();
            
            Assert.IsNotNull(Object.FindObjectOfType<ShieldBoatSelectionButton>());
        }

        [UnityTest]
        public IEnumerator DeploymentIsNotPossible_DuringLevelEdition()
        {
            yield return SceneManager.LoadSceneAsync("LevelEditor");

            yield return ClickInWorld(Vector2.down);
            yield return ClickInWorld(Vector2.one);
            
            Assert.IsNull(Object.FindObjectOfType<CristalBoat>());
        }

        [UnityTest]
        public IEnumerator HideLevelEditorButtons_DuringPlaymode()
        {
            yield return SceneManager.LoadSceneAsync("LevelEditor");
            
            yield return ClickOn<ConfirmLevelEditionButton>();
            
            Assert.IsNull(Object.FindObjectOfType<EnableShieldBoatButton>());
        }
    }
}