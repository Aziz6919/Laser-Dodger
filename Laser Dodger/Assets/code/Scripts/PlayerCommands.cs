using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommands : MonoBehaviour
{
    public class MoveCommand : Icommand
    {
        SimpleSampleCharacterControl Player;
       

        public MoveCommand(SimpleSampleCharacterControl player)
        {
            Player = player;
           

        }
        public void Excute() => Player.PlayerMovement();

    }

    public class JumpCommand : Icommand
    {
        SimpleSampleCharacterControl Player;
        public JumpCommand(SimpleSampleCharacterControl player)
        {
            Player = player;
        }
        public void Excute()
        {
            Player.Playerjump();
        }
    }
}
