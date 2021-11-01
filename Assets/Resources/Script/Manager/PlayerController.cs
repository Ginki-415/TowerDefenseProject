using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ҿ�����
/// </summary>
public class PlayerController : Singleton<PlayerController>
{
    /// <summary>
    /// �Ӵ��ƶ��ٶ�
    /// </summary>
    public float CameraMoveSpeed = 10f;

    /// <summary>
    /// ���Ӵ����
    /// </summary>
    private Transform mainCamera;

    private int screenHeight;
    private int screenWidth;

    void Start()
    {
        mainCamera = GameObject.Find("MainCamera").transform;

        screenHeight = Screen.height;
        screenWidth = Screen.width;
        //print(screenWidth + " " + screenHeight);
    }

    void FixedUpdate()
    {
        MoveCamera();
    }

    /// <summary>
    /// �ƶ����
    /// </summary>
    void MoveCamera() 
    {
        Vector3 mousePosition = Input.mousePosition;
        //print(mousePosition);

        Vector3 moveValue = Vector3.zero;

        //����ˮƽ�����ƶ�
        if (mousePosition.x <= 10 && mousePosition.x >= -10)
        {
            moveValue.x = -CameraMoveSpeed;
        }
        else if(mousePosition.x >= screenWidth - 10 && mousePosition.x <= screenWidth + 50)
        {
            moveValue.x = CameraMoveSpeed;
        }

        //������ֱ�����ϵ��ƶ�
        if (mousePosition.y <= 10 && mousePosition.y >= -10)
        {
            moveValue.z = -CameraMoveSpeed;
        }
        else if (mousePosition.y >= screenHeight - 10 && mousePosition.y <= screenHeight + 50)
        {
            moveValue.z = CameraMoveSpeed;
        }

        mainCamera.Translate(moveValue * Time.deltaTime, Space.World);

    }
}
