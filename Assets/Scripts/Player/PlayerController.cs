using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    /// 오브젝트 변수들 ///
    public Camera mainCam; // 카메라

        /// 이동 변수들 ///
    Vector3 targetPos; // 플레이어가 이동하는 위치
    float distance = 1000.0f;

    /// 입력 변수들 ///
    bool bRightMouseDown; // 우클릭 입력

    /// 컴포넌트 변수들 ///
    Rigidbody rigid; // 리지드바디
    NavMeshAgent agent;


    private void Awake()
    {
        /// 컴포넌트변수 할당 ///
        rigid = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        PlayerInput(); // 플레이어 입력을 받음

        SetTargetPosition(); // 이동할 목표포지션을 정함
        MovePlayerPosition(); // 플레이어를 이동시킴
    }


    // 플레이어 입력을 받는하는 함수
    public void PlayerInput()
    {
        bRightMouseDown = Input.GetMouseButtonDown(1); // 우클릭
    }

    public void SetTargetPosition() // 우클릭시 플레이어가 이동할 위치를 표시해줌
    { 
        if(bRightMouseDown) // 우클릭이 입력됐을 때
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition); // 카메라에서 레이저를 쏨
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 1f); // [디버그]레이저를 씬에 표시

            int layerMask = 1 << LayerMask.NameToLayer("Ground"); // 그라운드레이어랑 레이가 충돌하게 설정
            if (Physics.Raycast(ray, out RaycastHit raycastHit, distance, layerMask)) // 레이저가 뭔가에 맞았다면
            {
                targetPos = raycastHit.point + Vector3.up;

            }

        }
    }

    public void MovePlayerPosition() // 플레이어의 위치를 targetPos로 이동시켜줌
    {
        // targetPos로 플레이어의 위치를 이동
        if(targetPos != Vector3.zero)
        {
            agent.SetDestination(targetPos);

        }
        
    }
}
