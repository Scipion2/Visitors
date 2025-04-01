using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;


public class MapMovement : MonoBehaviour
{
   
    [SerializeField] private GameObject ActiveMap;
    private float RotateSpeed=20f,ReverseRange=-1f,ReverseDelay=30f,CurrentDelay=0f;

    void Start()
    {

        Input.gyro.enabled=true;
    }

    public void Update()
    {

        Input.gyro.enabled=true;
        Flip(Input.gyro.enabled ? Input.gyro.rotationRateUnbiased*Time.deltaTime*RotateSpeed : Vector3.zero); //X is Up and Down - 

        if(CurrentDelay>0)
            CurrentDelay--;

    }

    [ContextMenu("Reverse")]
    public void Reverse()
    {

        ActiveMap.transform.Rotate(0,180,180);
        CurrentDelay=ReverseDelay;

    }

    public void Flip(Vector3 InputValue)
    {

        ActiveMap.transform.Rotate(0,0,InputValue.z);

        if(InputValue.x<ReverseRange && CurrentDelay<=0)
            Reverse();

    }

}
