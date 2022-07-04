using UnityEngine;
public class Enemy_NoDummy : Enemy
{

    public override void Start()
    {
        base.Start();

        this.gameObject.AddComponent(typeof(BoxCollider2D));
        this.gameObject.AddComponent(typeof(Rigidbody2D));

        this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        this.GetComponent<Rigidbody2D>().gravityScale = 8f;
        this.GetComponent<Rigidbody2D>().freezeRotation = true;
    }
    public virtual void Attack()
    {
        this.stats.attackRate.actionUsed();
    }
}
