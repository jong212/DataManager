using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using ViewModel.Extensions;

public class SubProfileView : MonoBehaviour
{
    [SerializeField] Text Text_Name;
    [SerializeField] Text Text_Level;

    private SubProfileViewModel _vm;

    private void OnEnable()
    {
        if(_vm == null)
        {
            _vm = new SubProfileViewModel();
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
                Text_Name.text = $"이름 : {_vm.Name}";
                break;
            case nameof(_vm.Level):
                Text_Level.text = $"레벨 : {_vm.Level}";
                break;
        }
    }
}
