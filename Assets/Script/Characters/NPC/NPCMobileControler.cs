using UnityEngine;

public class NPCMobileControler : Controler
{
    
    [SerializeField] private Transform RightLimit,LeftLimit;
    [SerializeField] private float MoveDelta=0.2f,distance,speed=0.5f;
    public bool MoveRight=true,isAutoMove=true;

    public void Awake()
    {

        distance=Vector3.Distance(LeftLimit.position,RightLimit.position);

    }

    public void Update()
    {

        if(isAutoMove)
            AutoMove();

    }

    public void AutoMove()
    {


        CheckMovingDir();

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

    public void CheckMovingDir()
    {

        if(transform.position.x>=RightLimit.position.x)
            MoveRight=false;

        if(transform.position.x<=LeftLimit.position.x)
            MoveRight=true;

    }

    public void Move(Vector2 MoveDirection)
    {

        CharacterMovement.Move(MoveDirection.x);

    }

}
