using UnityEngine;

public class Movement : MonoBehaviour
{
    
    [SerializeField] private Rigidbody2D CharacterBody;
    [SerializeField] private float JumpAnimDuration=0.6f;
    [SerializeField] private float WalkSpeed=1f,Runfactor=2f,Jumpheigth=5f,MaxSpeed=10;
    private bool isCharacterRunning=false,isCharacterJumping=false;

    //GETTERS

        public Rigidbody2D GetCharacterBody(){return CharacterBody;}//Getter For CharacterBody

    public void Move(float Movement)
    {

        CharacterBody.linearVelocity=new Vector2(Movement*WalkSpeed,CharacterBody.linearVelocity.y);
        CharacterBody.linearVelocity=new Vector2(Mathf.Clamp(CharacterBody.linearVelocity.x, -MaxSpeed, MaxSpeed),CharacterBody.linearVelocity.y);

    }

    public void Jump()
    {

        if(!isCharacterJumping)
        {

            CharacterBody.AddForce(Vector2.up*Jumpheigth);
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
