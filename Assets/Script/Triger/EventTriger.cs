using UnityEngine;

public class EventTriger : MonoBehaviour
{
    
    [Header("Datas")]
    [Space(2)]

        [SerializeField] protected string Message;

    //ESSENTIALS

        public void OnTriggerEnter2D(Collider2D other)
        {

            if(other.gameObject.tag=="Player")
            {

                UIManager.instance.DisplayTipWindow(Message);
                Invoke("Event",5f);

            }

        }

}
