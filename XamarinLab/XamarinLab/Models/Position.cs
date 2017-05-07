namespace XamarinLab.Models
{
    public class Position : BaseDataObject
    {
        private string _name = string.Empty;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}