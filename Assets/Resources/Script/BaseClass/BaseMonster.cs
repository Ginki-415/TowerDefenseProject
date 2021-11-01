using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 怪物基类
/// </summary>
public abstract class BaseMonster : MonoBehaviour
{
    /// <summary>
    /// 导航代理组件
    /// </summary>
    protected NavMeshAgent navMesh;
    /// <summary>
    /// 路径点组
    /// </summary>
    protected GameObject[] waypoints;
    /// <summary>
    /// 当前行进的目标导航点
    /// </summary>
    protected int curPos = 0;
    /// <summary>
    /// 最大生命值
    /// </summary>
    protected float maxHP = 0f;
    /// <summary>
    /// 当前生命值
    /// </summary>
    protected float curHP = 0f;

    protected virtual void Start()
    {
        InitEntity();
        UpdateMoveState();
    }

    /// <summary>
    /// 实体初始化方法
    /// </summary>
    protected virtual void InitEntity() 
    {
        navMesh = transform.GetComponent<NavMeshAgent>();
        waypoints = GameObject.FindGameObjectsWithTag("DefaultWaypoint");

        curHP = maxHP;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DefaultWaypoint")
        {
            UpdateMoveState();
        }
        else if(other.tag == "Finish")
        {
            ArriveAtEnding();
        }
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {

    }

    /// <summary>
    /// 刷新移动状态
    /// </summary>
    protected virtual void UpdateMoveState()
    {
        if (waypoints.Length == 0 || curPos >= waypoints.Length) return;

        navMesh.destination = waypoints[curPos++].transform.position;
    }

    /// <summary>
    /// 怪物到达终点触发方法
    /// </summary>
    protected virtual void ArriveAtEnding()
    {
        GlobalManager.Instance.OnChangePlayerHP(-curHP);

        MonsterCreator.Instance.MonsterEnterPool(gameObject);
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 设置最大生命值
    /// </summary>
    /// <param name="value">目标值</param>
    public virtual void SetHP(float value) 
    {
        maxHP = value;
    }

}
