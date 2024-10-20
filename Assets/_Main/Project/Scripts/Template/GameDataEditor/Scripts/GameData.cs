using UnityEngine;

namespace _Main.Project.Scripts.Template.GameDataEditor.Scripts
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameData", order = 1)]
    public class GameData : ScriptableObject
    {
        public int score;
        
        public void Save() => SaveManager.SaveData(this);
        public void Load() => SaveManager.LoadData(this);
        
        public void CopyFrom(GameRuntimeData data)
        {
            score = data.score;
        }
    }

    public class GameRuntimeData
    {
        public int score;
    }
}