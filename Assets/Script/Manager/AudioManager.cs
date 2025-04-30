using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    [Header("Audio Components")]
    [Space(2)]

        [SerializeField] private AudioSource MusicAudioSource,UIAudioSource;
        [SerializeField] private AudioClip ButtonPressedAudio,ButtonReleasedAudio;

    [Header("Audio Data")]
    [Space(2)]

        [SerializeField] private float MusicVolume=1f,UIVolume=1f;
        public enum AudioName{ButtonDown,ButtonUp}
        public enum AudioTarget{Music,UI}
        

    //GETTERS

        public float GetAudioData(AudioTarget AudioToGive)
        {

            switch(AudioToGive)
            {

                case AudioTarget.Music :

                    return MusicVolume;

                    break;

                case AudioTarget.UI :

                    return UIVolume;

                    break;

                default :

                    return 0;

                    break;

            }

        }

    //SETTERS

        public void SetAmbiantMusic(AudioClip SRC){MusicAudioSource.clip=SRC;MusicAudioSource.Play();}

    //ESSENTIALS

        public static AudioManager instance;
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

    public void Start()
    {
        
        CheckPlayerPrefs();

        UIAudioSource.volume = UIVolume;
        MusicAudioSource.volume=MusicVolume;

    }

    //

    public void PlayAudio(AudioName AudioToplay)
    {

        switch(AudioToplay)
        {

            case AudioName.ButtonUp :

                UIAudioSource.clip=ButtonReleasedAudio;
                break;

            case AudioName.ButtonDown :

                UIAudioSource.clip=ButtonPressedAudio;
                break;

            default :

                break;

        }

        UIAudioSource.Play();

    }

    public void UpdateVolume(AudioTarget AudioToUpdate,bool isOn,float Volume)
    {

        switch(AudioToUpdate)
        {

            case AudioTarget.Music :

                if(isOn)
                    MusicAudioSource.volume=Volume;
                else
                    MusicAudioSource.volume=0f;

                MusicVolume=MusicAudioSource.volume;

                break;

            case AudioTarget.UI :

                if(isOn)
                    UIAudioSource.volume=Volume;
                else
                    UIAudioSource.volume=0f;

                UIVolume=UIAudioSource.volume;

                break;

            default :

                break;

        }

        UpdatePlayerPrefs();

    }

    public void CheckPlayerPrefs()
    {

        if(PlayerPrefs.HasKey("MusicVolume"))
            MusicVolume=PlayerPrefs.GetFloat("MusicVolume");
        else
            PlayerPrefs.SetFloat("MusicVolume",MusicVolume);

        if(PlayerPrefs.HasKey("UIVolume"))
            UIVolume=PlayerPrefs.GetFloat("UIVolume");
        else
            PlayerPrefs.SetFloat("UIVolume",UIVolume);

    }

    public void UpdatePlayerPrefs()
    {

        PlayerPrefs.SetFloat("MusicVolume",MusicVolume);
        PlayerPrefs.SetFloat("UIVolume",UIVolume);

    }

}
