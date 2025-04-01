using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    
    public static EventManager instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public UnityEvent JumpEvent;

}
