using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageView : MonoBehaviour
{
    public void OnClick_GiveDamageToCharacter()
    {
        GameLogicManager.Inst.RequestTargetCharacterDamage(2, 10);
    }
}
