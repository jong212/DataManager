using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Inst { get; private set; }

    public Dictionary<int, Character> LoadedCharacterList { get; private set; }
    public Dictionary<string, Skill> LoadedSkillList { get; private set; }
    public Dictionary<string, Buff> LoadedBuffList { get; private set; }
    public Dictionary<string, ModelAnimationEvent> LoadedAnimEventList { get; private set; }

    private void Awake()
    {
        Inst = this;
        ReadAllDataOnAwake();
    }

    private void ReadAllDataOnAwake()
    {
        ReadDataTable(nameof(Character)); // == ReadData("Character")
        ReadDataTable(nameof(Skill));
        ReadDataTable(nameof(Buff));
        ReadDataTable(nameof(AnimationEvent));
    }

    private void ReadDataTable(string tableName)
    {
        var docTextAsset = Resources.Load<TextAsset>($"Data/{tableName}");

        XDocument doc = XDocument.Parse(docTextAsset.text);
        if (doc == null)
        {
            Debug.LogError($"Resource Load Faield!! Data/{tableName}.xml");
            return;
        }

        switch (tableName)
        {
            case "Character":
                ReadCharacterTable(doc);
                break;
            case "Skill":
                ReadSkillTable(doc);
                break;
            case "Buff":
                ReadBuffTable(doc);
                break;
            case nameof(AnimationEvent):
                ReadAnimationEventTable(doc);
                break;
        }

    }


    private void ReadCharacterTable(XDocument doc)
    {
        LoadedCharacterList = new Dictionary<int, Character>();
        
        var dataElements = doc.Descendants("data");

        foreach (var data in dataElements)
        {
            var tempCharacter = new Character();
            tempCharacter.DataId = int.Parse(data.Attribute(nameof(tempCharacter.DataId)).Value);
            tempCharacter.Name = data.Attribute(nameof(tempCharacter.Name)).Value;
            tempCharacter.Description = data.Attribute(nameof(tempCharacter.Description)).Value;
            tempCharacter.IconPath = data.Attribute(nameof(tempCharacter.IconPath)).Value;
            tempCharacter.PrefabPath = data.Attribute(nameof(tempCharacter.PrefabPath)).Value;

            string skillNameListStr = data.Attribute("SkillNameList").Value;
            if (!string.IsNullOrEmpty(skillNameListStr))
            {
                skillNameListStr = skillNameListStr.Replace("{", string.Empty);
                skillNameListStr = skillNameListStr.Replace("}", string.Empty);

                var skillNames = skillNameListStr.Split(',');

                var list = new List<string>();
                if (skillNames.Length > 0)
                {
                    foreach (var name in skillNames)
                    {
                        list.Add(name);
                    }
                }
                tempCharacter.SkillClassNameList = list;
            }

            LoadedCharacterList.Add(tempCharacter.DataId, tempCharacter);
        }

    }
    private void ReadSkillTable(XDocument doc)
    {
        LoadedSkillList = new Dictionary<string, Skill>();

        var dataElements = doc.Descendants("data");

        foreach (var data in dataElements)
        {
            var tempSkill = new Skill();
            tempSkill.SkillClassName = data.Attribute("DataName").Value;
            tempSkill.Name = data.Attribute(nameof(tempSkill.Name)).Value;
            tempSkill.Description = data.Attribute(nameof(tempSkill.Description)).Value;
            tempSkill.BaseDamage = int.Parse(data.Attribute(nameof(tempSkill.BaseDamage)).Value);
            tempSkill.DamageMultiSkillLevelName = float.Parse(data.Attribute(nameof(tempSkill.DamageMultiSkillLevelName)).Value);
            tempSkill.IconName = data.Attribute(nameof(tempSkill.IconName)).Value;

            string skillNameListStr = data.Attribute(nameof(tempSkill.BuffNameList)).Value;
            if (!string.IsNullOrEmpty(skillNameListStr))
            {
                skillNameListStr = skillNameListStr.Replace("{", string.Empty);
                skillNameListStr = skillNameListStr.Replace("}", string.Empty);

                var names = skillNameListStr.Split(',');

                var list = new List<string>();
                if (names.Length > 0)
                {
                    foreach (var name in names)
                    {
                        list.Add(name);
                    }
                }
                tempSkill.BuffNameList = list;

            }
            LoadedSkillList.Add(tempSkill.SkillClassName, tempSkill);
        }
    }

    private void ReadBuffTable(XDocument doc)
    {
        LoadedBuffList = new Dictionary<string, Buff>();

        var dataElements = doc.Descendants("data");

        foreach (var data in dataElements)
        {
            var tempBuff = new Buff();
            tempBuff.BuffClassName = data.Attribute("DataName").Value;
            tempBuff.Name = data.Attribute(nameof(tempBuff.Name)).Value;
            tempBuff.Description = data.Attribute(nameof(tempBuff.Description)).Value;
            tempBuff.BuffTime = int.Parse(data.Attribute(nameof(tempBuff.BuffTime)).Value);

            string buffValuesStr = data.Attribute(nameof(tempBuff.BuffValues)).Value;
            if (!string.IsNullOrEmpty(buffValuesStr))
            {
                buffValuesStr = buffValuesStr.Replace("{", string.Empty);
                buffValuesStr = buffValuesStr.Replace("}", string.Empty);

                var values = buffValuesStr.Split(',');

                 var list = new List<float>();
                if (values.Length > 0)
                {
                    foreach (var buffValue in values)
                    {
                        list.Add(float.Parse(buffValue));
                    }
                }
                tempBuff.BuffValues = list;
            }
            LoadedBuffList.Add(tempBuff.BuffClassName, tempBuff);
        }
    }

    public void ReadAnimationEventTable(XDocument doc)
    {
        LoadedAnimEventList = new Dictionary<string, ModelAnimationEvent>();

        var dataElements = doc.Descendants("data");

        foreach (var data in dataElements)
        {
            var tempAnimEvent = new ModelAnimationEvent();
            tempAnimEvent.ClassName = data.Attribute(nameof(tempAnimEvent.ClassName)).Value;
            tempAnimEvent.AnimationGroup = data.Attribute(nameof(tempAnimEvent.AnimationGroup)).Value;
            tempAnimEvent.ClipName = data.Attribute(nameof(tempAnimEvent.ClipName)).Value;
            tempAnimEvent.EventName = data.Attribute(nameof(tempAnimEvent.EventName)).Value;
            tempAnimEvent.EventStartTime = float.Parse(data.Attribute(nameof(tempAnimEvent.EventStartTime)).Value);

            LoadedAnimEventList.Add(tempAnimEvent.ClassName, tempAnimEvent);
        }
    }
}
