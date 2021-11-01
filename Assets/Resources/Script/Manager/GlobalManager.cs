using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏全局管理器
/// </summary>
public class GlobalManager : Singleton<GlobalManager>
{
    /// <summary>
    /// 当前关卡
    /// </summary>
    public static int LevelNumber = 1;
    /// <summary>
    /// 每关怪物数量增量乘数
    /// </summary>
    public static float LevelCountMultiplier = 1.0f;
    /// <summary>
    /// 每关怪物HP增量乘数
    /// </summary>
    public static float LevelHPMultiplier = 1.0f;
    /// <summary>
    /// 每关怪物移动速度增量乘数
    /// </summary>
    public static float LevelMoveSpeedMultiplier = 1.0f;

    public static float PlayerHP = 500f;

    /// <summary>
    /// 对玩家造成伤害
    /// </summary>
    public void OnChangePlayerHP(float value) 
    {
        PlayerHP = PlayerHP + value >= 0 ? PlayerHP + value : 0;
        print(PlayerHP);
    }
}
