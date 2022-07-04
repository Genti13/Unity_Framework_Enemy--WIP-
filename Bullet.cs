using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Vector2 target;
    private GameObject player;
    private int damage;

    private void Start()
    {
        this.player = GameObject.FindGameObjectWithTag("Player");
        this.gameObject.AddComponent(typeof(CircleCollider2D));
        this.gameObject.AddComponent(typeof(Rigidbody2D));

        this.GetComponent<CircleCollider2D>().isTrigger = true;
        this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

        this.target = (player.transform.position - this.transform.position).normalized * speed;

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(target.x, target.y);
    }

    private void Update()
    {
        destroyBullet(20f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Si el bullet pasa por un enemigo lo ignora
        if (other.CompareTag("Enemy") || other.CompareTag("Bullet"))
            return;

        //Compara lo que se esta golpeando con el ID unico del collider del Player
        if (other.GetInstanceID().Equals(this.player.GetComponent<BoxCollider2D>().GetInstanceID()))
        {
            player.GetComponent<PlayerStats>().TakeDamage(damage);
        }
        /*
        if(other.CompareTag("Player")){
            player.GetComponent<PlayerStats>().TakeDamage(10);
        }*/

        destroyBullet();
    }

    private void destroyBullet()
    {
        Destroy(this.gameObject);
    }
    private void destroyBullet(float time)
    {
        Destroy(this.gameObject, time);
    }

    public void setDamage(int damage)
    {
        this.damage = damage;
    }

}

