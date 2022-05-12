using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;
    [SerializeField] GameObject standartTurretPrefab;
    [SerializeField] GameObject missleLauncherPrefrab;
    [SerializeField] GameObject buildEffect;
    [SerializeField] PlayerStats playerStats;
    TurretBluePrint turretToBuild;
    public bool CanBuild { get { return turretToBuild != null; } private set { } }
    public bool HasMoney { get { return playerStats.Money >= turretToBuild.Cost; } private set { } }

    void Awake()
    {
        Instance = this;
    }
    public void BuildTurretOn(Node node)
    {
        if (playerStats.Money < turretToBuild.Cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }
        playerStats.DecreaseMoney(turretToBuild.Cost);
        GameObject turret = (GameObject)Instantiate(turretToBuild.Prefab, node.GetBuildPosition(), Quaternion.identity);
        node.SetTurret(turret);
        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        Debug.Log("Turret build! Money left " + playerStats.Money);
    }
    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;
    }
}