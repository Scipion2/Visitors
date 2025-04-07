using UnityEngine;

public class Character : MonoBehaviour
{

    [Header("Character Data")]

        [SerializeField] private int CurrentLives,MaxLives;
        

    [Header("Character Component")]

        [SerializeField] private Transform fillingComponent;


    //SETTERS

        protected void SetLives(int LivesToTake){CurrentLives=LivesToTake;}//Setter For CurrentLives

    //GETTERS

    //ESSENTIALS

        public void Awake()
        {

            SetLives(MaxLives);

        }

    //DATA GESTURE

        protected bool LoseLive(int LiveLost)
        {

            CurrentLives-=LiveLost;
            return CurrentLives<=0 ? true : false;

        }

        protected void Death()
        {

            GameManager.instance.Defeat();
            Destroy(this.gameObject);

        }

}