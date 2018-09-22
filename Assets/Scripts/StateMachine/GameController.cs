using HellStoned.Player;
using HellStoned.State;
using HellStoned.UI;
using HellStoned.Data;

using UnityEngine;

namespace HellStoned.Core
{
    public class GameController : MonoBehaviour, IStateMachine<GameController>, IGameController
    {

        [SerializeField]
        private GameObject[] levels;
        public GameObject[] Levels { get { return this.levels; } }

        [SerializeField]
        private UIRootController _uiRootController;
        public UIRootController _UIRootController { get { return this._uiRootController; } }

        [SerializeField]
        private PlayerController _playerController;
        public PlayerController _PlayerController { get { return this._playerController; } }

        [SerializeField]
        private AudioStorageController _audioStorageController;
        public AudioStorageController _AudioStorageController { get { return this._audioStorageController; } }

        [SerializeField]
        private DataStorage _dataStorage;
        public DataStorage _DataStorage { get { return this._dataStorage; } }

        [HideInInspector]
        public int currentLevel = 0;
        [HideInInspector]
        public int endGameScore;
        [HideInInspector]
        public bool checkAndChangeHighScore = true;


        private IState<GameController> currentState;
        private GameObject currentMap;

        private void Start()
        {
            _uiRootController.listener = this;
            StartMenuState();
        }

        private void Update()
        {
            UpdateState();    
        }
        //
        private void Awake()
        {
            if (!PlayerPrefs.HasKey("HighScores"))
            {
                PlayerPrefs.SetString("HighScores", JsonUtility.ToJson(_dataStorage._GlobalHighScores));
            }
            else
            {
               _dataStorage.setScores(JsonUtility.FromJson<GlobalHighScores>(PlayerPrefs.GetString("HighScores")));       
            }
        }
        //
        #region IGameController implementation
        public void StartMenuState ()
        {
            if(currentMap != null)
            {
                Destroy(currentMap);
                currentLevel = 0;
            }
            _playerController.isLevelChanging = true;
            _playerController._Rigidbody.useGravity = false;
            _playerController.isPaused = true;

            var state = new MenuState();         
            ChangeState(state);
        }

        public void StartGameState ()
        {
            var state = new GameState();
            currentMap = Instantiate(levels[currentLevel]);

            _playerController.transform.position = new Vector3(0, 0, 0);
            _playerController._Rigidbody.useGravity = true;
            Time.timeScale = 1f;
            ChangeState(state);
        }


        public void QuitGame ()
        {
            _dataStorage.SaveData();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        public void ChangeLevel()
        {
                currentLevel++;

                _playerController.transform.position = new Vector3(0, 0, 0);
                _playerController.isLevelChanging = true;

                _playerController._Rigidbody.useGravity = false;
                
                Destroy(currentMap);
                currentMap = Instantiate(levels[currentLevel]);
                _playerController._Rigidbody.useGravity = true;
           
        }

        public void WinAGame()
        {

            _playerController._Rigidbody.useGravity = false;
            _playerController.isPaused = true;

            _dataStorage.CheckScore(endGameScore);
            currentLevel = 0;   
           
            StartMenuState();
        }

        #endregion

        #region IStateMachine implementation
        public void ChangeState(IState<GameController> newState)
        {
            if(currentState != null)
            {
                currentState.DeinitState(this);
            }

            currentState = newState;

            if(currentState != null)
            {
                currentState.InitState(this);
            }
        }
        
        public void UpdateState()
        {
            currentState.UpdateState(this);
        }


        #endregion


    }
}
