using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubsMemberTwo : MonoBehaviour
{
    [SerializeField] Animator Animator_SubMember;

    private void OnEnable()
    {
        EventManager.Inst.RequestSubscribe(isSubscribe: true, OnEventLalala);
    }

    private void OnDisable()
    {
        EventManager.Inst.RequestSubscribe(isSubscribe: false, OnEventLalala);
    }
    public void OnEventLalala()
    {
        Animator_SubMember.SetTrigger("LevelUp");
    }
}
