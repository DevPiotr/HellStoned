using System;
using UnityEngine;
using HellStoned.State;
using HellStoned.UI;

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
        private Rigidbody playerRigidbody;
        public Rigidbody PlayerRigidbody { get { return this.playerRigidbody; } }

        private IState<GameController> currentState;
        private int currentLevel = 0;
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
            var state = new MenuState();         
            ChangeState(state);
        }

        public void StartGameState ()
        {
            var state = new GameState();
            currentMap = Instantiate(levels[currentLevel]);
            currentLevel++;
            playerRigidbody.useGravity = true;           
            Time.timeScale = 1f;

            ChangeState(state);
        }

        public void StartPauseState ()
        {
            var state = new PauseState();
            ChangeState(state);
        }
        public void ResumeGameState()
        {
            throw new NotImplementedException();
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
