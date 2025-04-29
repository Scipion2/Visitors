using System.Collections.Generic;
using UnityEngine;

public class CaveGenerator : MonoBehaviour
{
    
    [SerializeField] private CaveRock CaveRockPrefab;
    [SerializeField] private float CaveRockLength;
    [SerializeField] private List<CaveRock> FloorComponent=new List<CaveRock>();
    [SerializeField] private CaveGround CaveGroundPrefab;
    [SerializeField] private float CaveGroundLength;
    [SerializeField] private List<CaveGround> GroundComponent=new List<CaveGround>();
    [SerializeField] private Transform UpperRightLimit,UpperLeftLimit,LowerRightLimit,LowerLeftLimit;
    private int CaveFloorStages=5;

    public void OnEnable()
    {
        
        SpawnGround();
        SpawnFloor();

    }

    [ContextMenu("Spawn Ground")]
    private void SpawnGround()
    {

        float y=LowerLeftLimit.position.y;

        for(float i=LowerLeftLimit.position.x;i<=LowerRightLimit.position.x;i+=CaveGroundLength)
        {

            CaveGround Temp=Instantiate(CaveGroundPrefab,this.transform);
            Temp.transform.position=new Vector3(i,y,0);
            GroundComponent.Add(Temp);

        }

    }

    [ContextMenu("Spawn Floor")]
    private void SpawnFloor()
    {

        float y=UpperLeftLimit.position.y;
        for(;y<UpperLeftLimit.position.y+CaveFloorStages*CaveRockLength;y+=CaveRockLength)
        {

            for(float x=UpperLeftLimit.position.x-CaveRockLength; x<=UpperRightLimit.position.x+CaveRockLength;x+=CaveRockLength)
            {

                CaveRock Temp=Instantiate(CaveRockPrefab,this.transform);
                Temp.transform.position=new Vector3(x,y,0);
                FloorComponent.Add(Temp);

            }


        }

    }

}
