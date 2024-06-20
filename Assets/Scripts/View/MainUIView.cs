using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIView : MonoBehaviour
{
    public void OnClick_LevelUp()
    {
        GameLogicManager.Inst.RequestLevelUp();
    }
}
