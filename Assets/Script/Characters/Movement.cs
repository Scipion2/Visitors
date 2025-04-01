using UnityEngine;

public class Movement : MonoBehaviour
{
    
    [SerializeField] private Rigidbody2D CharacterBody;
    [SerializeField] private float JumpAnimDuration=0.6f;
    [SerializeField] private float WalkSpeed=1f,Runfactor=2f,Jumpheigth=5f;
    private bool isCharacterRunning=false,isCharacterJumping=false;

    public void Move(Vector2 Movement)
    {

        if(Movement!=Vector2.zero)
        {

            CharacterBody.linearVelocity+=Movement*WalkSpeed;

        }

    }

    public void Jump()
    {

        if(!isCharacterJumping)
        {

            CharacterBody.linearVelocity+=(Vector2.up*Jumpheigth);
            Invoke("Land",JumpAnimDuration);
            isCharacterJumping=true;

        }

    }

    public void Run()
    {

        if(!isCharacterRunning)
        {

            WalkSpeed*=Runfactor;
            isCharacterRunning=true;
        }
        

    }

    public void WalkBack()
    {

        if(isCharacterRunning)
        {

            WalkSpeed/=Runfactor;
            isCharacterRunning=false;

        }

    }

    public void Land()
    {

        isCharacterJumping=false;

    }


}
