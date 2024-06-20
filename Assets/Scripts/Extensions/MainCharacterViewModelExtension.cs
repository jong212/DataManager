using System;
using System.Collections;
using System.Collections.Generic;

namespace ViewModel.Extensions
{
    public static class MainCharacterViewModelExtension
    {
        public static void RefreshViewModel(this MainCharacterProfileViewModel vm)
        {
            int tempId = 2; // 이 부분은 나중에 유저 아이디를 가지고 있던지 해서 받아와서 넣어주자
            GameLogicManager.Inst.RefreshCharacterInfo(tempId, vm.OnRefreshViewModel);
        }

        public static void OnRefreshViewModel(this MainCharacterProfileViewModel vm, int userId, string name, int level)
        {
            vm.UserId = userId;
            vm.Name = name;
            vm.Level = level;
        }

        public static void RegisterEventsOnEnable(this MainCharacterProfileViewModel vm)
        {
            GameLogicManager.Inst.RegisterLevelUpCallback(vm.OnResponseLevelUp);
        }

        public static void UnRegisterOnDisable(this MainCharacterProfileViewModel vm)
        {
            GameLogicManager.Inst.UnRegisterLevelUpCallback(vm.OnResponseLevelUp);
        }

        public static void OnResponseLevelUp(this MainCharacterProfileViewModel vm, int userId, int level)
        {
            if (vm.UserId != userId)
                return;

            vm.Level = level;
        }
    }
}
