using UnityEngine;

public class Blob : NPC
{
    
    public void OnCollisionEnter2D(Collision2D other)
    {

        if(other.collider.gameObject.tag=="Player")
        {

            if(other.collider.transform.position.y>transform.position.y && Mathf.Abs(other.collider.transform.position.x-transform.position.x)<=BoundSize)
            {

                Death();

            }else
            {

                other.collider.GetComponent<Player>().TakeDamage(DamageType.Base);

            }

        }

    }

}
