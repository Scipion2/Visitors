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

        }
        
}
