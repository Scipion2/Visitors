using UnityEngine;

public class Controler : MonoBehaviour
{

    [Header("Components")]

        [SerializeField] protected Animator CharacterAnimator;
        [SerializeField] protected Movement CharacterMovement;
    
    [Header("Datas")]

        [SerializeField] protected float WalkSpeed,RunSpeed;
        public const string ISDYING="isDying",ISHURTED="isHurted",ISMOVINGLEFT="isMovingLeft",ISMOVINGRIGHT="isMovingRight",
                ISJUMPING="isJumping",ISATTACKING="isAttacking",ISIDLE="isIdle",ISINTERRACTING="isInterracting";

    //SETTERS

    //GETTERS

    //ESSENTIALS

        public void Awake()
        {

            UpdateAnimation(ISIDLE);
            
        }        

    //ANIMATOR GESTURE

        public void UpdateAnimation(string AnimationToSet)
        {

            CharacterAnimator.SetBool(ISDYING,ISDYING==AnimationToSet);
            CharacterAnimator.SetBool(ISHURTED,ISHURTED==AnimationToSet);
            CharacterAnimator.SetBool(ISMOVINGLEFT,ISMOVINGLEFT==AnimationToSet);
            CharacterAnimator.SetBool(ISMOVINGRIGHT,ISMOVINGRIGHT==AnimationToSet);
            CharacterAnimator.SetBool(ISJUMPING,ISJUMPING==AnimationToSet);
            CharacterAnimator.SetBool(ISATTACKING,ISATTACKING==AnimationToSet);
            CharacterAnimator.SetBool(ISIDLE,ISIDLE==AnimationToSet);

        }
  
}