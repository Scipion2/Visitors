using UnityEngine;
using UnityEngine.InputSystem;

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

    public void Start()
    {
        
        InputSystem.EnableDevice(Accelerometer.current);

    }

    //

    public void Play()
    {

        LevelManager.instance.Launch();

    }

    public void NextLevel()
    {

        Object.Destroy(player.gameObject);
        LevelManager.instance.GoToNextLevel();

    }

    public void WinLevel()
    {

        UIManager.instance.DisplayWinningWindow(true);
        UIManager.instance.DisplayPlayerUI(false);
        LevelManager.instance.UnlockNextLevel();

    }


    public void SpawnPlayer()
    {

        MainCamera.SetTarget(LevelManager.instance.GetCurrentSpawn());
        player=Object.Instantiate(playerPrefab, LevelManager.instance.GetCurrentSpawn().position,Quaternion.identity);
        MainCamera.SetTarget(player.transform);
        UIManager.instance.OnGameStart();

    }

    public void Defeat()
    {

        UIManager.instance.DisplayLoseWindow(true);
        UIManager.instance.EmptyAll();
        UIManager.instance.DisplayPlayerUI(false);

    }

    public void ResetLevel()
    {

        LevelManager.instance.ResetLevel();
        player=Object.Instantiate(playerPrefab, LevelManager.instance.GetCurrentSpawn().position,Quaternion.identity);
        MainCamera.SetTarget(player.transform);
        UIManager.instance.OnGameStart();

    }
   
}