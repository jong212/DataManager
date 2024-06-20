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
}
