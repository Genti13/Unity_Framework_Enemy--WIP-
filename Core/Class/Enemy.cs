using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected GameObject player;
    protected EnemyStats stats;

    public virtual void Start()
    {
        this.player = GameObject.FindGameObjectWithTag("Player");
        this.stats = this.gameObject.GetComponent<EnemyStats>();

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, this.stats.attackRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, this.stats.detectionRange);
    }

    protected bool PlayerOnAttackRange(GameObject player)
    {
        if (Vector2.Distance(player.transform.position, this.transform.position) <= this.stats.attackRange)
        {
            return true;
        }

        return false;
    }

    protected bool PlayerOnDetectionRange(GameObject player)
    {
        if (Vector2.Distance(player.transform.position, this.transform.position) <= this.stats.detectionRange)
        {
            return true;
        }

        return false;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerStats>().TakeDamage(this.GetComponent<EnemyStats>().dmg_contact.GetValue());

        }
    }

}
