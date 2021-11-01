using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 怪物生成器
/// </summary>
public class MonsterCreator : Singleton<MonsterCreator>
{
    /// <summary>
    /// 基础目标数量
    /// </summary>
    public static int BaseTargetCount = 20;
    /// <summary>
    /// 怪物基础血量
    /// </summary>
    public static int MonsterBaseHP = 20;
    /// <summary>
    /// 怪物基础移动速度
    /// </summary>
    public static float MonsterBaseMoveSpeed = 3.5f;
    /// <summary>
    /// 怪物生成间隔
    /// </summary>
    public static float MonsterCreateInterval = 1f;
    
    /// <summary>
    /// 怪物生成位置
    /// </summary>
    private static Transform creator;
    /// <summary>
    /// 怪物prefab
    /// </summary>
    private static GameObject skeleton;
    /// <summary>
    /// 怪物对象池
    /// </summary>
    private static List<GameObject> monsterPool;
    /// <summary>
    /// 当前关卡已生成的怪物数量
    /// </summary>
    private static int currentMonsterCount = 0;
    /// <summary>
    /// 当前关卡应生成怪物数量
    /// </summary>
    private static int maxMosterCount = 0;

    void Start()
    {
        maxMosterCount = BaseTargetCount;
        monsterPool = new List<GameObject>();

        creator = GameObject.Find("StartingPoint").transform;
        skeleton = Resources.Load<GameObject>("Prefabs/Monster/Skeleton");

        CreateMonster();
    }

    /// <summary>
    /// 生成怪物
    /// </summary>
    void CreateMonster()
    {
        StartCoroutine(CorotineCreateMonster());
    }

    IEnumerator CorotineCreateMonster()
    {
        while (currentMonsterCount < maxMosterCount)
        {
            GameObject curMonster = Instantiate(skeleton, creator);
            curMonster.GetComponent<Skeleton>().SetHP(MonsterBaseHP);
            currentMonsterCount++;
            yield return new WaitForSeconds(MonsterCreateInterval);
        }
    }

    /// <summary>
    /// 怪物对象入池
    /// </summary>
    /// <param name="monster">入池对象</param>
    public void MonsterEnterPool(GameObject monster) 
    {
        if (monsterPool == null) return;

        monsterPool.Add(monster);
    }

    /// <summary>
    /// 怪物对象出池
    /// </summary>
    /// <returns>出池对象</returns>
    GameObject MonsterOutPool()
    {
        if (monsterPool == null) return null;

        GameObject monster = monsterPool[monsterPool.Count];
        monsterPool.RemoveAt(monsterPool.Count);
        return monster;
    }

}
