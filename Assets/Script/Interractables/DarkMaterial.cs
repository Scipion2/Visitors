using UnityEngine;

public class DarkMaterial : MonoBehaviour
{
    
    [SerializeField] private float DarkMaterialQuantity;

    public void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.tag=="Player")
        {

            EventManager.instance.DarkMaterialEvent.Invoke(DarkMaterialQuantity);
            this.gameObject.SetActive(false);

        }
        

    }

}
