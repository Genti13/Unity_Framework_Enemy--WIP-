using UnityEngine;

public class Enemy_Movement : Enemy
{
    protected Rigidbody2D rb;

    public override void Start()
    {
        base.Start();

        this.rb = this.GetComponent<Rigidbody2D>();
    }
    public virtual void ChasePlayer(GameObject player){

    }

}
