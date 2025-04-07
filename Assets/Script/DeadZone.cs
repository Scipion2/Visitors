using UnityEngine;

public class DeadZone : MonoBehaviour
{

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag=="Player")
        {

            Player temp=collision.gameObject.GetComponent<Player>();
            temp.LoseLive();

        }

    }

}
