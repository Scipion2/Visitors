using UnityEngine;

public class NPCMobileControler : Controler
{
    
    [SerializeField] private Transform RightUpLimit,LeftDownLimit;
    [SerializeField] private float MoveDelta=0.2f,speed=1f;
    public bool MoveRight=true,isAutoMove=true,isVerticalMove=false;
    private float CheckRange=0.5f;


    public void Update()
    {

        if(isAutoMove)
        {

            if(!isVerticalMove)
                AutoMove();
            else
                AutoMoveVertical();

        }

    }

    public void AutoMoveVertical()
    {


        CheckMovingDir(true);

        float y=transform.position.y;
        MoveDelta=Mathf.PingPong(Time.time*speed,1);
        y=Mathf.Lerp(LeftDownLimit.position.y,RightUpLimit.position.y,MoveDelta);


        if(MoveRight)
        {

            Move(new Vector2(0,y));
            UpdateAnimation(ISMOVINGUP);

        }else
        {

            Move(new Vector2(0,-y));
            UpdateAnimation(ISMOVINGDOWN);

        }

    }

    public void AutoMove()
    {


        CheckMovingDir(false);

        float x=transform.position.x;
        MoveDelta=Mathf.PingPong(Time.time*speed,1);
        x=Mathf.Lerp(LeftDownLimit.position.x,RightUpLimit.position.x,MoveDelta);


        if(MoveRight)
        {

            Move(new Vector2(x,0));
            UpdateAnimation(ISMOVINGRIGHT);

        }else
        {

            Move(new Vector2(-x,0));
            UpdateAnimation(ISMOVINGLEFT);

        }

    }

    public void CheckMovingDir(bool isVertical)
    {

        
        if(isVertical)
        {

            if(transform.position.y-RightUpLimit.position.y>=0)
                MoveRight=false;

            if(transform.position.y-LeftDownLimit.position.y<=0)
                MoveRight=true;

        }else
        {

            if(transform.position.x-RightUpLimit.position.x>=0)
                MoveRight=false;

            if(transform.position.x-LeftDownLimit.position.x<=0)
                MoveRight=true;

        }
        
    }

    public void Move(Vector2 MoveDirection)
    {

        if(isVerticalMove)
            CharacterMovement.VerticalMove(MoveDirection.y);
        else
            CharacterMovement.Move(MoveDirection.x);

    }

}
