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

        public IGameController listener;
    }
}
