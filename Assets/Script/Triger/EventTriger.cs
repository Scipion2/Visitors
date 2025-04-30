using UnityEngine;

public class EventTriger : MonoBehaviour
{
    
    [Header("Datas")]
    [Space(2)]

        [SerializeField] protected string Message;
        [SerializeField] protected float EventDelay=5f;
        private bool isAlreadyTrigered=false;

    //ESSENTIALS

        public void OnTriggerEnter2D(Collider2D other)
        {

            if(!isAlreadyTrigered)
            {

                if(other.gameObject.tag=="Player")
                {

                    isAlreadyTrigered=true;
                    
                    if(SettingsManager.instance.GetTipsDisplay())
                    {

                        Time.timeScale=0.3f;
                        UIManager.instance.DisplayTipWindow(Message);

                    }
                    Invoke("Event",EventDelay);

                }
                

            }

        }

        public void Event()
        {}

}
