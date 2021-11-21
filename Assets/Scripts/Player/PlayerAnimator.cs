using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] enum PlayerAnimateState { idle, attack, moveRight, moveLeft, jump, fall }
    [SerializeField] PlayerAnimateState state = PlayerAnimateState.idle;
    [SerializeField] GlobalVector2 movement;
    [SerializeField] GlobalBool hasJumped;
    [SerializeField] AnimatorTrigger idleTrigger;
    [SerializeField] AnimatorTrigger jumpTrigger;
    [SerializeField] AnimatorTrigger fallTrigger;
    [SerializeField] AnimatorTrigger attackTrigger;
    [SerializeField] AnimatorTrigger walkRightTrigger;
    [SerializeField] AnimatorTrigger walkLeftTrigger;

    void Update()
    {
        Vector2 m = movement.Value;
        
        if (m.x.Equals(-1))
            state = PlayerAnimateState.moveLeft;
        else if (m.x.Equals(1))
            state = PlayerAnimateState.moveRight;

        if (m.x.Equals(0))
            state = PlayerAnimateState.idle;
        if (hasJumped.Value.Equals(true))
            state = PlayerAnimateState.jump;
        if (movement.Value.y.Equals(-1))
            state = PlayerAnimateState.fall;

        switch (state)
        {
            case PlayerAnimateState.idle:
                idleTrigger.Trigger();
                break;
            case PlayerAnimateState.attack:
                break;
            case PlayerAnimateState.moveRight:
                walkRightTrigger.Trigger();
                break;
            case PlayerAnimateState.moveLeft:
                walkLeftTrigger.Trigger();
                break;
            case PlayerAnimateState.jump:
                jumpTrigger.Trigger();
                break;
            case PlayerAnimateState.fall:
                fallTrigger.Trigger();
                break;
        }
    }
}
