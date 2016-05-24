namespace Application.Controller.GameManager
{
    public class GameManager : RabbitApplicationElement
    {
        public delegate void GameStartAction();
        public event GameStartAction OnGameStart;

        public delegate void GameEndAction();
        public event GameEndAction OnGameEnd;

        public void Start()
        {
            StartGame();
        }

        private void StartGame()
        {
            if (OnGameStart != null)
                OnGameStart();
        }
    }
}