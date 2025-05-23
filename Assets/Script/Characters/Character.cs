using UnityEngine;

public class Character : MonoBehaviour
{

    [Header("Character Data")]

        [SerializeField] protected int CurrentLives,MaxLives;
        [SerializeField] public enum DamageType{Base,Lethal,Final}
        [SerializeField] private float DeathAnimationTime;
        

    [Header("Character Component")]

        [SerializeField] public Controler CharacterControler;


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

            CurrentLives=0;
            CharacterControler.UpdateAnimation(Controler.ISDYING);
            Invoke("End",DeathAnimationTime);

        }

        private void End()
        {

            this.gameObject.SetActive(false);

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