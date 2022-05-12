using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] TurretBluePrint standartTurret;
    [SerializeField] TurretBluePrint missileLauncher;
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.Instance;
    }
    public void SelectStandartTurret()
    {
        buildManager.SelectTurretToBuild(standartTurret);
    }
    public void SelectMissleLauncher()
    {
        buildManager.SelectTurretToBuild(missileLauncher);
    }
}