using UnityEngine;

public class CaveGround : MonoBehaviour
{
    
    [SerializeField] private Animator GroundAnimator;
    [SerializeField] private Rigidbody2D GroundBody;
    [SerializeField] private float FallDelay;
    [SerializeField] private Vector3 Origin;

    public void OnEnable()
    {
        
        GroundBody.gravityScale=0;
        Origin=this.transform.position;

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.collider.gameObject.tag!="CaveGround")
        {

            //GroundAnimator.SetBool("isShaking",true);
            Invoke("Fall",FallDelay);

        }
        
    }

    private void Fall()
    {

        GroundBody.gravityScale=2;

    }

    public void OnDisable()
    {

        GroundBody.gravityScale=0;
        this.transform.position=Origin;

    }

}
