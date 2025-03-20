using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 40;    //ƽ���ٶ�
    public float zoomSpped = 1000;//�����ٶ�

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");//ˮƽ��
        float vertical = Input.GetAxisRaw("Vertical");//��ֱ��

        float scroll =  Input.GetAxisRaw("Mouse ScrollWheel");

        //�������������ƶ������
        transform.Translate(new Vector3(horizontal*speed, -scroll* zoomSpped, vertical*speed) *Time.deltaTime ,Space.World);


    }
}
