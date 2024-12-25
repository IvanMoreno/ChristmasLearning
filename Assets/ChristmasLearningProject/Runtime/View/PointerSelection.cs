using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// https://discussions.unity.com/t/how-to-detect-if-mouse-is-over-ui/821330/6
namespace ChristmasLearningProject.Runtime.View
{
    public static class PointerSelection
    {
        public static bool IsOverAnyUI()
        {
            return IsOverUI(GetEventSystemRaycastResults(), string.Empty);
        }

        public static bool IsOver(string specificLayer)
        {
            return IsOverUI(GetEventSystemRaycastResults(), specificLayer);
        }

        static bool IsOverUI(List<RaycastResult> eventSystemRaysastResults, string layer)
        {
            for (int index = 0; index < eventSystemRaysastResults.Count; index++)
            {
                RaycastResult curRaysastResult = eventSystemRaysastResults[index];
                if (string.IsNullOrEmpty(layer) || curRaysastResult.gameObject.layer == LayerMask.NameToLayer(layer))
                    return true;
            }

            return false;
        }
        
        static List<RaycastResult> GetEventSystemRaycastResults()
        {
            PointerEventData eventData = new PointerEventData(EventSystem.current);
            eventData.position = Input.mousePosition;
            List<RaycastResult> raysastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, raysastResults);
            return raysastResults;
        }
    }
}