using UnityEngine;

public class GameManager : MonoBehaviour
{
   

    [Header("Game Component")]
    [Space(2)]

        [SerializeField] private Player playerPrefab,player;
        [SerializeField] private CameraMove MainCamera;

    //SETTER

    //GETTER
        
        public int GetPlayerLives(){return player.GetLives();}//Getter For Player's Lives

    //ESSENTIAL

        public static GameManager instance;
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

    //

    public void Play()
    {

        LevelManager.instance.Launch();
        Invoke("LaunchGame",0.02f);

    }

    public void NextLevel()
    {

        //

    }

    public void LaunchGame()
    {

        UIManager.instance.OnGameStart();
        MainCamera.SetTarget(LevelManager.instance.GetCurrentSpawn());
        player=Object.Instantiate(playerPrefab, LevelManager.instance.GetCurrentSpawn().position,Quaternion.identity);
        MainCamera.SetTarget(player.transform);

    }

    public void Defeat()
    {

        UIManager.instance.DisplayLoseWindow(true);
        UIManager.instance.EmptyAll();

    }

    public void ResetLevel()
    {

        LevelManager.instance.ResetLevel();
        player=Object.Instantiate(playerPrefab, LevelManager.instance.GetCurrentSpawn().position,Quaternion.identity);
        MainCamera.SetTarget(player.transform);
        UIManager.instance.OnGameStart();

    }
   
}