namespace HellStoned.Core
{
    public interface IPlayerController{

        void OnPortalEnter();
        void OnTrapEnter();
        void OnEndPortalEnter();

        void ChangeScore(int score);
        void ChangeStonedBarValue(float value);
        void PlayPickUpSound();
        void PlayJumpSound();
        void PlayGettingHitSound();

        void SetAndShowTutorialText(TutorialTrigger trigger);
    }
}

public enum TutorialTrigger { Canabis, Traps, EndLevel };
