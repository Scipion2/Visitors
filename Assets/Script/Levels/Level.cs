using UnityEngine;

public class Level : MonoBehaviour
{
    
    [Header("Level Components")]
    [Space(2)]

        [SerializeField] private Transform Spawn;
        [SerializeField] private Transform[] CheckPoints;
        [SerializeField] private GameObject[] ObjectOnLevel;
        [SerializeField] private AudioClip LevelMusic;
        
    [Header("Level Datas")]
    [Space(2)]
    
        private int CurrentCheckPoint=-1;

    //GETTERS

    //SETTERS

    //ESSENTIALS

        public void Awake()
        {

            LevelManager.instance.SetCurrentSpawn(Spawn);
            LevelManager.instance.SetLevelDatas(this);

        }

    public void OnEnable()
    {
        
        EventManager.instance.CheckPointEvent.AddListener(UpdateCheckPoint);
        AudioManager.instance.SetAmbiantMusic(LevelMusic);

    }

    public void OnDisable()
    {
        
        EventManager.instance.CheckPointEvent.RemoveListener(UpdateCheckPoint);

    }

    public void UpdateCheckPoint(int CheckPointIndex)
        {

            if(CheckPointIndex>CurrentCheckPoint)
                CurrentCheckPoint=CheckPointIndex;

            LevelManager.instance.SetCurrentSpawn(CheckPoints[CurrentCheckPoint]);

        }

        public Transform Reset()
        {

            CurrentCheckPoint=-1;

            for(int i=0;i<ObjectOnLevel.Length;++i)
            {

                ObjectOnLevel[i].SetActive(true);

            }

            return Spawn;

        }
        
}