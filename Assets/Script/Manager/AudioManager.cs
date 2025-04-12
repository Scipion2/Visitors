using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    [Header("Audio Components")]
    [Space(2)]

        [SerializeField] private AudioSource GlobalAudioSource;
        [SerializeField] private AudioClip ButtonPressedAudio,ButtonReleasedAudio;

    [Header("Audio Data")]
    [Space(2)]

        [SerializeField] private float AudioVolume=1f;
        public enum AudioName{ButtonDown,ButtonUp}
        

    //GETTERS

    //SETTERS

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
        
        GlobalAudioSource.volume = AudioVolume;

    }

    //

    public void PlayAudio(AudioName AudioToplay)
    {

        switch(AudioToplay)
        {

            case AudioName.ButtonUp :

                GlobalAudioSource.clip=ButtonReleasedAudio;
                break;

            case AudioName.ButtonDown :

                GlobalAudioSource.clip=ButtonPressedAudio;
                break;

            default :

                break;

        }

        GlobalAudioSource.Play();

    }

}
