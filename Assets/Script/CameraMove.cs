using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform Target;

    //GETTER

    //SETTER

        public void SetTarget(Transform SRC){Target=SRC; this.transform.position=Target.position;}//Setter For Target

    //ESSENTIAL

    public void Update()
    {

        if(Target!=null)
        {

            transform.Translate(Target.position-transform.position);

        }
            

    }

}
