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
            Cursor.visible = true;
            base.InitState(controller);


            controller._UIRootController._UIMainMenuController.listener = this;
            controller._UIRootController._UIHighScoreController.listener = this;
            controller._UIRootController._UICreditsController.listener = this;
            controller._UIRootController._UIWinGameViewController.listener = this;
            controller._UIRootController._UILoseGameViewController.listener = this;
            controller._UIRootController._UIGameHistoryViewController.listener = this;

            Time.timeScale = 1f;

            this.controller = controller;

            

            if (controller.isFirstStart)
            {
                controller._UIRootController._UIGameHistoryViewController.gameObject.SetActive(true);
                controller.isFirstStart = false;
                
            }
            else
            {
                if (controller.isGameWon)
                {
                    controller.isGameWon = false;
                    SetHighScoreData();
                    ShowWinGameView();
                }
                else if (controller.isGameLost)
                {
                    controller.isGameLost = false;
                    ShowLoseGameView();
                }
                else
                {
                    controller._UIRootController._UIMainMenuController.gameObject.SetActive(true);
                }
            }
            
        }

        public override void UpdateState(GameController controller)
        {
            base.UpdateState(controller);

        }

        public override void DeinitState(GameController controller)
        {
            base.DeinitState(controller);

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

        public void SetHighScoreData()
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


        public void ShowWinGameView()
        {
            controller._UIRootController._UIWinGameViewController.Time.SetText(controller.globalTimer.ToString("#.##"));
            controller._UIRootController._UIWinGameViewController.Score.SetText(controller.endGameScore.ToString());
            controller._UIRootController._UIWinGameViewController.gameObject.SetActive(true);
        }
        public void OnWinGameViewBackButton()
        {
            controller._UIRootController._UIWinGameViewController.gameObject.SetActive(false);
            controller._UIRootController._UIMainMenuController.gameObject.SetActive(true);
        }

        public void BackToMenuFromLose()
        {
            controller._UIRootController._UILoseGameViewController.gameObject.SetActive(false);
            controller._UIRootController._UIMainMenuController.gameObject.SetActive(true);
        }
        public void ShowLoseGameView()
        {
            controller._UIRootController._UIGameViewController.gameObject.SetActive(false);
            controller._UIRootController._UILoseGameViewController.gameObject.SetActive(true);
        }
        public void GoToMenuFromHistory()
        {
            controller._AudioStorageController.WelcomeToHell.Play();

            
            controller._UIRootController._UIGameHistoryViewController.gameObject.SetActive(false);
            controller._UIRootController._UIMainMenuController.gameObject.SetActive(true);
            SetHighScoreData();
        }

        public void OnQuitButton()
        {
            controller.QuitGame();
        }

        #endregion
    }
}