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
}
