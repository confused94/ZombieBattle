

using UnityEngine;

public class AnimExit : StateMachineBehaviour
{
    

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("Reloading"))
        {
            animator.SetBool("bittiMi", true);
            

        }
        if (stateInfo.IsName("saldir"))
        {
            animator.SetBool("zararver",true);
        }
    }

    
}
