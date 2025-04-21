using System.IO;
using UnityEngine;

public class CaveRock : MonoBehaviour
{

    [SerializeField] private GameObject[] RockType;
    [SerializeField] private Rigidbody2D RockBody;
    private GameObject Body;
    private Vector3 Origin;
    private float seed;

    public void Awake()
    {
        
        Body=Instantiate(GetRockType(),this.transform);

    }

    public void OnEnable()
    {

        RockBody.gravityScale=0;
        Origin=this.transform.position;
        seed=GenerateSeed();

    }

    public void OnDisable()
    {

        RockBody.gravityScale=0;
        this.transform.position=Origin;

    }

    public void Update()
    {
        
        if(isFalling())
        {

            RockBody.gravityScale=2;

        }

    }

    private GameObject GetRockType()
    {

        return RockType[Random.Range(0,RockType.Length)];

    }

    private bool isFalling()
    {

        return Random.Range(1,99999)==seed;

    }

    private float GenerateSeed()
    {

        return Random.Range(1,99999);

    }

}
