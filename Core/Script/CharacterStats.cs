using UnityEngine;

public class CharacterStats : MonoBehaviour {
    public int currentHp{get; private set;}
    public Stat maxHp;
    public Stat speed;
    public Stat dmg;
    private void Awake() {
        this.currentHp = this.maxHp.getValue();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage){
        this.currentHp -= damage;
        if(this.currentHp <= 0){
            Die();
        }
    }

    public virtual void Die(){
        //Sobrescribir dependiendo el enemigo o jugador
        //Enemigo suelta loot, desaparece
        //Jugador pantalla de GameOver
        
        //Debug.Log(transform.name + " murio");
    }
} 
