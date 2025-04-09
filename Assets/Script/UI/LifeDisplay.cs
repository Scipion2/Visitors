using UnityEngine;
using UnityEngine.UI;

public class LifeDisplay : MonoBehaviour
{
    
    [Header("UI Components")]
    [Space(2)]

        [SerializeField] private ColorModifier colorModifier;
        [SerializeField] private Image LifeImage;
        [SerializeField] Color DownColor;

    //SETTERS

        [ContextMenu("Active")] public void SetLifeActive(){colorModifier.isAutoModifier=true;}
        [ContextMenu("Inactive")] public void SetLifeDown(){colorModifier.isAutoModifier=false; LifeImage.color=DownColor;}

    //GETTERS

    //ESSENTIALS

        public void Initialize(bool isColorModifier)
        {

            colorModifier.isAutoModifier=isColorModifier;

        }

}
