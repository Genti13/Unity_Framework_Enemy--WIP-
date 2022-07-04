using UnityEngine;

public class Enemy_Ground : Enemy_Movement
{
    private void Update()
    {
        if (PlayerOnDetectionRange(this.player) && !PlayerOnAttackRange(this.player))
        {
            ChasePlayer(this.player);
        }
    }
    public override void ChasePlayer(GameObject player)
    {
        base.ChasePlayer(player);

        if (Mathf.Abs(player.transform.position.x - this.transform.position.x) < 0.5f)
        {
            this.rb.velocity = Vector2.zero;
        }
        else
        {
            if (player.transform.position.x > this.transform.position.x)
            {
                this.rb.velocity = new Vector2(this.stats.moveSpeed.GetValue(), 0f);
            }
            else
            {
                this.rb.velocity = new Vector2(-this.stats.moveSpeed.GetValue(), 0f);
            }
        }


    }
}
