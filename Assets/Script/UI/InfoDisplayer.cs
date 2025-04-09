using UnityEngine;
using TMPro;

public class InfoDisplayer : MonoBehaviour
{
    
    [Header("UI Components")]
    [Space(2)]

        [SerializeField] private TextMeshProUGUI InfoName,InfoValue;
        [SerializeField] private ColorModifier colorModifier;

    //SETTERS

    //GETTERS

    //ESSENTIALS

        public InfoDisplayer(string InfoToDisplay,string InitialValue,bool isColorModifier)
        {

            InfoName.text=InfoToDisplay;
            InfoValue.text=InitialValue;
            colorModifier.isAutoModifier=isColorModifier;

        }

}
