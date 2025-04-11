using UnityEngine;

public class BlobTutoTriger : EventTriger
{
    
    [Header("Components")]
    [Space(2)]

        [SerializeField] private NPC TutoBlob;

        public void Awake()
        {

            Message="<b>Beware <color=blue>Visitor</color>!</b>\nThis world contain many dangers.\nLike this <color=red>slime</color>.\n";

        }

        public void Event()
        {

            //TutoBlob.CharacterController.

        }

}
