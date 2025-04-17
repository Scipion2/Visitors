using UnityEngine;
using TMPro;

public class DialogDisplayer : MonoBehaviour
{
    
    [SerializeField] private Message[] DialogToDisplay;
    [SerializeField] private TextMeshProUGUI DialogContent,DialogHeader;
    [SerializeField] private int CurrentMessage=-1;

    //GETTERS

    //SETTERS

        public void SetDialogToDisplay(Message[] SRC){DialogToDisplay=SRC; DisplayDialog();}//Setter For DialogToDisplay

    //ESSENTIALS

        public void Awake()
        {

            DialogToDisplay=new Message[1];

        }

        public void DisplayDialog()
        {

            if(-1==CurrentMessage)
            {

                CurrentMessage=0;
                DialogHeader.text=DialogToDisplay[CurrentMessage].Talker;
                DialogContent.text=DialogToDisplay[CurrentMessage].Content;

            }else if(CurrentMessage<DialogToDisplay.Length-1)
            {

                CurrentMessage++;
                DialogHeader.text=DialogToDisplay[CurrentMessage].Talker;
                DialogContent.text=DialogToDisplay[CurrentMessage].Content;

            }else
            {

                CurrentMessage=-1;
                UIManager.instance.DisplayPlayerUI(true);
                UIManager.instance.DisplayDialogDisplayer(false);

            }


        }

}
