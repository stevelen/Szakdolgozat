using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelStep : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.SetInteger("closed_change", 0);
        animator.SetInteger("natural_turn", 0);
        animator.SetInteger("reversed_turn", 0);
        animator.SetInteger("spin_turn", 0);
        animator.SetInteger("whisk", 0);
        animator.SetInteger("closed_left", 0);
    }
}
