using UnityEngine;
using TMPro;

public class TipsWindow : MonoBehaviour
{
    
    [Header("Components")]
    [Space(2)]

        [SerializeField] private TextMeshProUGUI Message;

    //

        public void SetMessage(string TipsToDisplay)
        {

            Message.text=TipsToDisplay;

        }

        public void Close()
        {

            Time.timeScale=1;
            Destroy(this.gameObject);

        }

}
