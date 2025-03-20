using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//可被序列化
[Serializable]
public class Wave
{
    public GameObject enemyPrefab;  //这个波次中出现的敌人类型
    public int count;   //数量
    public float rate; //敌人出现的频率
}
