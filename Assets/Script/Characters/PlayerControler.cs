using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : Controler
{
    
    [Header("Datas")]

        InputAction AttackAction;
        private float RotateMargin=0.2f,RayRange=0.5f;
        private LayerMask GroundLayerMask;
        private bool isGrounded=true;

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

            RaycastHit HitInfo;
            Debug.DrawLine(Base.position, Base.position+Vector3.down*RayRange,Color.red);
            if(!isGrounded && Physics.Linecast(Base.position, Base.position+Vector3.down*RayRange,out HitInfo,GroundLayerMask))
            {

                Land();

            }

        }


    //LISTENERS

        public void Jump()
        {

            CharacterMovement.Jump();
            CharacterAnimator.SetBool("isLanding",false);
            UpdateAnimation(ISJUMPING);
            isGrounded=false;

        }

        public void Land()
        {

            UpdateAnimation(ISIDLE);
            CharacterAnimator.SetBool("isLanding",true);
            isGrounded=true;

        }

}