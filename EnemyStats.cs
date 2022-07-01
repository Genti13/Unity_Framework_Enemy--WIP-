public class EnemyStats : CharacterStats
{
    public override void Die()
    {
        base.Die();
        //Hacer Algo
        Destroy(this.gameObject);
    }
}
