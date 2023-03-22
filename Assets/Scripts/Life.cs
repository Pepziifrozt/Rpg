using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator animator;
    [SerializeField] private GameObject _endScreen;
    private bool _isDead = false;

    public bool IsAlive
    {
        get { return !_isDead; }
    }

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        if (!_isDead)
        {
            _isDead = !_isDead;

            animator.SetTrigger("death");




        }

    }

    private void RestartLevel()
    {
        _endScreen.SetActive(true);
    }


}
