//使用这些路径点来控制敌人的移动路径
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    //单例模式
    public static Waypoints Instance { get; private set; }

    //存储路径点的位置信息
    private List<Transform> waypointList;

    private void Awake()
    {
        Instance = this;
        Init();
    }

    //获取子对象数组 
    private void Init()
    {
        //
        Transform[] transfroms = transform.GetComponentsInChildren<Transform>();
        waypointList = new List<Transform>(transfroms);
        waypointList.RemoveAt(0);//移除自身
    }
    //获取路径长度
    public int GetLength()
    {
        return waypointList.Count;
    }
    //获取路径点
    public Vector3 GetWaypoint(int index)
    {
        return waypointList[index].position;
    }
}
