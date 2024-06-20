using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using ViewModel.Extensions;

public class MainCharacterProfileView : MonoBehaviour
{
    [SerializeField] Image Image_CharacterIcon;
    [SerializeField] Text Text_CharacterName;
    [SerializeField] Text Text_CharacterLevel;

    private MainCharacterProfileViewModel _vm;

    private void OnEnable()
    {
        if(_vm == null)
        {
            _vm = new MainCharacterProfileViewModel();
            _vm.PropertyChanged += OnPropertyChanged;
            _vm.RegisterEventsOnEnable();
            _vm.RefreshViewModel();
        }
    }

    private void OnDisable()
    {
        if(_vm != null)
        {
            _vm.UnRegisterOnDisable();
            _vm.PropertyChanged -= OnPropertyChanged;
            _vm = null;
        }
    }

    private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case nameof(_vm.Name):
                Text_CharacterName.text = $"이름 : {_vm.Name}";
                break;
            case nameof(_vm.Level):
                Text_CharacterLevel.text = $"레벨 : {_vm.Level}";
                break;
            case nameof(_vm.IconName):
                break;
        }
    }

}
