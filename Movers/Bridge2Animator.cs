using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge2Animator : MonoBehaviour
{
    Animator animator;
    public GameObject player;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            animator.SetTrigger("bridge lower");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            animator.SetTrigger("bridge raise");
        }
    }
}
