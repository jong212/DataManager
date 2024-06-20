using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManigingExtensions
{
    public static Character GetCharacterData(this DataManager manager, int dataId)
    {
        var loadedCharacterList = manager.LoadedCharacterList;
        if(loadedCharacterList.Count == 0
            || loadedCharacterList.ContainsKey(dataId) == false)
        {
            return null;
        }

        return loadedCharacterList[dataId];
    }

    public static Skill GetSkillData(this DataManager manager, string dataClassName)
    {
        var loadedSkillList = manager.LoadedSkillList;
        if (loadedSkillList.Count == 0
            || loadedSkillList.ContainsKey(dataClassName) == false)
        {
            return null;
        }

        return loadedSkillList[dataClassName];
    }

    public static Buff GetBuffData(this DataManager manager, string dataClassName)
    {
        var loadedBuffList = manager.LoadedBuffList;
        if (loadedBuffList.Count == 0
           || loadedBuffList.ContainsKey(dataClassName) == false)
        {
            return null;
        }

        return loadedBuffList[dataClassName];
    }
}
