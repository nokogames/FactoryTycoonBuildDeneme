using _Main.Project.Scripts.Game;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Main.Project.Scripts
{
    public class GamePlayController : LifetimeScope
    {
        [SerializeField] private TouchManager touchManager;
        [SerializeField] private HapticFeedback hapticFeedback;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(touchManager);
            builder.RegisterComponent(hapticFeedback);
        }
    }
}
