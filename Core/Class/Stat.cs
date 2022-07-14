using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]
    private int value;

    public Stat(int value){
        this.value = value;
    }

    public int GetValue()
    {
        return this.value;
    }

    public void setValue(int value){
        this.value = value;
    }

}
