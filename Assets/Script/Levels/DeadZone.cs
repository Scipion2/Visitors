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

        if(other.gameObject.tag=="NPC")
        {

            other.gameObject.GetComponent<NPC>().TakeDamage(Character.DamageType.Final);

        }

    }

}
