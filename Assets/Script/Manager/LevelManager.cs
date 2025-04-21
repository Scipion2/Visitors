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
        [SerializeField] private int CurrentMaxLevel=0;

    //GETTERS

        public Transform GetCurrentSpawn(){return CurrentSpawn;}//Getter For CurrentSpawn

    //SETTERS

        public void SetCurrentSpawn(Transform SRC){CurrentSpawn=SRC;}//Setter For CurrentSpawn
        public void SetLevelDatas(Level SRC){LevelDatas=SRC; GameManager.instance.SpawnPlayer();}//Setter For LevelDatas

    //ESSENTIALS

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

        public void Start()
        {

            if(PlayerPrefs.HasKey("MaxLevel"))
                CurrentMaxLevel=PlayerPrefs.GetInt("MaxLevel");

        }

        [ContextMenu("Reset Player Prefs")]
        public void ResetSave()
        {

            PlayerPrefs.DeleteAll();

        }

    //

        public void Launch()
        {

            SceneManager.LoadScene(Levels[CurrentMaxLevel]);
            CurrentLevel=CurrentMaxLevel;

        }

        public void UnlockNextLevel()
        {

            CurrentLevel++;

        }

        public void GoToNextLevel()
        {

            
            if(CurrentLevel>CurrentMaxLevel)
            {

                CurrentMaxLevel=CurrentLevel;
                PlayerPrefs.SetInt("MaxLevel",CurrentMaxLevel);

            }

            SceneManager.LoadScene(Levels[CurrentLevel]);

        }

        public void ResetLevel()
        {

            CurrentSpawn=LevelDatas.Reset();

        }

}