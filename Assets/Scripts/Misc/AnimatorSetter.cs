using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSetter : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] string triggerName;

    public void SetBool(bool value) => animator.SetBool(triggerName, value);
}
