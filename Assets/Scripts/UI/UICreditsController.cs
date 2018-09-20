using UnityEngine;
using HellStoned.Core;

namespace HellStoned.UI
{
    public class UICreditsController : MonoBehaviour
    {
        public IMenuState listener;

        public void OnBackButtonClick()
        {
            listener.OnCreditsBackButton();
        }
    }
}
