using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : Controler
{
    
    [Header("Datas")]

        InputAction MoveAction;
        [SerializeField] private LayerMask GroundLayerMask;
        [SerializeField] private bool isGrounded=true;

    [Header("Components")]

        [SerializeField] private Transform Base;

    //SETTERS

    //GETTERS

    //ESSENTIALS


        public void OnEnable()
        {
            
            EventManager.instance.JumpEvent.AddListener(Jump);
            GroundChecker.onLineCastHit2D.AddListener(GroundCheck);

        }

        public void OnDisable()
        {

            EventManager.instance.JumpEvent.RemoveListener(Jump);
            GroundChecker.onLineCastHit2D.RemoveListener(GroundCheck);

        }

        public void Start()
        {

            MoveAction=InputSystem.actions.FindAction("GyroMove"); 

        }

        public void Update()
        {


            float AngularMobileMovement=MoveAction.ReadValue<Vector3>().x;
            //CharacterMovement.Move(AngularMobileMovement);

            if(AngularMobileMovement>0.1)
            {

                UpdateAnimation(ISMOVINGRIGHT);
                CharacterMovement.Move(AngularMobileMovement);

            }else if(AngularMobileMovement<-0.1)
            {

                UpdateAnimation(ISMOVINGLEFT);
                CharacterMovement.Move(AngularMobileMovement);

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