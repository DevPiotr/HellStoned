using UnityEngine;
using HellStoned.Core;

namespace HellStoned.State
{
    public class MenuState : BaseState, IMenuState
    {
        private GameController controller;

        public override void InitState(GameController controller)
        {
            Cursor.lockState = CursorLockMode.None;

            base.InitState(controller);
            Debug.LogWarning("MenuState ::Init");
            
            controller._UIRootController._UIMainMenuController.listener = this;
            controller._UIRootController._UIHighScoreController.listener = this;
            controller._UIRootController._UICreditsController.listener = this;

            this.controller = controller;

            if (controller.checkAndChangeHighScore)
            {
                setHighScoreData();
                controller.checkAndChangeHighScore = false;
            }
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

        public void setHighScoreData()
        {
            controller._UIRootController._UIHighScoreController.Scores[0].SetText(controller._DataStorage._GlobalHighScores.Scores[0].ToString());
            controller._UIRootController._UIHighScoreController.Scores[1].SetText(controller._DataStorage._GlobalHighScores.Scores[1].ToString());
            controller._UIRootController._UIHighScoreController.Scores[2].SetText(controller._DataStorage._GlobalHighScores.Scores[2].ToString());
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