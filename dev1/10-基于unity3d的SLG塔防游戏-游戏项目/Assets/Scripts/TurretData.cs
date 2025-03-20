using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//保存炮台相关数据
//炮台预制体，炮台升级预制体，炮台类型，炮台价格，炮台升级价格

[Serializable]
public class TurretData 
{
    public GameObject turretPrefab;
    public int cost;
    public GameObject turretUpgradedPrefab;
    public int costUpgraded;
    public TurretType type;
}

public enum TurretType
{
    StandardTurret,
    MissileTurret,
    LaserTurret
}