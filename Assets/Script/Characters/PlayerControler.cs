using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : Controler
{
    
    [Header("Datas")]

        InputAction AttackAction;
        private float RotateMargin=0.2f,RayRange=0.5f;
        [SerializeField] private LayerMask GroundLayerMask;
        [SerializeField] private bool isGrounded=true;
        private float RotationRate=0f;

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
            Input.gyro.enabled=true;

        }

        public void Update()
        {


            if(AttackAction.IsPressed())
            {

                UpdateAnimation(ISATTACKING);

            }


            if(Input.gyro.rotationRateUnbiased!=null)
            {

                RotationRate=Input.gyro.rotationRateUnbiased.z;

            }

            CharacterMovement.Move(new Vector2(RotationRate,0));


            if(RotationRate>0.1)
            {

                UpdateAnimation(ISMOVINGRIGHT);

            }else if(RotationRate<-0.1)
            {

                UpdateAnimation(ISMOVINGLEFT);

            }else
            {

                UpdateAnimation(ISIDLE);

            }




            /*Vector2 CharacterMoveQuantity=CharacterMovement.GetCharacterBody().linearVelocity;

            if(CharacterMoveQuantity.x>0.1)
            {

                UpdateAnimation(ISMOVINGRIGHT);

            }else if(CharacterMoveQuantity.x<-0.1)
            {

                UpdateAnimation(ISMOVINGLEFT);

            }else
            {

                UpdateAnimation(ISIDLE);

            }*/
            

        }

    //ACTIONS


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