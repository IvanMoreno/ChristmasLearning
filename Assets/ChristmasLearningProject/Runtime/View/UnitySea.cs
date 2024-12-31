using UnityEngine;

namespace ChristmasLearningProject.Runtime.View
{
    public class UnitySea : Sea
    {
        public void Refresh()
        {
            Object.FindObjectOfType<CristalBoat>()?.Refresh();
            Object.FindObjectOfType<ShieldBoat>()?.Refresh();
        }
    }
}