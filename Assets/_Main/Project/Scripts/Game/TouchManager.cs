using System.Collections;
using _Main.Project.Scripts.ObjectPooling;
using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;
using static _Main.Project.Scripts.Utilities.Events;

namespace _Main.Project.Scripts.Game
{
    public class TouchManager : MonoBehaviour
    {
        [Inject] private HapticFeedback _hapticFeedback;
        
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;
            
            // TODO: Update for different devices
            if (Input.touchCount > 0)
            {
                foreach (var touch in Input.touches)
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        NotifyTouch();
                    }
                }
            }
            else if (Input.GetMouseButtonDown(0))
            {
                NotifyTouch();
            }
        }

        private void NotifyTouch()
        {
            OnTouch?.Invoke();
            //HapticManager.PlayHaptic(HapticType.Selection);
            //HapticManager.TriggerVibration(0.1f);
            //HapticFeedback.TriggerHaptic();
            _hapticFeedback.Vibrate(100);
            
            StartCoroutine(CreateWaterUI());
        }

        private IEnumerator CreateWaterUI()
        {
            var pos = Input.mousePosition;
            pos.z = 4f;
            var water = ObjectPooler.Instance.SpawnFromPool("WaterUI");
            water.transform.position = _camera.ScreenToWorldPoint(pos);
            water.transform.rotation = Quaternion.identity;
            
            yield return new WaitForSeconds(2f);
            
            ObjectPooler.Instance.ReturnToPool("WaterUI", water);
        }

        private void DisableWaterUI()
        {
            
        }
    }
}