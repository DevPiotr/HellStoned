using UnityEngine;
using HellStoned.Core;
namespace HellStoned.UI {
    public class UIRootController : MonoBehaviour {

        [SerializeField]
        private UIMainMenuController _uiMainMenuController;
        public UIMainMenuController _UIMainMenuController { get { return this._uiMainMenuController; } }

        [SerializeField]
        private UIGameViewController _uiGameViewController;
        public UIGameViewController _UIGameViewController { get { return this._uiGameViewController; } }

        [SerializeField]
        private UIPauseViewController _uiPauseViewController;
        public UIPauseViewController _UIPauseViewController { get { return this._uiPauseViewController; } }

        [SerializeField]
        private UIHighScoreController _uiHighScoreController;
        public UIHighScoreController _UIHighScoreController { get { return this._uiHighScoreController; } }

        [SerializeField]
        private UICreditsController _uiCreditsController;
        public UICreditsController _UICreditsController { get { return this._uiCreditsController; } }

        [SerializeField]
        private UIWinGameViewController _uiWinGameViewController;
        public UIWinGameViewController _UIWinGameViewController { get { return this._uiWinGameViewController; } }

        [SerializeField]
        private UILoseGameViewController _uiLoseGameViewControler;
        public UILoseGameViewController _UILoseGameViewController { get { return this._uiLoseGameViewControler; } }

        [SerializeField]
        private UITutorialController _uiTutorialControler;
        public UITutorialController _UITutorialControler { get { return this._uiTutorialControler; } }

        [SerializeField]
        private UIGameHistoryViewController _uiGameHistoryViewController;
        public UIGameHistoryViewController _UIGameHistoryViewController { get { return this._uiGameHistoryViewController; } }

        public IGameController listener;
    }
}
