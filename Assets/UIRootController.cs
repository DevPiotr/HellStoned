using UnityEngine;
using UnityEngine.UI;

public class UIRootController : MonoBehaviour {

    [SerializeField]
    private UIGameViewController gameView;
    public UIGameViewController GameView { get { return this.gameView; } }
}
