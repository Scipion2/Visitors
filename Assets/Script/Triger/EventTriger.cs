using UnityEngine;

public class EventTriger : MonoBehaviour
{
    
    [Header("Datas")]
    [Space(2)]

        [SerializeField] protected string Message;
        private bool isAlreadyTrigered=false;

    //ESSENTIALS

        public void OnTriggerEnter2D(Collider2D other)
        {

            if(!isAlreadyTrigered)
            {

                if(other.gameObject.tag=="Player")
                {

                    isAlreadyTrigered=true;
                    Time.timeScale=0;
                    UIManager.instance.DisplayTipWindow(Message);
                    Invoke("Event",5f);

                }
                

            }

        }

        public void Event()
        {}

}
