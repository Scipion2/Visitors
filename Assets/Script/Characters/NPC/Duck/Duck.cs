using UnityEngine;

public class Duck : NPC
{
    
    [Header("Datas")]
    [Space(2)]

        [SerializeField] private Message[] Dialog;

    public void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.tag=="Player")
        {

            
            UIManager.instance.DisplayDialogDisplayer(false);
            UIManager.instance.DisplayTalkButton(true);
            UIManager.instance.InitializeDialog(Dialog);

        }
        

    }

    public void OnTriggerExit2D(Collider2D other)
    {

        if(other.gameObject.tag=="Player")
            UIManager.instance.DisplayTalkButton(false);

    }

}
