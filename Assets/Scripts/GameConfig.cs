using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Configuration")]
[System.Serializable]
public class GameConfig : ScriptableObject
{
    #region Script Parameters
    public TurretDamageConfig[] DamageConfig;
    #endregion

    #region Methods
    public int GetHitDamage(EnemyType enemy, TurretType type)
    {
        if(type == TurretType.MachineGun)
        {
            if(enemy == EnemyType.Normal)
            {
                return DamageConfig[0].enemies[0].damageTaken;
            }
            else if(enemy == EnemyType.Strong)
            {
                return DamageConfig[0].enemies[1].damageTaken;
            }
            else
            {
                return DamageConfig[0].enemies[2].damageTaken;
            }
        }
        else if(type == TurretType.MissleLauncher)
        {
            if (enemy == EnemyType.Normal)
            {
                return DamageConfig[1].enemies[0].damageTaken;
            }
            else if (enemy == EnemyType.Strong)
            {
                return DamageConfig[1].enemies[1].damageTaken;
            }
            else
            {
                return DamageConfig[1].enemies[2].damageTaken;
            }
        }
        else
        {
            if (enemy == EnemyType.Normal)
            {
                return DamageConfig[2].enemies[0].damageTaken;
            }
            else if (enemy == EnemyType.Strong)
            {
                return DamageConfig[2].enemies[1].damageTaken;
            }
            else
            {
                return DamageConfig[2].enemies[2].damageTaken;
            }
        }
    }
    #endregion
}

[System.Serializable]
public struct TurretDamageConfig
{
    public TurretType type;
    public List<Enemies> enemies;
}

[System.Serializable]
public struct Enemies
{
    public EnemyType enemy;
    public int damageTaken;
}
