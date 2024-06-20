using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubsMemberOne : MonoBehaviour
{
    [SerializeField] Animator Animator_SubMember;

    private void OnEnable()
    {
        EventManager.Inst.RequestSubscribe(true, OnEventMakerInvoked);
    }

    private void OnDisable()
    {
        EventManager.Inst.RequestSubscribe(false, OnEventMakerInvoked);
    }

    public void OnEventMakerInvoked()
    {
        Animator_SubMember.SetTrigger("Atk");
    }

}
