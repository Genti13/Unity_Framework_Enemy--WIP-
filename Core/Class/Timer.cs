using UnityEngine;

[System.Serializable]
public class Timer
{
    //Permite asignar nuevo tiempo mediante codigo a un CD con valores ya asignados desde el editor
    public Timer(float time){
        this.coolDown = time;
    }
    
    [SerializeField]
    private float coolDown;
    private float nextAction = 0.0f;

    //Al usar una accion empieza el CD
    public void actionUsed(){
        this.nextAction = Time.time + this.coolDown;
    }

    //Retorna True si se puede usar una accion
    //Retorna False si no se puede usar una accion
    public bool canDoAction(){
        if(Time.time > this.nextAction){
            return true;
        }
        return false;
    }
}
