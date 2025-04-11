using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    [Header("LevelComponent")]
    [Space(2)]

        [SerializeField] private Transform CurrentSpawn;

    [Header("Levels")]
    [Space(2)]

        [SerializeField] private string[] Levels;
        [SerializeField] private Level LevelDatas;
        [SerializeField] private int CurrentLevel=0;

    //GETTERS

        public Transform GetCurrentSpawn(){return CurrentSpawn;}//Getter For CurrentSpawn

    //SETTERS

        public void SetCurrentSpawn(Transform SRC){CurrentSpawn=SRC;}//Setter For CurrentSpawn
        public void SetLevelDatas(Level SRC){LevelDatas=SRC;}//Setter For LevelDatas

    public static LevelManager instance;
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

    public void Launch()
    {

        SceneManager.LoadScene(Levels[CurrentLevel]/*,LoadSceneMode.Additive*/);

    }

    public void ResetLevel()
    {

        CurrentSpawn=LevelDatas.Reset();

    }

}