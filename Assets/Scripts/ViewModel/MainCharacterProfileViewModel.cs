using ViewModel;

public class MainCharacterProfileViewModel : ViewModelBase
{
    private string _iconName;
    private int _userId;
    private string _name;
    private int _level;

    public string IconName
    {
        get { return _iconName; }
        set
        {
            if (_iconName == value)
                return;


           _iconName = value;
           OnPropertyChanged(nameof(IconName));
        }
    }

    public int UserId
    {
        get { return _userId; }
        set
        {
            if (_userId == value)
                return;

            _userId = value;
            OnPropertyChanged(nameof(UserId));
        }
    }

    public string Name
    {
        get { return _name; }
        set
        {
            if (_name == value)
                return;

            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    public int Level
    {
        get { return _level; }
        set
        {
            if (_level == value)
                return;

            _level = value;
            OnPropertyChanged(nameof(Level));
        }
    }

}
