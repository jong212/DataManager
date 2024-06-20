
namespace ViewModel.Extensions
{
    public static class SubProfileViewModelExtension
    {
        public static void RefreshViewModel(this SubProfileViewModel vm)
        {
            int tempId = 2;
            GameLogicManager.Inst.RefreshCharacterInfo(tempId, vm.OnRefreshViewModel);
        }

        public static void OnRefreshViewModel(this SubProfileViewModel vm, int userId, string name, int level)
        {
            vm.UserId = userId;
            vm.Name = name;
            vm.Level = level;
        }

        public static void RegisterEventsOnEnable(this SubProfileViewModel vm)
        {
            GameLogicManager.Inst.RegisterLevelUpCallback(vm.OnResponseLevelUp);
        }

        public static void UnRegisterOnDisable(this SubProfileViewModel vm)
        {
            GameLogicManager.Inst.UnRegisterLevelUpCallback(vm.OnResponseLevelUp);
        }

        public static void OnResponseLevelUp(this SubProfileViewModel vm, int userId, int level)
        {
            if (vm.UserId != userId)
                return;

            vm.Level = level;
        }

    }

}

