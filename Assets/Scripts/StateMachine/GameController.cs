using HellStoned.Player;
using HellStoned.State;
using HellStoned.UI;
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

        public int currentLevel = 0;
        public int endGameScore;

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

        #region IGameController implementation
        public void StartMenuState ()
        {
            if(currentMap != null)
            {
                Destroy(currentMap);
                currentLevel = 0;
            }
            _playerController._Rigidbody.useGravity = false;
            var state = new MenuState();         
            ChangeState(state);
        }

        public void StartGameState ()
        {
            var state = new GameState();
            currentMap = Instantiate(levels[currentLevel]);
            
            _playerController._Rigidbody.useGravity = true;
            Time.timeScale = 1f;
            ChangeState(state);
        }


        public void QuitGame ()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        public void ChangeLevel()
        {

                currentLevel++;

                _playerController.transform.position = Vector3.forward;
                _playerController.isLevelChanging = true;

                _playerController._Rigidbody.useGravity = false;
                
                Destroy(currentMap);
                currentMap = Instantiate(levels[currentLevel]);
                _playerController._Rigidbody.useGravity = true;
           
        }

        public void WinAGame()
        {
            /*
            if (PlayerPrefs.HasKey("Score1"))
            {
            
            }
            else if(PlayerPrefs.HasKey("Score1") && PlayerPrefs.HasKey("Score2"))
            {
            }
            else if(PlayerPrefs.HasKey("Score1") && PlayerPrefs.HasKey("Score2") && PlayerPrefs.HasKey("Score3"))
            {

            }
            */
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
