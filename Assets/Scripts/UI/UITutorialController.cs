using UnityEngine;
using HellStoned.Core;
using TMPro;

namespace HellStoned.UI
{
    public class UITutorialController : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI tutorialText;
        public TextMeshProUGUI TutorialText { get { return this.tutorialText; } }

    }
}