using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

    public class OnLineCastHit : UnityEvent<Collider>{}
    public class OnLineCastHit2D : UnityEvent<Collider2D>{}

public class GroundChecker : MonoBehaviour
{

    [SerializeField] private Transform Rfoot,Lfoot;
    [SerializeField] private RaycastHit HitInfo;
    [SerializeField] private RaycastHit2D HitInfo2D;
    [SerializeField] private LayerMask Floor;
    [SerializeField] private bool is3D=true;


    //EVENTS
    public static OnLineCastHit onLineCastHit=new OnLineCastHit();
    public static OnLineCastHit2D onLineCastHit2D=new OnLineCastHit2D();
    
    // Update is called once per frame
    void FixedUpdate()
    {

        if(is3D)
            Checker3D();
        else
            Checker2D();

    }

    private void Checker2D()
    {

        if(Rfoot!=null)
        {

            Debug.DrawLine(this.transform.position,Rfoot.position,Color.red);
        
            if(HitInfo2D=Physics2D.Linecast(this.transform.position,Rfoot.position,Floor))
            {

                onLineCastHit2D.Invoke(HitInfo2D.collider);

            }

        }else
            Debug.Log("Right Foot Not Assigned For "+this);

        if(Lfoot!=null)
        {

             Debug.DrawLine(this.transform.position,Lfoot.position,Color.red);

            if(HitInfo2D=Physics2D.Linecast(this.transform.position,Lfoot.position,Floor))
            {


                onLineCastHit2D.Invoke(HitInfo2D.collider);

            }

        }else
            Debug.Log("Left Foot Not Assigned For "+this);

    }

    private void Checker3D()
    {

        if(Rfoot!=null)
        {

            Debug.DrawLine(this.transform.position,Rfoot.position,Color.red);
        
            if(Physics.Linecast(this.transform.position,Rfoot.position,out HitInfo,Floor))
            {

                onLineCastHit.Invoke(HitInfo.collider);

            }

        }else
            Debug.Log("Right Foot Not Assigned For "+this);

        if(Lfoot!=null)
        {

             Debug.DrawLine(this.transform.position,Lfoot.position,Color.red);

            if(Physics.Linecast(this.transform.position,Lfoot.position,out HitInfo,Floor))
            {


                onLineCastHit.Invoke(HitInfo.collider);

            }

        }else
            Debug.Log("Left Foot Not Assigned For "+this);

    }

}
