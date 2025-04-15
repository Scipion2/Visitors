using UnityEngine;

public class UIManager : MonoBehaviour
{
    
    [Header("UI Components")]
    [Space(2)]

        [SerializeField] private Transform UIDisplayer;
        [SerializeField] private GameObject PlayerUIPrefab;
        [SerializeField] private PlayerUI CurrentPlayerUI;
        [SerializeField] private GameObject LoseWindowPrefab;
        [SerializeField] private GameObject LoseWindow;
        [SerializeField] private TipsWindow TipsWindowPrefab, CurrentTipsWindow;
        [SerializeField] private GameObject PauseWindowPrefab;
        [SerializeField] private GameObject CurrentPauseWindow;

    //GETTERS

    //SETTERS

    //ESSENTIALS

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

    //DISPLAYERS

        public void PauseWindowDisplay(bool isDisplayable)
        {

            if(CurrentPauseWindow==null)
            {

                CurrentPauseWindow=Instantiate(PauseWindowPrefab);

            }

            CurrentPauseWindow.SetActive(isDisplayable);

        }

        public void DisplayTipWindow(string Message)
        {

            if(CurrentTipsWindow==null)
            {

                CurrentTipsWindow=Instantiate(TipsWindowPrefab);

            }else
            {

                CurrentTipsWindow.gameObject.SetActive(true);

            }

            CurrentTipsWindow.SetMessage(Message);

        }

        private void DisplayPlayerUI(bool isDisplayable)
        {

            if(CurrentPlayerUI==null)
            {

                CurrentPlayerUI=Instantiate(PlayerUIPrefab,UIDisplayer).GetComponent<PlayerUI>();

            }

            CurrentPlayerUI.gameObject.SetActive(isDisplayable);

        }

        public void DisplayLoseWindow(bool isDisplayable)
        {

            if(LoseWindow==null)
            {

                LoseWindow=Instantiate(LoseWindowPrefab,UIDisplayer);

            }

            LoseWindow.SetActive(isDisplayable);

        }

    //PLAYER UI

        public void OnGameStart()
        {

            DisplayPlayerUI(true);
            Invoke("InitUI",0.1f);

        }

        public void OnGameEnd()
        {

            DisplayPlayerUI(false);

        }

        private void initPlayerUI()
        {

            DisplayPlayerUI(true);
            CurrentPlayerUI.Initialize(GameManager.instance.GetPlayerLives());

        }

        public void UpdateLives(int NewLivesAmount)
        {

            CurrentPlayerUI.UpdateLives(NewLivesAmount);

        }

        public void InitUI()
        {

            EmptyAll();
            initPlayerUI();

        }

        public void EmptyAll()
        {

            CurrentPlayerUI.ClearUI();

        }

}