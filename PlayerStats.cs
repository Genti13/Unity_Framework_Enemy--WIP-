public class PlayerStats : CharacterStats
{
    public override void Die()
    {
        base.Die();
        print("GAME OVER");
    }
}
