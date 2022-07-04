public class EnemyStats : CharacterStats
{
    public Stat dmg_contact;
    public Timer attackRate;
    public float attackRange;
    public float detectionRange;

    public override void Die()
    {
        base.Die();
        //Hacer Algo
        Destroy(this.gameObject);
    }
}
