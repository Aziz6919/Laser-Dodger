using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] SimpleSampleCharacterControl Player;
    Icommand MoveIcommand;
    Icommand JumpIcommand;
    private void Awake()
    {
        Player = GetComponent<SimpleSampleCharacterControl>();
    }
    private void FixedUpdate()
    {

        move();
    }
   
    // thsi is Player Move  Method
    #region 

    void move()
    {
        
        MoveIcommand = new PlayerCommands.MoveCommand(Player);
        MoveIcommand.Excute();
    }
    #endregion;
    // thsi is Player Jump  Method
    #region
    public void jump()
    {
        JumpIcommand = new PlayerCommands.JumpCommand(Player);
        JumpIcommand.Excute();
    }
   
    #endregion
}
