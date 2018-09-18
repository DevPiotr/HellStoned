using UnityEngine;
using HellStoned.Core;
namespace HellStoned.State
{
    public class PauseState : BaseState, IPauseState
    {
        private GameController controller;

        public override void InitState(GameController controller)
        {
            Time.timeScale = 0.0f;
            this.controller = controller;
            controller._UIRootController._UIPauseViewController.listener = this;

            controller._UIRootController._UIPauseViewController.gameObject.SetActive(true);
        }
        public override void UpdateState(GameController controller)
        {
            base.UpdateState(controller);
        }
        public override void DeinitState(GameController controller)
        {
            controller._UIRootController._UIPauseViewController.gameObject.SetActive(false);
        }

        public void onResumeButton()
        {
            //controller.ResumeGameState();
        }

        public void onQuitButton()
        {
            controller.StartMenuState();
        }

       
    }
}
