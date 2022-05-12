using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : BaseProjectile
{
    public int towerDamage; // 포탑 공격력

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 10) // 적과 충돌하면
        {
            other.GetComponent<EntityStatus>().GetDamage(towerDamage); // 적에게 데미지를 주고
            destroyProjectile(); // 투사체 파괴
        }
        
    }
}
