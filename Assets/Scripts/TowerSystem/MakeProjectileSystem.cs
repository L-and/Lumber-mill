using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 타워의 투사체를 만들어내는 시스템
public class MakeProjectileSystem : MonoBehaviour
{


    private SphereCollider attackCollider; // 공격사거리(원형 콜라이더)

    public float attackRadius; // 공격 사거리

    public float attackDelay; // 공격 딜레이

    public GameObject target; // 공격 타겟

    private GameObject attackObjectPrefab; // 공격 오브젝트

    private Transform attackTransform; // 투사체생성 위치

    bool attackAble; // 포탑의 공격가능

    private void Start()
    {
        gameObject.AddComponent<SphereCollider>(); // 스피어 콜라이더 추가

        attackCollider = GetComponent<SphereCollider>(); // 스피어콜라이더 변수에 저장

        attackCollider.radius = attackRadius; // 공격 사거리 설정
        attackCollider.isTrigger = true;

        attackObjectPrefab = Resources.Load("BasicProjectilePrefab") as GameObject; // 포탑공격 오브젝트 설정

        attackAble = true;

        attackTransform = transform.Find("AttackArm"); // 투사체생성위치 설정
    }

    // 공격사거리에 들어옴
    private void OnTriggerStay(Collider other)
    {
        InAttackRange(other);
    }

    // 공격사거리에서 벗어남
    private void OnTriggerExit(Collider other)
    {
        target = null; // 타겟 해제 
    }

    private void InAttackRange(Collider other)
    {
        if (other.gameObject.layer == 10) // 오브젝트가 공격사거리에 들어온다면(10: 적의 레이어)
        {
            setTarget(other.gameObject); // 공격타겟 설정
            tryAttackTarget(); // 공격시도

        }
    }


    // 타겟 설정
    private void setTarget(GameObject target) 
    {
        this.target = target; 
    }

    private void tryAttackTarget()
    {
        if(attackAble) // 포탑공격쿨이 돌았다면
        {
            attackAble = false;
            makeAttackObject(); // 투사체 생성
            StartCoroutine(WaitForIt());
        }
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(attackDelay);
        attackAble = true;

    }

    // 투사체 생성
    private void makeAttackObject()
    {
        if(target != null)
        {
            GameObject attackObject = Instantiate(attackObjectPrefab, attackTransform, true); // 공격 오브젝트 생성
            attackObject.transform.position = attackTransform.position; // 포탑의 AttackArm으로 공격위치 설정

            attackObject.GetComponent<BasicProjectile>().setTarget(); // 투사체의 타겟 설정
        }
    }
}
