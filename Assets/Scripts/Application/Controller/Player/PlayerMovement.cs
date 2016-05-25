using UnityEngine;

namespace Application.Controller.Player
{
    public class PlayerMovement : RabbitApplicationElement {
        public void Update ()
        {
            var player = App.Model.Player;

            player.Location += player.Speed * Time.deltaTime;
        }
    }
}
