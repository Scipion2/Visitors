using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    
    [Header("UI Components")]
    [Space(2)]

        [SerializeField] private GameObject LifeDisplayPrefab;
        [SerializeField] private LifeDisplay[] Lifes;
        [SerializeField] private Transform LifeContainer;
        [SerializeField] private Image TankBar;

    //SETTERS

    //GETTERS

    //ESSENTIALS

        public void Awake()
        {

            EventManager.instance.DarkMaterialEvent.AddListener(UpdateTank);

        }

        public void Initialize(int LifeNumber)
        {

            Lifes=new LifeDisplay[LifeNumber];
            TankBar.fillAmount=0;

            for(int i=0;i<LifeNumber;++i)
            {

                Lifes[i]=Instantiate(LifeDisplayPrefab,LifeContainer).GetComponent<LifeDisplay>();
                Lifes[i].Initialize(true);

            }

        }

        public void UpdateTank(float NewAmount)
        {

            TankBar.fillAmount= TankBar.fillAmount+NewAmount>1 ? 1 : TankBar.fillAmount+NewAmount;

        }

        public void UpdateLives(int NewLivesAmount)
        {

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

        public void ClearUI()
        {

            TankBar.fillAmount=0.1f;
            for(int i=0;i<Lifes.Length;++i)
            {

                Destroy(Lifes[i].gameObject);

            }

            Lifes=new LifeDisplay[0];
            Debug.Log(Lifes.Length);

        }

}
