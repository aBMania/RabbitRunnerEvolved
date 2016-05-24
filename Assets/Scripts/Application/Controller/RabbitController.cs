namespace Application.Controller
{
    public class RabbitController : RabbitApplicationElement
    {
        public GameManager.GameManager GameManager
        {
            get { return GetComponentInChildren<GameManager.GameManager>(); }
        }
    }
}
