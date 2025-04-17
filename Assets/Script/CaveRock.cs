using UnityEngine;

public class CaveRock : MonoBehaviour
{

    [SerializeField] private Sprite[] RockSprites;

    public Sprite GetRandomRock()
    {

        return RockSprites[Random.Range(0,RockSprites.Length)];

    }

}
