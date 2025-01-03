using System.Collections;
using ChristmasLearningProject.Runtime.View;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using static ChristmasLearningProject.Runtime.Domain.Route;
using static ChristmasLearningProject.Tests.Runtime.LevelBuilder;
using static ChristmasLearningProject.Tests.Runtime.Simulate;
using static UnityEngine.Object;
using static UnityEngine.Vector2;

namespace ChristmasLearningProject.Tests.Runtime
{
    public class TurretTests
    {
        [UnityTest]
        public IEnumerator Hide_GameOverScreen_OnStart()
        {
            yield return FromLevelEditor().Build();
            
            Assert.False(Is.GameOver());
        }

        [UnityTest]
        public IEnumerator WhenTurretKills_CristalBoat_GameOver()
        {
            yield return FromLevelEditor().WithTurretAt(one).Build();

            yield return DeployCristalBoat(Between(one * 2, one));

            Assert.True(Is.GameOver());
        }

        [UnityTest]
        public IEnumerator ShieldBoat_BlocksTurretAttack_WhenInFrontOfCristalBoat()
        {
            yield return FromLevelEditor().WithShieldBoatEnabled().WithTurretAt(one).Build();

            yield return DeployShieldBoat(Between(one * 2, one));
            yield return DeployCristalBoat(Between(one * 3, one * 2));

            Assert.False(Is.GameOver());
        }

        [UnityTest]
        public IEnumerator TurretShoots_NearestBoat()
        {
            yield return FromLevelEditor().WithShieldBoatEnabled().WithTurretAt(one).Build();

            yield return DeployShieldBoat(Between(one * 5, one * 2));
            yield return DeployCristalBoat(Between(one * 2, one));

            Assert.True(Is.GameOver());
        }

        [UnityTest]
        public IEnumerator Ignore_FarAwayBoats()
        {
            yield return FromLevelEditor().WithTurretAt(one).Build();

            yield return DeployCristalBoat(Between(one * 5, one * down * 5));
            
            Assert.False(Is.GameOver());
        }

        [UnityTest]
        public IEnumerator FaceAway_FromTheIsland()
        {
            yield return FromLevelEditor().WithTurretAt(right).Build();
            
            Assert.IsTrue(Distance(right, FindObjectOfType<Turret>().transform.up) <= .05f);
        }
    }
}