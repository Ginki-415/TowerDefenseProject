using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// �������
/// </summary>
public abstract class BaseMonster : MonoBehaviour
{
    /// <summary>
    /// �����������
    /// </summary>
    protected NavMeshAgent navMesh;
    /// <summary>
    /// ·������
    /// </summary>
    protected GameObject[] waypoints;
    /// <summary>
    /// ��ǰ�н���Ŀ�굼����
    /// </summary>
    protected int curPos = 0;
    /// <summary>
    /// �������ֵ
    /// </summary>
    protected float maxHP = 0f;
    /// <summary>
    /// ��ǰ����ֵ
    /// </summary>
    protected float curHP = 0f;

    protected virtual void Start()
    {
        InitEntity();
        UpdateMoveState();
    }

    /// <summary>
    /// ʵ���ʼ������
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
    /// ˢ���ƶ�״̬
    /// </summary>
    protected virtual void UpdateMoveState()
    {
        if (waypoints.Length == 0 || curPos >= waypoints.Length) return;

        navMesh.destination = waypoints[curPos++].transform.position;
    }

    /// <summary>
    /// ���ﵽ���յ㴥������
    /// </summary>
    protected virtual void ArriveAtEnding()
    {
        GlobalManager.Instance.OnChangePlayerHP(-curHP);

        MonsterCreator.Instance.MonsterEnterPool(gameObject);
        gameObject.SetActive(false);
    }

    /// <summary>
    /// �����������ֵ
    /// </summary>
    /// <param name="value">Ŀ��ֵ</param>
    public virtual void SetHP(float value) 
    {
        maxHP = value;
    }

}
