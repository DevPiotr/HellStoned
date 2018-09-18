using UnityEngine;
namespace HellStoned.Core
{
    public interface IGameController
    {
        void StartMenuState();
        void StartGameState();
        void ResumeGameState();
        void StartPauseState();
        void ChangeLevel();
        void QuitGame();

    }
}