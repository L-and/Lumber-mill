using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStatus : MonoBehaviour
{
    public int hp; //체력
    public int mp; //마나
    
    //데미지 받음
    public void GetDamage(int damage)
    {
        hp -= damage; // 체력 감소

        dieCheck(); // 사망여부 체크
    }

    //사망체크
    private void dieCheck()
    {
        if(hp <= 0)
        {
            // 엔티티 사망코드
            Destroy(gameObject); // 현재 오브젝트 삭제
        }
    }

    // 마나사용
    public void UseMp(int mana)
    {
        mp -= mana; // 마나 감소
    }

    // 현재 마나를 리턴
    public int GetMp()
    {
        return mp;
    }
}
