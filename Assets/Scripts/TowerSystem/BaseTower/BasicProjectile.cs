using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
    MakeProjectileSystem projectileSystem;
    GameObject target;

    public float speed; // 투사체 속도

    private void Update()
    {
        moveToPlayer();
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 10) // 적에게 충돌하면
        {
            Destroy(gameObject); // 포탑에맞은 객체에게 데미지를 주는걸로 변경(변경해야할 부분)
        }
    }
}
