namespace HellStoned.Core
{
    public interface IMenuState
    {
        
        // Menu
        void OnPlayButton();
        void OnHighScoreButton();
        void OnCreditsButton();
        void OnQuitButton();

        //Highscore
        void SetHighScoreData();
        void OnHighScoreBackButton();

        //Credits
        void OnCreditsBackButton();

        //WinGameView
        void ShowWinGameView();
        void OnWinGameViewBackButton();

        //LoseGameView
        void BackToMenuFromLose();
        void ShowLoseGameView();

        void GoToMenuFromHistory();
    }
}