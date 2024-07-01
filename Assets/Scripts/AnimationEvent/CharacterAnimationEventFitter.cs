using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationEventFitter : MonoBehaviour
{
    [SerializeField] Animator Animator_Origin;
    [SerializeField] string _animationEventGroupName;
   
    private void Start()
    {
        SetAnimationEvent();
    }

    private void SetAnimationEvent()
    {
        if (string.IsNullOrEmpty(_animationEventGroupName))
            return;

        if (DataManager.Inst.LoadedAnimEventList?.Count == 0)
            return;

        if (false == DataManager.Inst.LoadedAnimEventList.ContainsKey(_animationEventGroupName))
            return;

        var animEventList = DataManager.Inst.LoadedAnimEventList[_animationEventGroupName];

        foreach(var animEventData in animEventList)
        {
            AddAnimationEvent(
                animEventData.EventName,
                animEventData.ClipName,
                animEventData.EventStartTime
                );
        }
    }

    private void AddAnimationEvent(string eventName, string clipName, float eventStartTime)
    {
        var clip = LoadClipByName(clipName);
        if (clip != null)
        {
            // 반드시 애니메이터와 이벤트 컴포넌트가 동일한 GameObject에 있어야한다.
            // 자식이나 부모에 있으면 이벤트 컴포넌트 내의 함수들이 불려지지 않는다.
            var animEvents = Animator_Origin.gameObject.AddComponent<CharacterAnimEvents>();
            if (animEvents != null)
            {
                AddEventOnClip(eventName, clip, eventStartTime);
            }
        }
    }

    private AnimationClip LoadClipByName(string name)
    {
        AnimationClip clip = null;
        foreach(var animClip in Animator_Origin.runtimeAnimatorController.animationClips)
        {
            if(animClip.name == name)
            {
                clip = animClip;
                break;
            }
        }

        return clip;
    }

    private void AddEventOnClip(string eventName, AnimationClip clip, float eventStartTime)
    {
        float eventTime = eventStartTime;

        AnimationEvent animEvent = new AnimationEvent();
        animEvent.objectReferenceParameter = this;
        animEvent.time = eventTime;
        animEvent.functionName = eventName;
        animEvent.messageOptions = SendMessageOptions.DontRequireReceiver;

        clip.AddEvent(animEvent);
    }
}
