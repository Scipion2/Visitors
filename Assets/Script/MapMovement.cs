using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;

public class MapMovement : MonoBehaviour
{
   
    [SerializeField] private GameObject ActiveMap;
    InputAction FlipMap;
    private float RotateSpeed=1f;

    public void Start()
    {

        FlipMap=InputSystem.actions.FindAction("Flip");
        Input.gyro.enabled=true;

        /*if(!UnityEngine.InputSystem.Gyroscope.current.enabled)
            InputSystem.EnableDevice(UnityEngine.InputSystem.Gyroscope.current);

        //FlipMap=new InputAction();
        FlipMap.AddBinding("<Sensor>/Gyroscope");
        FlipMap.Enable();*/

    }

    public void OnDisable()
    {

        FlipMap.Disable();

    }

    public void Update()
    {

        Flip(FlipMap.ReadValue<Vector2>()*Time.deltaTime*RotateSpeed);
        Flip(Input.gyro.attitude.ToEulerAngles()*Time.deltaTime*RotateSpeed); //X is Up and Down - 

    }

    [ContextMenu("Reverse")]
    public void Reverse()
    {

        ActiveMap.transform.Rotate(0,180,180);

    }

    public void Flip(Vector3 InputValue)
    {

        ActiveMap.transform.Rotate(0,0,InputValue.y);

    }

    [ContextMenu("Flip")]
    public void Flip()
    {

        Vector3 Angle=new Vector3(0,0,5);
        ActiveMap.transform.Rotate(Angle);

    }

}
