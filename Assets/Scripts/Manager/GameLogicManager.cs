using System;
using System.Collections.Generic;

public class Player
{
    public Player(int userId, string name)
    {
        UserId = userId;
        Name = name;
        Level = 0;
        HP = 100;
    }

    public int UserId { get; private set; }
    public string Name { get; private set; }
    public int Level { get; set; }
    public int HP { get; set; }
}

public class GameLogicManager
{
    private static GameLogicManager _instance = null;
    private int _curSelectedPlayerId = 0;

    private static Dictionary<int, Player> _playerDic = new Dictionary<int, Player>();
    private Action<int, int> _levelUpCallback;
    private Action<int, int> _hpChangedCallback;

    public static GameLogicManager Inst
    {
        get
        {
            if(_instance == null)
            {
                _instance = new GameLogicManager();
                TempInitPlayerList();
            }
            return _instance;
        }
    }

    public static void TempInitPlayerList()
    {
        _playerDic.Add(1, new Player(1, "죠스바"));
        _playerDic.Add(2, new Player(2, "쌍쌍바"));
        _playerDic.Add(3, new Player(3, "바밤바"));
    }

    public void RegisterLevelUpCallback(Action<int, int> levelupCallback)
    {
        _levelUpCallback += levelupCallback;
    }

    public void UnRegisterLevelUpCallback(Action<int, int> levelupCallback)
    {
        _levelUpCallback -= levelupCallback;
    }
    public void RequestLevelUp()
    {
        int reqUserId = _curSelectedPlayerId;

        if (_playerDic.ContainsKey(reqUserId))
        {
            var curPlayer = _playerDic[reqUserId];
            curPlayer.Level++;
            _levelUpCallback.Invoke(reqUserId, curPlayer.Level);
        }
    }

    public void RefreshCharacterInfo(int requestId, Action<int, string, int> callback)
    {
        _curSelectedPlayerId = requestId;
        if (_playerDic.ContainsKey(requestId))
        {
            var curPlayer = _playerDic[requestId];
            callback.Invoke(curPlayer.UserId, curPlayer.Name, curPlayer.Level);
        }
    }

    public void RefreshCharacterHp(int requestId, Action<int> callback)
    {
        _curSelectedPlayerId = requestId;
        if (_playerDic.ContainsKey(requestId))
        {
            var curPlayer = _playerDic[requestId];
            callback.Invoke(curPlayer.HP);
        }
    }

    public void RegisterHpChangedCallback(Action<int, int> hpChangedCallback, bool isRegister)
    {
        if (isRegister)
        {
            _hpChangedCallback += hpChangedCallback;
        }
        else
        {
            _hpChangedCallback -= hpChangedCallback;
        }
    }

    public void RequestTargetCharacterDamage(int requestCharacterId, int damage)
    {
        _curSelectedPlayerId = requestCharacterId;
        if (_playerDic.ContainsKey(requestCharacterId))
        {
            var curPlayer = _playerDic[requestCharacterId];
            var finalDamage = curPlayer.HP - damage;
            curPlayer.HP = (finalDamage < 0) ? 0 : finalDamage;
            _hpChangedCallback.Invoke(curPlayer.UserId, curPlayer.HP);
        }
    }
}
