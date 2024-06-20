using System.Collections;
using System.Collections.Generic;

namespace ViewModel.Extension
{
    public static class CharacterStateViewModelExtension
    {
        public static void RefreshViewModel(this CharacterStateViewModel vm)
        {
            var tempId = 2;
            GameLogicManager.Inst.RefreshCharacterHp(tempId, vm.OnRefreshViewModel);
        }

        public static void OnRefreshViewModel(this CharacterStateViewModel vm, int hp)
        {
            vm.CharacterHp = hp;
        }

        public static void RegisterHpChangedEvent(this CharacterStateViewModel vm, bool isRegister)
        {
            GameLogicManager.Inst.RegisterHpChangedCallback(vm.OnResponseHpChangedEvent, isRegister);
        }

        public static void OnResponseHpChangedEvent(this CharacterStateViewModel vm, int userId, int hp)
        {
            vm.CharacterHp = hp;
        }
    }
}

