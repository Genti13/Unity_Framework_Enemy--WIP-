using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPanel : MonoBehaviour
{
    #region ListaDeScrips
    [HideInInspector]
    public int codeIA = 0;
    [HideInInspector]
    public List<string> listOfIA = new List<string>(new string[] { "Rango", "Melee", "Estatico" });
    [HideInInspector]
    public Dictionary<int, Type> listOfScript = new Dictionary<int, Type>
    {
        {0, typeof(EnemyType_Range)}

    };
    #endregion

    #region IAAtaques
    [HideInInspector]
    public Bullet bullet;
    #endregion

    #region Stats
    [HideInInspector]
    public int maxHP;
    [HideInInspector]
    public int speed;
    [HideInInspector]
    public int dmg;
    [HideInInspector]
    public int contactDamage;
    [HideInInspector]
    public float attackRate;
    [HideInInspector]
    public float attackRange;
    [HideInInspector]
    public float detectionRange;
    [HideInInspector]
    #endregion
    private void Start()
    {
        this.gameObject.tag = "Enemy";
        cargaDeScript(typeof(EnemyStats));

        cargaDeStats(this.GetComponent<EnemyStats>());

        cargaDeScript(listOfScript[codeIA]);
        configuracionDeScript(codeIA);

        this.gameObject.AddComponent<Enemy_Ground>();
    }
    private void cargaDeStats(EnemyStats stats)
    {
        if(stats == null){
            return;
        }

        stats.maxHp = new Stat(this.maxHP);
        stats.moveSpeed = new Stat(this.speed);

        stats.dmg = new Stat(this.dmg);
        stats.dmg_contact = new Stat(this.contactDamage);

        stats.attackRate = new Timer(this.attackRate);

        stats.attackRange = this.attackRange;
        stats.detectionRange = this.detectionRange;


    }
    private void cargaDeScript(Type script)
    {
        if (this.GetComponent(script) != null)
            return;
        this.gameObject.AddComponent(script);
    }

    private void configuracionDeScript(int code)
    {
        switch (code)
        {
            case 0:
                this.GetComponent<EnemyType_Range>().setBullet(this.bullet);
                break;
        }
    }


}
