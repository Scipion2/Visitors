using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : Controler
{
    
    [Header("Datas")]

        InputAction AttackAction;
        private float RotateMargin=0.2f,RayRange=0.5f;
        [SerializeField] private LayerMask GroundLayerMask;
        [SerializeField] private bool isGrounded=true;
        [SerializeField] private Vector2 OldPos=new Vector2();

    [Header("Components")]

        [SerializeField] private Transform Base;

    //SETTERS

    //GETTERS

    //ESSENTIALS

        public void Start()
        {

            EventManager.instance.JumpEvent.AddListener(Jump);
            AttackAction=InputSystem.actions.FindAction("Attack");
            GroundChecker.onLineCastHit2D.AddListener(GroundCheck);
            OldPos=this.transform.position;
            Input.gyro.enabled=true;

        }

        public void Update()
        {


            if(AttackAction.IsPressed())
            {

                UpdateAnimation(ISATTACKING);

            }


            Vector2 CharacterMoveQuantity=CharacterMovement.GetCharacterBody().linearVelocity;

            if(CharacterMoveQuantity.x>0.1)
            {

                UpdateAnimation(ISMOVINGRIGHT);

            }else if(CharacterMoveQuantity.x<-0.1)
            {

                UpdateAnimation(ISMOVINGLEFT);

            }else
            {

                UpdateAnimation(ISIDLE);

            }
            

        }

    //ACTIONS

        private void Move()
        {

            //

        }


    //LISTENERS

        public void Jump()
        {

            if(isGrounded)
            {

                CharacterMovement.Jump();
                CharacterAnimator.SetBool("isLanding",false);
                UpdateAnimation(ISJUMPING);
                isGrounded=false;

            }

        }

        public void GroundCheck(Collider2D Hitted)
        {

            if(!isGrounded)
            {
                UpdateAnimation(ISIDLE);
                CharacterAnimator.SetBool("isLanding",true);
                isGrounded=true;
            }

        }

}