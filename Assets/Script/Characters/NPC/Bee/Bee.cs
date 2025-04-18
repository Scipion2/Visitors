using UnityEngine;

public class Bee : NPC
{
    
    public void OnCollisionEnter2D(Collision2D other)
    {

        if(other.collider.gameObject.tag=="Player")
        {

            other.collider.GetComponent<Player>().TakeDamage(DamageType.Base);

        }

    }

}
