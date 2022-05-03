using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    // 게임오브젝트 변수들 ///
    GameObject mainTargetObject; // 적이 최종목표로하는 오브젝트

    /// 이동 변수들 ///
    Vector3 mainTargetPos; // 적이 목표로하는 위치

    /// 컴포넌트 변수들 ///
    NavMeshAgent agent;

    private void Awake()
    {
        /// 컴포넌트변수 할당 ///
        agent = GetComponent<NavMeshAgent>();
        mainTargetObject = GameObject.FindGameObjectWithTag("EndPoint");
        mainTargetPos = mainTargetObject.transform.position;
        print(mainTargetPos);
        
    }

    private void Update()
    {
        move();
    }

    private void move()
    {
        // targetPos로 적의 위치를 이동
        if (mainTargetPos != Vector3.zero)
        {
            agent.SetDestination(mainTargetPos);
        }
    }
}
