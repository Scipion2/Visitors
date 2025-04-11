using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    
    [Header("UI Components")]
    [Space(2)]

        [SerializeField] private GameObject LifeDisplayPrefab;
        [SerializeField] private LifeDisplay[] Lifes;
        [SerializeField] private Transform LifeContainer;

    //SETTERS

    //GETTERS

    //ESSENTIALS

        public void Initialize(int LifeNumber)
        {

            Lifes=new LifeDisplay[LifeNumber];
            Debug.Log(LifeDisplayPrefab);

            for(int i=0;i<LifeNumber;++i)
            {

                Lifes[i]=Instantiate(LifeDisplayPrefab,LifeContainer).GetComponent<LifeDisplay>();
                Lifes[i].Initialize(true);

            }

        }

        public void UpdateLives(int NewLivesAmount)
        {

            Debug.Log(NewLivesAmount+" : "+Lifes.Length);

            if(NewLivesAmount>Lifes.Length)
            {

                LifeDisplay[] temp=new LifeDisplay[NewLivesAmount];

                for(int i=0;i<temp.Length;++i)
                {

                    if(i<Lifes.Length)
                    {

                        temp[i]=Lifes[i];
                        Lifes[i].SetLifeActive();

                    }
                    else
                    {

                        temp[i]=Instantiate(LifeDisplayPrefab,LifeContainer).GetComponent<LifeDisplay>();
                        temp[i].Initialize(true);

                    }


                }

                Lifes=temp;

            }else
            {

                for(int i=0;i<Lifes.Length;++i)
                {

                    if(i<NewLivesAmount)
                        Lifes[i].SetLifeActive();
                    else
                        Lifes[i].SetLifeDown();

                }

            }

        }

}
