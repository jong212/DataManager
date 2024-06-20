using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipPopup : MonoBehaviour
{
    [SerializeField] Text Text_TooltipMsg;
    
    public void SetUI(string msg)
    {
        Text_TooltipMsg.text = msg;
    }

    public void OnClick_CloseTooltip()
    {
        UIManager.Instance.CloseSpecificUI(UIType.TooltipPopup);
    }

}
