using UnityEngine;

public class EnemyType_Range : MonoBehaviour
{
    public GameObject bullet;
    [SerializeField]
    private Timer fireRate;
    private void Update()
    {
        if(this.fireRate.canDoAction()){
            shoot();
        }
    }

    private void shoot(){
        Instantiate(this.bullet, this.transform.position, Quaternion.identity);
        this.fireRate.actionUsed();
    }
}
