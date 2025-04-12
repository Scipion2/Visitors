using UnityEngine;
using UnityEngine.InputSystem;
using Gyroscope = UnityEngine.InputSystem.Gyroscope;

public class PlayerControler : Controler
{
    
    [Header("Datas")]

        InputAction AttackAction,MoveAction;
        private float RotateMargin=0.2f,RayRange=0.5f;
        [SerializeField] private LayerMask GroundLayerMask;
        [SerializeField] private bool isGrounded=true;
        private bool GyroChecked=false;

    [Header("Components")]

        [SerializeField] private Transform Base;

    //SETTERS

    //GETTERS

    //ESSENTIALS
    

        public void Start()
        {

            EventManager.instance.JumpEvent.AddListener(Jump);
            AttackAction=InputSystem.actions.FindAction("Attack");
            MoveAction=InputSystem.actions.FindAction("GyroMove");
            GroundChecker.onLineCastHit2D.AddListener(GroundCheck);
            
            
            

        }

        public void Update()
        {
            
            if(AttackAction.IsPressed())
            {

                UpdateAnimation(ISATTACKING);

            }


            float AngularMobileMovement=MoveAction.ReadValue<Vector3>().x;
            CharacterMovement.Move(AngularMobileMovement);

            if(AngularMobileMovement>0.05)
            {

                UpdateAnimation(ISMOVINGRIGHT);

            }else if(AngularMobileMovement<-0.05)
            {

                UpdateAnimation(ISMOVINGLEFT);

            }else
            {

                UpdateAnimation(ISIDLE);

            }      

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