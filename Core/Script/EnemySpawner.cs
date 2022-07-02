using UnityEngine;

public class EnemySpawner : MonoBehaviour
{  
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private bool spawnEnemyOnStart;
    [SerializeField]
    private Timer respawnCoolDown;
    private GameObject enemyInstance;
    private Vector2 spawnPoint;

    //Spawnea un primer enemigo de quererse asi
    private void Start()
    {
        if(spawnEnemyOnStart){
            spawnPoint = new Vector2(this.transform.position.x, this.transform.position.y + enemy.transform.localScale.y / 2);
            spawnEnemy();
        }

    }

    //Si no se detecta instancia del enemigo asignado y no hay CD spawnea un nuevo enemigo
    //Se puede expandir para agregar mas condiciones sobrescribiendolo
    public virtual void Update()
    {
        if(!enemyInstance && respawnCoolDown.canDoAction()){
            spawnEnemy();
        }
    }

    //Instancia un nuevo enemigo
    //Sobreescribir si se desea por ejemplo varios enemigos desde el mismo spawn y agregarlos a una lista
    public virtual void spawnEnemy(){
        enemyInstance = Instantiate(this.enemy, this.spawnPoint, Quaternion.identity);
        respawnCoolDown.actionUsed();
    }
}
