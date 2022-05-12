using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 모든 포탑투사체의 기본이되는 클래스
public class BaseProjectile : MonoBehaviour
{
    MakeProjectileSystem projectileSystem;
    GameObject target;

    public float speed; // 투사체 속도

    private void Update()
    {
        moveToPlayer(); // 플레이어에게 투사체를 이동하게 함

        if (target == null) // 투사체가 날라가는도중 타겟이 사라지면
            destroyProjectile(); // 투사체 파괴
    }

    public void setTarget()
    {
        projectileSystem = transform.parent.parent.GetComponent<MakeProjectileSystem>(); // 포탑 오브젝트의 컴포넌트를 받아와서
        target = projectileSystem.target; // 타겟으로 설정
    }

    private void moveToPlayer()
    {
        if(target != null)
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, speed);
    }

    public void destroyProjectile()
    {
            Destroy(gameObject); // 포탑에맞은 객체에게 데미지를 주는걸로 변경(변경해야할 부분)
    }
}
