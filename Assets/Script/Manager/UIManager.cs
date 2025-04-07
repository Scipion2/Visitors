using UnityEngine;

public class UIManager : MonoBehaviour
{
    
    [Header("UI Components")]
    [Space(2)]

        [SerializeField] private Transform UIDisplayer;
        [SerializeField] private GameObject PlayerUIPrefab,PlayerUI;

    public static UIManager instance;
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

    public void OnGameStart()
    {

        DisplayPlayerUI(true);
        initPlayerUI();

    }

    public void OnGameEnd()
    {

        DisplayPlayerUI(false);

    }

    private void DisplayPlayerUI(bool isDisplayable)
    {

        if(PlayerUI==null)
        {

            PlayerUI=Instantiate(PlayerUIPrefab,UIDisplayer);

        }

        PlayerUI.SetActive(isDisplayable);

    }

    private void initPlayerUI()
    {

        //

    }

}
