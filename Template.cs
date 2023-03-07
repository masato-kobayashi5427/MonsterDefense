using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent(typeof(NavMeshAgent))]

public class Template : MonoBehaviour
{
    private GameObject target;
    private NavMeshAgent agent;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private string AttackTag; //Inspectorで設定
    private float stopDistance;
    private float attackTimer;
    private bool isAttack;
    //ここから
    private const int maxHp = 1000;
    public int hp; //(数字を設定する)
    public int power;
    public int walkspeed;
    public int attackrange;

    //ここまでInspectorで設定
    public Slider slider;
    Animator animator;

    private enum targetType
    {
        other,
        castle
    }
    private targetType currentTargetType;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        target = GameObject.FindWithTag(AttackTag);
        isAttack = false;
        this.animator = GetComponent<Animator>();
        slider.maxValue = maxHp;    // Sliderの最大値を敵キャラのHP最大値と合わせる
        hp = maxHp;      // 初期状態はHP満タン
        slider.value = hp;   // Sliderの初期状態を設定（HP満タン）
    }
    private void Update()
    {
        slider.value = hp;
        this.animator.SetTrigger("Walk");
        if (target == null)
        {
            target = GameObject.FindWithTag(AttackTag);
        }

        SetStopDistance();
        FintTarget();
        agent.SetDestination(target.transform.position);

        if (Vector3.Distance(transform.position, target.transform.position) <= stopDistance)
        {
            isAttack = true;
            agent.speed = 0;
        }

        if (isAttack)
        {
            CheckNearTarget();
            SetStopDistance(); //攻撃中にtargetが変わった時のためにここでも記述
            Attack();
            this.animator.SetTrigger("Attack");
        }
    }
    //targetが近くにいるのかどうか判定する
    private void CheckNearTarget()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > stopDistance)
        {
            isAttack = false;
            agent.speed = walkspeed;
        }
    }
    private void SetStopDistance()
    {
        if (target.gameObject.name.Contains("Castle"))
        {
            currentTargetType = targetType.castle;
            stopDistance = attackrange * 2f;
        }
        else
        {
            currentTargetType = targetType.other;
            stopDistance = 2f;
        }
    }
    private void FintTarget()
    {
        enemies = GameObject.FindGameObjectsWithTag(AttackTag);

        float closestDistance = Vector3.Distance(transform.position, target.transform.position);

        foreach (GameObject enemy in enemies)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) < closestDistance)
            {
                target = enemy;
            }
        }
    }

    private void Attack()
    {
        attackTimer += Time.deltaTime;
        switch (currentTargetType)
        {
            case (targetType.other):
                if (attackTimer > 1.0f)
                {
                    target.GetComponent<Character>().hp -= power;
                    attackTimer = 0f;
                }
                if (target.GetComponent<Character>().hp <= 0)
                {
                    isAttack = false;
                    Destroy(target.gameObject);
                    agent.speed = walkspeed;
                }
                break;
            case (targetType.castle):
                if (attackTimer > 1.0f)
                {
                    target.GetComponent<Castle>().Hp -= power;
                    attackTimer = 0f;
                }
                break;
        }
    }
}
