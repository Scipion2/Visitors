using UnityEngine;

public class PauseButton : MonoBehaviour
{
    
    public void Pause()
    {

        Time.timeScale=0;
        UIManager.instance.PauseWindowDisplay(true);

    }

}
