using UnityEngine;

public class Character : MonoBehaviour
{

    [Header("Character Data")]

        [SerializeField] protected int CurrentLives,MaxLives;
        [SerializeField] public enum DamageType{Base,Lethal,Final}
        

    [Header("Character Component")]

        [SerializeField] private Transform fillingComponent;


    //SETTERS

        protected void SetLives(int LivesToTake){CurrentLives=LivesToTake;}//Setter For CurrentLives

    //GETTERS

        public int GetLives(){return CurrentLives;}//Getter For CurrentLives

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

        public virtual void TakeDamage(DamageType TypeOfDamageTaken)
        {

            switch(TypeOfDamageTaken)
            {

                case DamageType.Base :

                    LoseLive(1);

                    break;

                case DamageType.Lethal :

                    LoseLive(1);

                    break;

                default :

                    break;

            }

        }

}