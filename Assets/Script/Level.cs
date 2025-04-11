using UnityEngine;

public class Level : MonoBehaviour
{
    
    [Header("Level Components")]
    [Space(2)]

        [SerializeField] private Transform Spawn;
        [SerializeField] private Transform[] CheckPoints;
        
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
            EventManager.instance.CheckPointEvent.AddListener(UpdateCheckPoint);

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
            return Spawn;

        }
        
}