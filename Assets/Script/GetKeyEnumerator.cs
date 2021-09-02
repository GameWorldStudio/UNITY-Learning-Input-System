using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKeyEnumerator : CustomYieldInstruction
{
    [SerializeField]
    private KeyCode KeyDown;
    Action<KeyCode> action;
    public override bool keepWaiting
    {
        get
        {
            foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(vKey))
                {
                    action(vKey);
                    return false;
                }
            }
            return true;
        }
    }
    public GetKeyEnumerator(Action<KeyCode> Ptest)
    {
        action = Ptest;
    }

}