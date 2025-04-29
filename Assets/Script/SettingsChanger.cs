using UnityEngine;

public class SettingsChanger : MonoBehaviour
{
    
    public void ChangeTipsDisplay()
    {

        SettingsManager.instance.SwitchTipsDisplay();

    }

    public void ResetSave()
    {

        LevelManager.instance.ResetSave();

    }

}
