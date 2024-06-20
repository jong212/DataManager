using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace ViewModel
{
    public class CharacterStateViewModel
    {
        private int _characterHp;

        public int CharacterHp
        {
            get { return _characterHp; }
            set
            {
                if (_characterHp == value)
                    return;

                _characterHp = value;
                OnPropertyChanged(nameof(CharacterHp));
            }
        }

        #region PropChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

