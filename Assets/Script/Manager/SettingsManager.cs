using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    
    private bool TipsDisplay=true;

    //SETTERS

    //GETTERS

        public bool GetTipsDisplay(){return TipsDisplay;}

    public static SettingsManager instance;
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

    public void SwitchTipsDisplay()
    {

        TipsDisplay=!TipsDisplay;

    }

}
