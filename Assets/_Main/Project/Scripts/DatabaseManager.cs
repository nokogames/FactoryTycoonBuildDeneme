using _Main.Project.Scripts.Template.GameDataEditor.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Main.Project.Scripts
{
    public class DatabaseManager : MonoBehaviour
    {
        [SerializeField] private GameData gameData;
    
        private void Start()
        {
            LoadUserDataAndLoadScene();
        }

        private void LoadUserDataAndLoadScene()
        {
            LoadUserData();
        
            SceneManager.LoadScene("GamePlay");
        }

        private void LoadUserData()
        {
            if (!PlayerPrefs.HasKey("GameData"))
            {
                SaveUserData();
            }
            
            var dataString = PlayerPrefs.GetString("GameData");
            var gameRuntimeData = JsonUtility.FromJson<GameRuntimeData>(dataString);
            gameData.CopyFrom(gameRuntimeData);
        }

        public void SaveUserData()
        {
            PlayerPrefs.SetString("GameData", JsonUtility.ToJson(gameData));
        }
    }
}