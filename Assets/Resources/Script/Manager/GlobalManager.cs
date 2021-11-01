using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��Ϸȫ�ֹ�����
/// </summary>
public class GlobalManager : Singleton<GlobalManager>
{
    /// <summary>
    /// ��ǰ�ؿ�
    /// </summary>
    public static int LevelNumber = 1;
    /// <summary>
    /// ÿ�ع���������������
    /// </summary>
    public static float LevelCountMultiplier = 1.0f;
    /// <summary>
    /// ÿ�ع���HP��������
    /// </summary>
    public static float LevelHPMultiplier = 1.0f;
    /// <summary>
    /// ÿ�ع����ƶ��ٶ���������
    /// </summary>
    public static float LevelMoveSpeedMultiplier = 1.0f;

    public static float PlayerHP = 500f;

    /// <summary>
    /// ���������˺�
    /// </summary>
    public void OnChangePlayerHP(float value) 
    {
        PlayerHP = PlayerHP + value >= 0 ? PlayerHP + value : 0;
        print(PlayerHP);
    }
}
