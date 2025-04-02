using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : Controler
{
    
    [Header("Datas")]

        InputAction AttackAction;
        private float RotateMargin=0.2f,RayRange=0.5f;
        [SerializeField] private LayerMask GroundLayerMask;
        [SerializeField] private bool isGrounded=true;

    [Header("Components")]

        [SerializeField] private Transform Base;

    //SETTERS

    //GETTERS

    //ESSENTIALS

        public void Start()
        {

            EventManager.instance.JumpEvent.AddListener(Jump);
            AttackAction=InputSystem.actions.FindAction("Attack");

        }

        public void Update()
        {


            if(AttackAction.IsPressed())
            {

                UpdateAnimation(ISATTACKING);

            }

            Debug.DrawLine(Base.position, Base.position+Vector3.down*RayRange,Color.red);
            if(Physics2D.Linecast(Base.position, Base.position+Vector3.down*RayRange,GroundLayerMask))
            {

                Land();

            }

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

        public void Land()
        {

            UpdateAnimation(ISIDLE);
            CharacterAnimator.SetBool("isLanding",true);
            isGrounded=true;

        }

}