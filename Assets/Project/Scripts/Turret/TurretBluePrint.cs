using UnityEngine;

[System.Serializable]
public class TurretBluePrint
{
    [SerializeField] GameObject prefab;
    [SerializeField] int cost;
    public GameObject Prefab { get { return prefab; } private set { } }
    public int Cost { get { return cost; } private set { } }
}