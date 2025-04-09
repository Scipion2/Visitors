using UnityEngine;

public class DeadZone : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.tag=="Player")
        {

            Player temp=other.gameObject.GetComponent<Player>();
            temp.TakeDamage(Character.DamageType.Lethal);

        }

    }

}
