using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]
    private int value;

    public int GetValue()
    {
        return this.value;
    }
}
