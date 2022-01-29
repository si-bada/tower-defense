using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    #region static
    public static BuildingManager sIntance;
    #endregion

    #region Script Parameters
    public GameObject MachineGunTurretPrefab;
    public GameObject LaserBeamTurretPrefab;
    public GameObject MissileLauncherTurretPrefab;
    #endregion

    #region Properties
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerManager.sIntance.Money >= turretToBuild.Cost; } }
    #endregion

    #region Fields
    private TurretInfo turretToBuild;
    #endregion


    #region Unity Methods
    private void Awake()
    {
        if (sIntance != null)
            sIntance = null;
        sIntance = this;
    }
    #endregion

    #region Methods

    public void SetTurretToBuild(TurretInfo turretType)
    {
        turretToBuild = turretType;
    }
    public void BuildTurretOn(Stone stone)
    {
        if(PlayerManager.sIntance.Money < turretToBuild.Cost)
        {
            Debug.LogWarning("not enough money");
        }
        else
        {
            if(turretToBuild != null)
            {
                PlayerManager.sIntance.SubMoney(turretToBuild.Cost);
                GameObject newTurret = Instantiate(turretToBuild.Prefab, stone.GetBuildPosition(), Quaternion.identity);
                stone.turret = newTurret;
            }
        }
    }
    #endregion
}
