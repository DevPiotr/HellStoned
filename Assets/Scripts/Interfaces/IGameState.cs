namespace HellStoned.Core
{
    public interface IGameState
    {
        void UpdateTimer(float time);
        void UpdateStonedBar(float value);
        void OnResumeButton();
        void OnQuitButton();
    }
}
