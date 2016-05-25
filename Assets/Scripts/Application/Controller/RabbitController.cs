using Application.Controller.Player;

namespace Application.Controller
{
    public class RabbitController : RabbitApplicationElement
    {
        public GameManager.GameManager GameManager
        {
            get { return GetComponentInChildren<GameManager.GameManager>(); }
        }

        public PlayerInputs PlayerInputs
        {
            get { return GetComponentInChildren<PlayerInputs>(); }
        }
    }
}
