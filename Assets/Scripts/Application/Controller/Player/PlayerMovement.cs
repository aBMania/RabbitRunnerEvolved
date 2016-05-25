using UnityEngine;
using System.Collections;
using Application;
using Application.Model.Player;

public class PlayerMovement : RabbitApplicationElement {
	void Update ()
	{
	    Player player = App.Model.Player;

        player.Location += player.Speed * Time.deltaTime;
    }
}
