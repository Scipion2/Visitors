using UnityEngine;

public class NPC : Character
{
    
    protected float BoundSize;
    [SerializeField] private Collider2D NPCCollider;

    public void Start()
    {

        BoundSize=NPCCollider.bounds.extents.x;

    }

}
