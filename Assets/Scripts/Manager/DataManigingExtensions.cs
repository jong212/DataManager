using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManigingExtensions
{
    public static Character GetCharacter(this DataManager manager, int dataId)
    {
        if(manager.LoadedCharacterList.Count == 0
            || manager.LoadedCharacterList.ContainsKey(dataId) == false)
        {
            return null;
        }

        return manager.LoadedCharacterList[dataId];
    }
   
}
