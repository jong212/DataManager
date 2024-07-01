using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempAnimationPrefab : MonoBehaviour
{
    [SerializeField] GameObject Prefab_DizzyEffect;

    public GameObject GetEffect(string effectName)
    {
        GameObject gObj = null;
        switch (effectName)
        {
            case "dizzy":
                gObj = Prefab_DizzyEffect;
                break;
        }

        return gObj;
    }
}
