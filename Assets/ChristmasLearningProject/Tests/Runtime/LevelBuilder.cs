using System.Collections;
using ChristmasLearningProject.Runtime.View;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ChristmasLearningProject.Tests.Runtime
{
    public record LevelBuilder
    {
        Vector2? turretPosition;
        bool withShieldBoat;

        public LevelBuilder WithTurretAt(Vector2 position)
        {
            turretPosition = position;
            return this;
        }

        public LevelBuilder WithShieldBoatEnabled()
        {
            withShieldBoat = true;
            return this;
        }

        public IEnumerator Build()
        {
            yield return SceneManager.LoadSceneAsync("LevelEditor");
            
            if (turretPosition != null)
                yield return PlaceTurretAt(turretPosition.Value);
            
            if (withShieldBoat)
                yield return Do.ClickOn<EnableShieldBoatButton>();
            
            yield return Do.ClickOn<ConfirmLevelEditionButton>();
        }

        static IEnumerator PlaceTurretAt(Vector2 worldPoint)
        {
            Assert.IsNotNull(Object.FindObjectOfType<LevelEditor>());

            return MouseOperations.ClickInWorld(worldPoint);
        }

        public static LevelBuilder FromLevelEditor() => new();
    }
}