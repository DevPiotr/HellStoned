using HellStoned.Core;
using HellStoned.UI;
using UnityEngine;

namespace HellStoned.State {
    public class GameState : BaseState, IGameState {

        private UIGameViewController uiGameViewController;

        private float time = 1;
        private int score = 0;


        public override void InitState(GameController controller)
        {
            base.InitState(controller);
            Debug.LogWarning("GameState:: init");

            uiGameViewController = controller._UIRootController._UIGameViewController;
            uiGameViewController.gameObject.SetActive(true);   
        }

        public override void UpdateState(GameController controller)
        {
            time += Time.deltaTime;
            UpdateTimer(time);
            UpdateStonedBar(-0.001f);

            
        }

        public override void DeinitState(GameController controller)
        {
            base.InitState(controller);
            Debug.LogWarning("GameState::deinit");
        }

        public void UpdateTimer(float time)
        {
            uiGameViewController.Timer.text = time.ToString("#.##");
        }

        public void UpdateStonedBar(float value)
        {
            uiGameViewController.StonedBar.value += value;
        }

        public void UpdateScore(int score)
        {
            uiGameViewController.Score.text = score.ToString();
        }

    }
}
