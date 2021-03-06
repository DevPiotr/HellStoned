﻿using HellStoned.Core;
using HellStoned.UI;
using UnityEngine;

namespace HellStoned.State {
    public class GameState : BaseState, IGameState,IPlayerController {

        private UIGameViewController uiGameViewController;
        private GameController controller;
        private Animator tutorialTextAnimator;

        private float time = 1;
        private bool isPaused = false;
        
        private int score = 0;
        

        public override void InitState(GameController controller)
        {
            base.InitState(controller);

            controller._UIRootController._UIGameViewController.Score.text = "0";
            controller._UIRootController._UIGameViewController.StonedBar.value = 1;

            uiGameViewController = controller._UIRootController._UIGameViewController;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            this.controller = controller;

            controller._PlayerController.listener = this;
            controller._PlayerController.isPaused = false;

            tutorialTextAnimator = controller._UIRootController._UITutorialControler.GetComponent<Animator>();

            uiGameViewController.gameObject.SetActive(true);
            controller._UIRootController._UITutorialControler.gameObject.SetActive(true);

            controller._UIRootController._UITutorialControler.TutorialText.SetText("Moving W,S,A,D");
            tutorialTextAnimator.SetTrigger("ShowTutorial");
        }

        public override void UpdateState(GameController controller)
        {
            if (!isPaused)
            {

                time += Time.deltaTime;
                UpdateTimer(time);
                UpdateStonedBar(-0.04f * Time.deltaTime);

                if (uiGameViewController.StonedBar.value <= 0)
                { 
                    controller.LoseAGame();
                }
                if (Input.GetKeyDown("escape"))
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    isPaused = true;
                    Time.timeScale = 0.0f;
                    controller._PlayerController.isPaused = true;

                    controller._UIRootController._UIPauseViewController.listener = this;

                    uiGameViewController.gameObject.SetActive(false);
                    controller._UIRootController._UIPauseViewController.gameObject.SetActive(true);
                }
            }
        }

        public override void DeinitState(GameController controller)
        {
            base.InitState(controller);

            score = 0;
            uiGameViewController.gameObject.SetActive(false);
        }

        public void UpdateTimer(float time)
        {
            uiGameViewController.Timer.text = time.ToString("#.##");
        }

        public void UpdateStonedBar(float value)
        {
            uiGameViewController.StonedBar.value += value;
        }

        public void OnResumeButton()
        {
            Time.timeScale = 1f;
            isPaused = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            controller._PlayerController.isPaused = false;

            uiGameViewController.gameObject.SetActive(true);
            controller._UIRootController._UIPauseViewController.gameObject.SetActive(false);
        }

        public void OnQuitButton()
        {
            controller._PlayerController.transform.position = new Vector3(0, 0, 0);
            controller._UIRootController._UIPauseViewController.gameObject.SetActive(false);
            controller._UIRootController._UITutorialControler.TutorialText.alpha = 0;
            controller.StartMenuState();
        }
        #region IPlayerController implementation
        public void OnPortalEnter()
        {
                uiGameViewController.StonedBar.maxValue += 0.2f;
                uiGameViewController.StonedBar.value = uiGameViewController.StonedBar.maxValue;

                ChangeScore((int)Mathf.Round(1000f / time));
                
                controller.globalTimer += time;

                time = 1;
      
                controller.ChangeLevel();         
        }

        public void OnTrapEnter()
        {
            ChangeStonedBarValue(-0.1f);
        }

        public void ChangeScore(int score)
        {
            this.score += score;
            uiGameViewController.Score.text = this.score.ToString();
        }

        public void ChangeStonedBarValue(float value)
        {
            uiGameViewController.StonedBar.value += value;
        }

        public void PlayPickUpSound()
        {
            controller._AudioStorageController.PickUp.Play();
        }
        public void PlayJumpSound()
        {
            controller._AudioStorageController.Jump.Play();
        }
        public void PlayGettingHitSound()
        {
            controller._AudioStorageController.GettingHit.Play();
        }
        public void OnEndPortalEnter()
        {
            ChangeScore((int)Mathf.Round(1000f / time));
            controller.endGameScore = int.Parse(uiGameViewController.Score.text);
            controller.globalTimer += time;    
            controller.WinAGame();
        }

        public void SetAndShowTutorialText(TutorialTrigger trigger)
        {
            if(trigger == TutorialTrigger.Canabis)
            {
            controller._UIRootController._UITutorialControler.TutorialText.SetText("Collect weed to survive");
            }
            if (trigger == TutorialTrigger.Traps)
            {
            controller._UIRootController._UITutorialControler.TutorialText.SetText("Avoid traps. \n Jump: Space");
            }
            if (trigger == TutorialTrigger.EndLevel)
            {
            controller._UIRootController._UITutorialControler.TutorialText.SetText("Collect red weed to change level");
            }

            tutorialTextAnimator.SetTrigger("ShowTutorial");
        }
        #endregion

    }
}
