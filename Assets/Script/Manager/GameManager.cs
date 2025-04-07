using UnityEngine;

public class GameManager : MonoBehaviour
{
   

    [Header("Game Component")]
    [Space(2)]

        [SerializeField] private Player playerPrefab,player;
        [SerializeField] private Camera MainCamera;
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

        LevelManager.instance.Launch();
        Invoke("LaunchGame",1f);

    }

    public void LaunchGame()
    {

        UIManager.instance.OnGameStart();
        player=Object.Instantiate(playerPrefab, LevelManager.instance.GetCurrentSpawn().position,Quaternion.identity);
        MainCamera.transform.SetParent(playerPrefab.gameObject.transform);
        MainCamera.transform.Translate(playerPrefab.gameObject.transform.position);

    }

    public void Defeat()
    {

        //

    }
   
}
