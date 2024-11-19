using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private float moveSpeed; 

    public float MoveSpeed
    {
        get => moveSpeed;
        private set => moveSpeed = value; // 별도의 moveSpeed 값을 넣어주니 에러가 없어졌다
    }

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        MoveSpeed = 5f;
    }
}
