using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField]
    [field: Range(0, 100)]
    public int Hp { get; private set; }

    [SerializeField] AudioClip _audio;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        // _audio = GetComponent<AudioSource>();
    }
    
    public void TakeHit(int damage)
    {
        Hp -= damage;

        if (Hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("플레이어 사망");
        SoundManager.instance.PlaySound(_audio);
        gameObject.SetActive(false);
    }
}
