using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 카메라를 플레이어에게 붙여주는 스크립트
public class CameraAttcher : MonoBehaviour
{
    public Transform targetTransform;
    public Vector3 offSet;


    private void Start()
    {
        offSet = transform.position; 
    }
    void Update()
    {
        gameObject.transform.position = targetTransform.position + offSet;
    }
}