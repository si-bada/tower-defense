using UnityEngine;
public class TurretShop : MonoBehaviour
{
    #region Script Parameters
    public TurretInfo MachineGun;
    public TurretInfo MisslbeLauncher;
    public TurretInfo LaserBeam;
    #endregion

    #region Fields
    private BuildingManager buildingManager;
    #endregion

    #region Unity Methods
    private void Start()
    {
        buildingManager = BuildingManager.sIntance;
    }
    #endregion

    #region Methods
    public void SelectMachineGun()
    {
        buildingManager.SetTurretToBuild(MachineGun);
    }
    public void SelectLaserBeam()
    {
        buildingManager.SetTurretToBuild(LaserBeam);
    }
    public void SelectMissileLauncher()
    {
        buildingManager.SetTurretToBuild(MisslbeLauncher);
    }
    #endregion
}
