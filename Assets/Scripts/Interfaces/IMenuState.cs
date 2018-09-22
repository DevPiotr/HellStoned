namespace HellStoned.Core
{
    public interface IMenuState
    {
        void OnPlayButton();
        void OnHighScoreButton();
        void OnCreditsButton();
        void OnQuitButton();

        void setHighScoreData();
        void OnHighScoreBackButton();

        void OnCreditsBackButton();
    }
}