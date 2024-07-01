using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimEvents : MonoBehaviour
{
    public void OnAnimationEventTest()
    {
        Debug.Log("애니 발생 됬다");
    }

    public void OnAnimationEvent_Dizzy()
    {
        var tempAnimPrefab = this.GetComponent<TempAnimationPrefab>();
        if(tempAnimPrefab != null)
        {
            var prefab = tempAnimPrefab.GetEffect("dizzy");
            if(prefab != null)
            {
                var effectObj = Instantiate(prefab, this.gameObject.transform);
                var effect = effectObj.GetComponent<ParticleSystem>();
                if (effect != null)
                {
                    effect.Play();
                }
            }
        }
    }
}
