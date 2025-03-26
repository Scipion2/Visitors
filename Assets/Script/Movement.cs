using UnityEngine;

public class Movement : MonoBehaviour
{
    
    [SerializeField] private Animator CharacterAnimator;
    [SerializeField] private SpriteRenderer CharacterRenderer;
    [SerializeField] private float JumpAnimDuration=0.6f;
    [SerializeField] private float WalkSpeed=100f,Runfactor=2f,Jumpheigth=0.5f;
    private bool isCharacterRunning=false,isCharacterJumping=false;

    [Header("Animation State")]
        private const string isWalking="isWalking";
        private const string isRunning="isRunning";
        private const string isJumping="isJumping";

    public void Move(Vector2 Movement)
    {

        if(Movement!=Vector2.zero)
        {

            if(Movement==Vector2.left)
                CharacterRenderer.flipX=true;
            else
                CharacterRenderer.flipX=false;

            CharacterAnimator.SetBool(isWalking,true);
            transform.Translate(Movement*WalkSpeed);

        }else
        {

            CharacterAnimator.SetBool(isWalking,false);

        }

    }

    public void Jump()
    {

        if(!isCharacterJumping)
        {

            CharacterAnimator.SetBool(isJumping,true);
            transform.Translate(Vector3.up*Jumpheigth);
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
            CharacterAnimator.SetBool(isRunning,true);

        }
        

    }

    public void WalkBack()
    {

        if(isCharacterRunning)
        {

            WalkSpeed/=Runfactor;
            isCharacterRunning=false;
            CharacterAnimator.SetBool(isRunning,false);

        }

    }

    public void Land()
    {

        CharacterAnimator.SetBool(isJumping,false);
        isCharacterJumping=false;

    }


}
