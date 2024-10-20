using UnityEngine;
using System.Runtime.InteropServices;
public class HapticFeedback : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void TriggerVibration(int duration);

    public void Vibrate(int duration)
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        TriggerVibration(duration);
#endif
    }
}