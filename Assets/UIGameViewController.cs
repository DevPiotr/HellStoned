using UnityEngine;
using UnityEngine.UI;

public class UIGameViewController : MonoBehaviour  {

    [SerializeField]
    private Text score;
    public Text Score { get { return this.score; } }

    [SerializeField]
    private Text timer;
    public Text Timer { get { return this.timer; } }

    [SerializeField]
    private Slider stonedBar;
    public Slider StonedBar { get { return this.stonedBar; } }

    public void UpdateTimer(float time)
    {
        timer.text = time.ToString("#.##");
    }

    public void UpdateStonedBar(float value)
    {
        stonedBar.value += value;
    }

    public void UpdateScore(int score)
    {
        this.score.text = score.ToString();
    }
}
