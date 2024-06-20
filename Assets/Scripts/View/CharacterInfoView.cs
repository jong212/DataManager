using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfoView : MonoBehaviour
{
    [SerializeField] Text Text_Name;
    [SerializeField] Text Text_Description;
    [SerializeField] GameObject Transform_SlotRoot;
    [SerializeField] GameObject Prefab_SkillSlot;

    private int _currentCharacter = 3;

    public void Start()
    {
        SetCharacterInfo();
    }

    private void SetCharacterInfo()
    {
        var character = DataManager.Inst.GetCharacterData(_currentCharacter);
        if(character == null)
        {
            return;
        }

        Text_Name.text = character.Name;
        Text_Description.text = character.Description;
    }

}
