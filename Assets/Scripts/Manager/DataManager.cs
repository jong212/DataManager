using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Inst { get; private set; }

    Dictionary<int, Character> _loadedCharacterList = new Dictionary<int, Character>();
    Dictionary<string, Buff> _loadedBuffList = new Dictionary<string, Buff>();
    Dictionary<string, Skill> _loadedSkillList = new Dictionary<string, Skill>();

    private readonly string _dataRootPath = "C:/Users/KGA/Desktop/DataParser";

    private void Awake()
    {
        Inst = this;
        ReadAllDataOnAwake();
    }

    private void ReadAllDataOnAwake()
    {
        ReadData(nameof(Character)); // == ReadData("Character")
        ReadData(nameof(Skill));
        ReadData(nameof(Buff));
    }

    private void ReadData(string tableName)
    {
        // 이 부분은 충분히 개선될 수 있음
        switch (tableName)
        {
            case "Character":
                ReadCharacterTable(tableName);
                break;
            case "Skill":
                ReadSkillTable(tableName);
                break;
            case "Buff":
                ReadBuffTable(tableName);
                break;
        }
    }

    private void ReadCharacterTable(string tableName)
    {
        XDocument doc = XDocument.Load($"{_dataRootPath}/{tableName}.xml");
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
            if (string.IsNullOrEmpty(skillNameListStr))
            {
                skillNameListStr = skillNameListStr.Replace("{", string.Empty);
                skillNameListStr = skillNameListStr.Replace("}", string.Empty);

                var skillNames = skillNameListStr.Split(',');

                if (skillNames.Length > 0)
                {
                    var list = new List<string>();
                    foreach (var name in skillNames)
                    {
                        list.Add(name);
                        tempCharacter.SkillClassNameList = list;
                    }
                }
            }

            _loadedCharacterList.Add(tempCharacter.DataId, tempCharacter);
        }

    }
    private void ReadSkillTable(string tableName)
    {
        XDocument doc = XDocument.Load($"{_dataRootPath}/{tableName}.xml");
        var dataElements = doc.Descendants("data");

        foreach (var data in dataElements)
        {
            var tempSkill = new Skill();
            tempSkill.SkillClassName = data.Attribute("DataName").Value;
            tempSkill.Name = data.Attribute(nameof(tempSkill.Name)).Value;
            tempSkill.Description = data.Attribute(nameof(tempSkill.Description)).Value;
            tempSkill.BaseDamage = int.Parse(data.Attribute(nameof(tempSkill.BaseDamage)).Value);
            tempSkill.DamageMultiSkillLevelName = float.Parse(data.Attribute(nameof(tempSkill.DamageMultiSkillLevelName)).Value);

            string skillNameListStr = data.Attribute(nameof(tempSkill.BuffNameList)).Value;
            if (string.IsNullOrEmpty(skillNameListStr))
            {
                skillNameListStr = skillNameListStr.Replace("{", string.Empty);
                skillNameListStr = skillNameListStr.Replace("}", string.Empty);

                var names = skillNameListStr.Split(',');

                if (names.Length > 0)
                {
                    var list = new List<string>();
                    foreach (var name in names)
                    {
                        list.Add(name);
                        tempSkill.BuffNameList = list;
                    }
                }
            }
            _loadedSkillList.Add(tempSkill.SkillClassName, tempSkill);
        }
    }

    private void ReadBuffTable(string tableName)
    {
        XDocument doc = XDocument.Load($"{_dataRootPath}/{tableName}.xml");
        var dataElements = doc.Descendants("data");

        foreach (var data in dataElements)
        {
            var tempBuff = new Buff();
            tempBuff.BuffClassName = data.Attribute("DataName").Value;
            tempBuff.Name = data.Attribute(nameof(tempBuff.Name)).Value;
            tempBuff.Description = data.Attribute(nameof(tempBuff.Description)).Value;
            tempBuff.BuffTime = int.Parse(data.Attribute(nameof(tempBuff.BuffTime)).Value);

            string skillNameListStr = data.Attribute(nameof(tempBuff.BuffValues)).Value;
            if (string.IsNullOrEmpty(skillNameListStr))
            {
                skillNameListStr = skillNameListStr.Replace("{", string.Empty);
                skillNameListStr = skillNameListStr.Replace("}", string.Empty);

                var names = skillNameListStr.Split(',');

                if (names.Length > 0)
                {
                    var list = new List<float>();
                    foreach (var name in names)
                    {
                        list.Add(float.Parse(name));
                        tempBuff.BuffValues = list;
                    }
                }
            }
            _loadedBuffList.Add(tempBuff.BuffClassName, tempBuff);
        }
    }
}
