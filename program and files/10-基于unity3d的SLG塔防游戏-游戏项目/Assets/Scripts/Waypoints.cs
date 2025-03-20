//ʹ����Щ·���������Ƶ��˵��ƶ�·��
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    //����ģʽ
    public static Waypoints Instance { get; private set; }

    //�洢·�����λ����Ϣ
    private List<Transform> waypointList;

    private void Awake()
    {
        Instance = this;
        Init();
    }

    //��ȡ�Ӷ������� 
    private void Init()
    {
        //
        Transform[] transfroms = transform.GetComponentsInChildren<Transform>();
        waypointList = new List<Transform>(transfroms);
        waypointList.RemoveAt(0);//�Ƴ�����
    }
    //��ȡ·������
    public int GetLength()
    {
        return waypointList.Count;
    }
    //��ȡ·����
    public Vector3 GetWaypoint(int index)
    {
        return waypointList[index].position;
    }
}
