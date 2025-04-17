using UnityEngine;

public class NPCMobileControler : Controler
{
    
    [SerializeField] private Transform RightUpLimit,LeftDownLimit;
    [SerializeField] private float MoveDelta=0.2f,distance,speed=0.5f;
    public bool MoveRight=true,isAutoMove=true,isVerticalMove=false;

    public void Awake()
    {

        if(isAutoMove)
            distance=Vector3.Distance(LeftDownLimit.position,RightUpLimit.position);

    }

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
        MoveDelta=Mathf.PingPong(Time.time*speed,distance);


        if(MoveRight)
        {

            Move(new Vector2(0,MoveDelta));
            UpdateAnimation(ISMOVINGUP);

        }else
        {

            Move(new Vector2(0,-MoveDelta));
            UpdateAnimation(ISMOVINGDOWN);

        }

    }

    public void AutoMove()
    {


        CheckMovingDir(false);

        float x=transform.position.x;
        MoveDelta=Mathf.PingPong(Time.time*speed,distance);


        if(MoveRight)
        {

            Move(new Vector2(MoveDelta,0));
            UpdateAnimation(ISMOVINGRIGHT);

        }else
        {

            Move(new Vector2(-MoveDelta,0));
            UpdateAnimation(ISMOVINGLEFT);

        }

    }

    public void CheckMovingDir(bool isVertical)
    {

        
        if(isVertical)
        {

            if(transform.position.y>=RightUpLimit.position.y)
                MoveRight=false;

            if(transform.position.y<=LeftDownLimit.position.y)
                MoveRight=true;

        }else
        {

            if(transform.position.x>=RightUpLimit.position.x)
                MoveRight=false;

            if(transform.position.x<=LeftDownLimit.position.x)
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
