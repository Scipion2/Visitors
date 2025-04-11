using UnityEngine;

public class NPCMobileControler : Controler
{
    
    public void Move(Vector2 MoveDirection)
    {

        CharacterMovement.Move(MoveDirection.x);

    }

}
