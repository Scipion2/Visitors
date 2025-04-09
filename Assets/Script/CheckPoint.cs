using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    [SerializeField] private int CheckPointIndex;
    
    public void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.tag=="Player")
        {

            EventManager.instance.CheckPointEvent.Invoke(CheckPointIndex);

        }

    }

}
