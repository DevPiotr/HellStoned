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

        public IGameController listener;
    }
}
