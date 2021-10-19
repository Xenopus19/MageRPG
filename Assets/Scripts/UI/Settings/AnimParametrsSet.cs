using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimParametrsSet : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void ChangeState(bool NewState)
    {
        animator.SetBool("Out", NewState);
    }
}
