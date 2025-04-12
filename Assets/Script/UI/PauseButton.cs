using UnityEngine;

public class PauseButton : Buttons
{
    
    public void Pause()
    {

        Time.timeScale=0;
        UIManager.instance.PauseWindowDisplay(true);

    }

}
