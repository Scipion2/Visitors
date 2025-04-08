using UnityEngine;

public class DeadZone : MonoBehaviour
{

    public void OnTrigerEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag=="Player")
        {

            Player temp=collision.gameObject.GetComponent<Player>();
            temp.LoseLive();

        }

    }

}
