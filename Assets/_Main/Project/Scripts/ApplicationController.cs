using _Main.Project.Scripts.Template.GameDataEditor.Scripts;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Main.Project.Scripts
{
    public class ApplicationController : LifetimeScope
    {
        //[SerializeField] private LoaderMediator loaderMediatorPrefab;
        [SerializeField] private GameData gameData;
        [SerializeField] private DatabaseManager databaseManager;

        // private LoaderMediator _loaderMediator;
        //private SceneLoader _sceneLoader;

        protected override void Awake()
        {
            gameData.Load();
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }

        protected override void Configure(IContainerBuilder builder)
        {
            //builder.RegisterComponentInNewPrefab(loaderMediatorPrefab, Lifetime.Scoped).DontDestroyOnLoad();

            //builder.Register<SceneLoader>(Lifetime.Singleton);
            builder.RegisterInstance(gameData);
            builder.RegisterInstance(databaseManager);
        }

        private void Start()
        {
            //  _loaderMediator = Container.Resolve<LoaderMediator>();
            //_sceneLoader = Container.Resolve<SceneLoader>();
            //_sceneLoader.LoadLevel("Level" + (gameData.currentLevelIndex + 1));
            
            Application.targetFrameRate = 60;
#if !UNITY_EDITOR
            Debug.unityLogger.logEnabled=false;
#endif
        }
    }
}