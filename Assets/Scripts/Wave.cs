using UnityEngine;

[CreateAssetMenu(fileName = "Wave")]
[System.Serializable]
public class Wave : ScriptableObject
{
    public GameObject enemy;
    public int count;
    public float rate;
}
