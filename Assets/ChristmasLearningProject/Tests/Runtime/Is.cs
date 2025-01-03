using ChristmasLearningProject.Runtime.View;
using UnityEngine;

namespace ChristmasLearningProject.Tests.Runtime
{
    public static class Is
    {
        public static bool GameOver() => Object.FindObjectOfType<GameOverScreen>() != null;
    }
}