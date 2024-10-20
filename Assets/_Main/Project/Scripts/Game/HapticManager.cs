using UnityEngine;

namespace _Main.Project.Scripts
{
    public static class HapticManager
    {
        public static void TriggerVibration(float duration)
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            Application.ExternalCall("triggerVibration", duration);
#endif
        }
    }
}