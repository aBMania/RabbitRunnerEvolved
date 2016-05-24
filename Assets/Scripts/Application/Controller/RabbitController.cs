namespace Application.Controller
{
    public class RabbitController : RabbitApplicationElement
    {
        private GameManager.GameManager _gameManager;

        public void Awake()
        {
            _gameManager = GetComponentInChildren<GameManager.GameManager>();
        }


        public GameManager.GameManager GameManager
        {
            get { return _gameManager; }
        }
    }
}
