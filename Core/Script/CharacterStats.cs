using UnityEngine;
///Estadisticas de los personajes, asi como metodos que las alteran
public class CharacterStats : MonoBehaviour
{
    public int currentHp { get; private set; }
    public Stat maxHp;
    public Stat moveSpeed;
    public Stat dmg;
    private void Awake()
    {
        //this.currentHp = this.maxHp.GetValue();
    }

    public void setCurrentHP(int hp){
        this.currentHp = hp;
    }

    private void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(20);
        }*/
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Damage Recibido " + damage + " Vida Restante: " + this.currentHp);
        this.currentHp -= damage;
        if (this.currentHp <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        //Sobrescribir dependiendo el enemigo o jugador
        //Enemigo suelta loot, desaparece
        //Jugador pantalla de GameOver

        //Debug.Log(transform.name + " murio");
    }
}
