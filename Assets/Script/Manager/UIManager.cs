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
        [SerializeField] private DialogDisplayer DialogDisplayerPrefab;
        [SerializeField] private DialogDisplayer CurrentDialogDisplayer;
        [SerializeField] private GameObject WinningWindowPrefab;
        [SerializeField] private GameObject CurrentWinningWindow;

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

        public void Start()
        {

            DisplayDialogDisplayer(false);

        }


    //DISPLAYERS

        public void DisplayWinningWindow(bool isDisplayable)
        {

            if(CurrentWinningWindow==null)
            {

                CurrentWinningWindow=Instantiate(WinningWindowPrefab,UIDisplayer);

            }

            CurrentWinningWindow.SetActive(isDisplayable);

        }

        public void DisplayDialogDisplayer(bool isDisplayable)
        {


            if(CurrentDialogDisplayer==null)
            {

                CurrentDialogDisplayer=Instantiate(DialogDisplayerPrefab,this.transform);

            }

            CurrentDialogDisplayer.gameObject.SetActive(isDisplayable);

            if(isDisplayable)
                Time.timeScale=0;
            else
                Time.timeScale=1;

        }

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

        public void DisplayPlayerUI(bool isDisplayable)
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

        public void DisplayTalkButton(bool isDisplayable)
        {

            CurrentPlayerUI.DisplayTalkButton(isDisplayable);

        }

    //DIALOG GESTURE

        public void InitializeDialog(Message[] SRC)
        {

            CurrentDialogDisplayer.SetDialogToDisplay(SRC);

        }

}