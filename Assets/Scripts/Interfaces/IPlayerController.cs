namespace HellStoned.Core
{
    public interface IPlayerController{

        void OnPortalEnter();
        void OnTrapEnter();
        void ChangeScore(int score);
        void ChangeStonedBarValue(float value);
        void PlayPickUpSound();
        void PlayJumpSound();
    }
}
