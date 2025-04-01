using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : Controler
{
    
    [Header("Datas")]

        InputAction AttackAction;
        private float RotateMargin=0.2f;
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

            if(!isGrounded)
            {

                //

            }

        }


    //LISTENERS

        public void Jump()
        {

            CharacterMovement.Jump();
            UpdateAnimation(ISJUMPING);
            isGrounded=false;

        }

}