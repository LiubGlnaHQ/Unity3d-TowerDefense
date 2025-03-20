using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 40;    //平移速度
    public float zoomSpped = 1000;//缩放速度

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");//水平轴
        float vertical = Input.GetAxisRaw("Vertical");//垂直轴

        float scroll =  Input.GetAxisRaw("Mouse ScrollWheel");

        //按照世界坐标移动摄像机
        transform.Translate(new Vector3(horizontal*speed, -scroll* zoomSpped, vertical*speed) *Time.deltaTime ,Space.World);


    }
}
