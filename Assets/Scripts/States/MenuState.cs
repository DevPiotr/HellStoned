using UnityEngine;
using HellStoned.Core;

namespace HellStoned.State
{
    public class MenuState : BaseState, IMenuState
    {
        private GameController controller;

        public override void InitState(GameController controller)
        {
            base.InitState(controller);
            Debug.LogWarning("MenuState ::Init");

           
            controller._UIRootController._UIMainMenuController.listener = this;
            controller._UIRootController._UIHighScoreController.listener = this;
            controller._UIRootController._UICreditsController.listener = this;

            this.controller = controller;

            controller._UIRootController._UIMainMenuController.gameObject.SetActive(true);
        }

        public override void UpdateState(GameController controller)
        {
            base.UpdateState(controller);
            Debug.LogWarning("MenuState ::Update");
        }

        public override void DeinitState(GameController controller)
        {
            base.DeinitState(controller);
            Debug.LogWarning("MenuState ::Deinit");
            controller._UIRootController._UIMainMenuController.gameObject.SetActive(false);
        }

        #region IMenuState implementation
        public void OnPlayButton()
        {
            controller.StartGameState();    
        }

        public void OnHighScoreButton()
        {
            controller._UIRootController._UIMainMenuController.gameObject.SetActive(false);
            controller._UIRootController._UIHighScoreController.gameObject.SetActive(true);
        }


        public void OnCreditsButton()
        {
            controller._UIRootController._UIMainMenuController.gameObject.SetActive(false);
            controller._UIRootController._UICreditsController.gameObject.SetActive(true);
        }


        public void OnHighScoreBackButton()
        {
            controller._UIRootController._UIHighScoreController.gameObject.SetActive(false);
            controller._UIRootController._UIMainMenuController.gameObject.SetActive(true);       
        }

        public void OnCreditsBackButton()
        {
            controller._UIRootController._UICreditsController.gameObject.SetActive(false);
            controller._UIRootController._UIMainMenuController.gameObject.SetActive(true);
        }
        public void OnQuitButton()
        {
            controller.QuitGame();
        }
        #endregion
    }
}