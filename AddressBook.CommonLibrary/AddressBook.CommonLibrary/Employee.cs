using System.ComponentModel;

namespace AddressBook.CommonLibrary
{
    public record Employee : INotifyPropertyChanged
    {
        private string name;
        private string position;
        private string? phone;
        private string email;
        private string? room;
        private string? mainWorkplace;
        private string? workplace;

        public string Name 
        { 
            get { return name; }
            set
            {
                if (name != value)
                { 
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        public string Position
        {
            get { return position; }
            set
            {
                if (position != value)
                {
                    position = value;
                    OnPropertyChanged(nameof(Position));
                }
            }
        }
        public string? Phone
        {
            get { return phone; }
            set
            {
                if (phone != value) 
                {
                    phone = value;
                    OnPropertyChanged(nameof(Phone));
                }
            }
        }
        public string Email
        {
            get { return  email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }
        public string? Room
        {
            get { return room; }
            set
            {
                if (room != value)
                {
                    room = value;
                    OnPropertyChanged(nameof(Room));
                }
            }
        }
        public string? MainWorkplace
        {
            get { return mainWorkplace; }
            set
            {
                if(mainWorkplace != value)
                {
                    mainWorkplace = value;
                    OnPropertyChanged(nameof(MainWorkplace));
                }
            }
        }
        public string? Workplace
        { 
            get { return workplace; }
            set
            {
                if (workplace != value)
                {
                    workplace = value;
                    OnPropertyChanged(nameof(Workplace));
                }
            }
        }

        public Employee(string name, string position, string email, string? phone = null, string? room = null, string? mainWorkplace = null, string? workplace = null)
        {
            this.name = name;
            this.position = position;
            this.email = email;
            this.phone = phone;
            this.room = room;
            this.mainWorkplace = mainWorkplace;
            this.workplace = workplace;
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
