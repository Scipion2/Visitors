using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScrollBar : MonoBehaviour
{
  
    [SerializeField] private Slider slider;
    [SerializeField] private Toggle IsOn;
    [SerializeField] private AudioManager.AudioTarget AudioToChange;
    [SerializeField] private TextMeshProUGUI Label;

    void Awake()
    {

        slider.value=AudioManager.instance.GetAudioData(AudioToChange);
        IsOn.isOn=slider.value!=0;
        Label.text=(slider.value*100).ToString()+"%";

    }

    public void UpdateBar()
    {

        UpdateAudio();

    }

    public void Mute()
    {

        slider.value=0;
        IsOn.isOn=false;

        UpdateAudio();

    }

    public void UnMute()
    {

        IsOn.isOn=true;
        slider.value=0.1f;

        UpdateAudio();

    }

    public void OnSwitch()
    {

        if(IsOn.isOn)
            UnMute();
        else
            Mute();

    }

    private void UpdateAudio()
    {

        AudioManager.instance.UpdateVolume(AudioToChange,IsOn.isOn,slider.value);
        Label.text=(slider.value*100).ToString()+"%";

    }


}
