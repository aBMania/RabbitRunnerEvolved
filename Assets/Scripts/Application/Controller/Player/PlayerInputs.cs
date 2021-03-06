﻿using UnityEngine;

namespace Application.Controller.Player
{
    public class PlayerInputs : RabbitApplicationElement
    {
        public void Update()
        {
            Model.Player.Player player = App.Model.Player;
            float vertical = Input.GetAxisRaw("Horizontal");

            player.Angle += vertical * player.AngularSpeed * Time.deltaTime;
        }
    }
}