using UnityEngine;
using UnityEngine.UI;

public class SettingsChanger : MonoBehaviour
{

    [SerializeField] private Toggle TipsDisplay;

    public void Awake()
    {

        TipsDisplay.isOn=SettingsManager.instance.GetTipsDisplay();

    }
    
    public void ChangeTipsDisplay()
    {

        SettingsManager.instance.SwitchTipsDisplay();

    }

    public void ResetSave()
    {

        LevelManager.instance.ResetSave();

    }


}
