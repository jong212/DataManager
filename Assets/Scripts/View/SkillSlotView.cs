using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlotView : MonoBehaviour
{
    [SerializeField] Image Image_Icon;
    [SerializeField] Text Text_SkillName;

    private string _skillClassName;

    public void SetUI(string skillClassName)
    {
        _skillClassName = skillClassName;

        var skillData = DataManager.Inst.GetSkillData(_skillClassName);
        if(skillData != null)
        {
            Text_SkillName.text = skillData.Name;
        }
    }

    public void OnClick_OpenTooltip()
    {
    }
}
