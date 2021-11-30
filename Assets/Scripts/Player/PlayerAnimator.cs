using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] enum PlayerAnimateState { Idle, Attack, MoveRight, MoveLeft, Jump, Fall }
    [SerializeField] PlayerAnimateState state = PlayerAnimateState.Idle;
    [SerializeField] GlobalVector2 movement;
    [SerializeField] GlobalBool hasJumped;
    [SerializeField] string idleName, attackName, moveRightName, moveLeftName, jumpName, fallName;
    [SerializeField] Animator playerAnimator;

    void Update()
    {
        Vector2 m = movement.Value;
        
        if (m.x.Equals(-1))
            state = PlayerAnimateState.MoveLeft;
        else if (m.x.Equals(1))
            state = PlayerAnimateState.MoveRight;

        if (m.x.Equals(0))
            state = PlayerAnimateState.Idle;
        if (hasJumped.Value.Equals(true))
            state = PlayerAnimateState.Jump;
        if (movement.Value.y.Equals(-1))
            state = PlayerAnimateState.Fall;

        switch (state)
        {
            case PlayerAnimateState.Idle:
                playerAnimator.SetTrigger(idleName);
                break;
            case PlayerAnimateState.Attack:
                playerAnimator.SetTrigger(attackName);
                break;
            case PlayerAnimateState.MoveRight:
                playerAnimator.SetTrigger(moveRightName);
                break;
            case PlayerAnimateState.MoveLeft:
                playerAnimator.SetTrigger(moveLeftName);
                break;
            case PlayerAnimateState.Jump:
                playerAnimator.SetTrigger(jumpName);
                break;
            case PlayerAnimateState.Fall:
                playerAnimator.SetTrigger(fallName);
                break;
        }
    }
}
