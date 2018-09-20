using UnityEngine;
namespace HellStoned.Core
{
    public interface IGameController
    {
        void StartMenuState();
        void StartGameState();
        void ChangeLevel();
        void QuitGame();
        void WinAGame();
    }
}