using UnityEngine;

public class NPCMobileControler : Controler
{
    
    [SerializeField] private Transform RightLimit,LeftLimit;
    [SerializeField] private float MoveDelta=0.2f;
    public bool MoveRight=true;

    public void Update()
    {

        float x=transform.position.x;

        if(x>=RightLimit.position.x)
        {

            MoveRight=false;

        }

        if(x<=LeftLimit.position.x)
        {

            MoveRight=true;

        }

        if(MoveRight)
        {

            x=Mathf.Lerp(x,RightLimit.position.x,MoveDelta);

        }else
        {

            x=Mathf.Lerp(LeftLimit.position.x,x,MoveDelta);

        }

        Move(new Vector2(x,0));


    }

    public void Move(Vector2 MoveDirection)
    {

        CharacterMovement.Move(MoveDirection.x);

    }

}
