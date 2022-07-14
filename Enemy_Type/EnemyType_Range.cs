using UnityEngine;

public class EnemyType_Range : Enemy_NoDummy
{
    [SerializeField]
    private Bullet bullet;

    private void Update()
    {
        if (this.stats.attackRate.canDoAction() && PlayerOnAttackRange(this.player))
        {
            Attack();
        }
    }
    public override void Attack()
    {
        base.Attack();
        Bullet bullet = Instantiate(this.bullet, this.transform.position, Quaternion.identity);
        bullet.setDamage(this.stats.dmg.GetValue());
    }

    public void setBullet(Bullet bullet){
        this.bullet = bullet;
    }

}
