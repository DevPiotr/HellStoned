using UnityEngine;
using HellStoned.Data;

namespace HellStoned.Core {
    public class DataStorage : MonoBehaviour {

        [SerializeField]
        private GlobalHighScores _globalHighScores;
        public GlobalHighScores _GlobalHighScores { get { return this._globalHighScores; } }

        /* czysczenie 
        private void Awake()
        {
            _globalHighScores.Scores.Clear();
        }
        */
        public void SaveData()
        {
            PlayerPrefs.SetString("HighScores", JsonUtility.ToJson(_globalHighScores));
        }

        public void SetScores(GlobalHighScores scores)
        {
            this._globalHighScores = scores;
        }

        public void CheckScore(int endGameScore)
        {
           
            switch (_globalHighScores.Scores.Count)
            {
                case 0:
                    {
                        _globalHighScores.Scores.Add(endGameScore);
                        break;
                    }
                case 1:
                    {
                        _globalHighScores.Scores.Add(endGameScore);
                        _globalHighScores.Scores.Sort();
                        _globalHighScores.Scores.Reverse();
                        break;
                    }
                case 2:
                    {
                        _globalHighScores.Scores.Add(endGameScore);
                        _globalHighScores.Scores.Sort();
                        _globalHighScores.Scores.Reverse();
                        break;
                    }
                case 3:
                    {
                        _globalHighScores.Scores.Add(endGameScore);
                        _globalHighScores.Scores.Sort();
                        _globalHighScores.Scores.Reverse();
                        _globalHighScores.Scores.RemoveAt(3);                   
                        break;
                    }
                default:
                    {
                        Debug.LogWarning("DataStorage:: Too much highscores in list");
                        break;
                    }
            }

            SaveData();
        }
    }
}
