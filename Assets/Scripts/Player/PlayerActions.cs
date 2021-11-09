using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] GlobalBool canUseAction;
    [SerializeField] GlobalBool actionPressed;
    public void OnAction()
    {
        if (canUseAction.Value)
            actionPressed.Value = true;
    }
}
