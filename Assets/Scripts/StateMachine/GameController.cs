using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Test.State;

namespace Test.Core{

    public class GameController : MonoBehaviour, IStateMachine<GameController>, IMenuListener {

        public IState<GameController> currentState;

        void Update(){
            UpdateState();
        }

        void Start(){
            StartMenuState();
            StartCoroutine(WaitForChange());
        }
              
        #region IStateMachine implementation

        public void ChangeState(IState<GameController> newState)
        {
            if(currentState != null){
                currentState.DeinitState(this);
            }

            currentState = newState;

            if(currentState != null){
                currentState.InitState(this);
            }
        }

        public void UpdateState()
        {
            currentState.UpdateState(this);
        }

        #endregion

        private void StartGameState(){
            var gameState = new GameState();
            ChangeState(gameState);
        }

        private void StartMenuState(){
            var menuState = new MenuState();
            menuState.listener = this;
            ChangeState(menuState);
        }

        IEnumerator WaitForChange(){
            yield return new WaitForSeconds(3f);
            StartGameState();
        }

        #region IMenuListener implementation

        public void OnDeinitState()
        {
            Debug.LogError("GameController :: Menu state got deinited");
        }

        #endregion
    }
}