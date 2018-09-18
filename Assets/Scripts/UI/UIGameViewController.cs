using UnityEngine;
using UnityEngine.UI;
using HellStoned.Core;
namespace HellStoned.UI
{
    public class UIGameViewController : MonoBehaviour
    {
        public IGameState listener;

        [SerializeField]
        private Text score;
        public Text Score { get { return this.score; } }

        [SerializeField]
        private Text timer;
        public Text Timer { get { return this.timer; } }

        [SerializeField]
        private Slider stonedBar;
        public Slider StonedBar { get { return this.stonedBar; } }
       
    }
}