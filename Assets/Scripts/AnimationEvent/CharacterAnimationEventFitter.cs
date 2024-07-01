using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationEventFitter : MonoBehaviour
{
    [SerializeField] Animator Animator_Origin;

    private string _temporalClipName = "Dizzy";

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

    private void AddEventOnClip(string eventName, AnimationClip clip)
    {
        float eventTime = 0.05f;

        AnimationEvent animEvent = new AnimationEvent();
        animEvent.objectReferenceParameter = this;
        animEvent.time = eventTime;
        animEvent.functionName = eventName;
        animEvent.messageOptions = SendMessageOptions.DontRequireReceiver;

        clip.AddEvent(animEvent);
    }
}
