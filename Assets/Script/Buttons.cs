using UnityEngine;
using UnityEngine.Events;

public class Buttons : MonoBehaviour
{


    public void Jump()
    {

        EventManager.instance.JumpEvent.Invoke();

    }

}
