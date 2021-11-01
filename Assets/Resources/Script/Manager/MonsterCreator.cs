using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����������
/// </summary>
public class MonsterCreator : Singleton<MonsterCreator>
{
    /// <summary>
    /// ����Ŀ������
    /// </summary>
    public static int BaseTargetCount = 20;
    /// <summary>
    /// �������Ѫ��
    /// </summary>
    public static int MonsterBaseHP = 20;
    /// <summary>
    /// ��������ƶ��ٶ�
    /// </summary>
    public static float MonsterBaseMoveSpeed = 3.5f;
    /// <summary>
    /// �������ɼ��
    /// </summary>
    public static float MonsterCreateInterval = 1f;
    
    /// <summary>
    /// ��������λ��
    /// </summary>
    private static Transform creator;
    /// <summary>
    /// ����prefab
    /// </summary>
    private static GameObject skeleton;
    /// <summary>
    /// ��������
    /// </summary>
    private static List<GameObject> monsterPool;
    /// <summary>
    /// ��ǰ�ؿ������ɵĹ�������
    /// </summary>
    private static int currentMonsterCount = 0;
    /// <summary>
    /// ��ǰ�ؿ�Ӧ���ɹ�������
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
    /// ���ɹ���
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
    /// ����������
    /// </summary>
    /// <param name="monster">��ض���</param>
    public void MonsterEnterPool(GameObject monster) 
    {
        if (monsterPool == null) return;

        monsterPool.Add(monster);
    }

    /// <summary>
    /// ����������
    /// </summary>
    /// <returns>���ض���</returns>
    GameObject MonsterOutPool()
    {
        if (monsterPool == null) return null;

        GameObject monster = monsterPool[monsterPool.Count];
        monsterPool.RemoveAt(monsterPool.Count);
        return monster;
    }

}
