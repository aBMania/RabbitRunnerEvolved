using System;

namespace Application.Controller.GameManager
{
    public class GameManager : RabbitApplicationElement
    {
        public delegate void GameStartAction();
        public event GameStartAction OnGameStart;

        public delegate void GameEndAction();
        public event GameEndAction OnGameEnd;

        private bool _isActive;

        public bool IsActive
        {
            get { return _isActive; }
        }

        public void Start()
        {
            StartGame();
        }

        private void StartGame()
        {
            _isActive = true;
            if (OnGameStart != null)
                OnGameStart();
        }

        private void EndGame()
        {
            _isActive = false;
            if (OnGameEnd != null )
                OnGameEnd();
        }
    }
}