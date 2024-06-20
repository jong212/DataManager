using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMaker : MonoBehaviour, IEventMake
{
    [SerializeField] Animator Animator_Player;

    Action _eventInvokHandler;

    private void Start()
    {
        EventManager.Inst.RegisterCurEventMaker(true, this);
    }

    private void OnDisable()
    {
        _eventInvokHandler = null;
    }

    // 보통 Subscribe보다 Register 또는 AddEvent 등의 용어를 쓴다 - 예제는 구독이라는 의미로 그냥 사용
    public void Subscribe(bool isSubscribe, Action callback)
    {
        if (isSubscribe)
            _eventInvokHandler += callback;
        else
            _eventInvokHandler -= callback;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeEvent();
        }
    }

    private void InvokeEvent()
    {
        Animator_Player.SetTrigger("Atk");

        if(_eventInvokHandler != null)
            _eventInvokHandler.Invoke();   
    }
}
