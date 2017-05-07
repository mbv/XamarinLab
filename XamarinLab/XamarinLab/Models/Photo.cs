namespace XamarinLab.Models
{
    public class Photo : BaseDataObject
    {
        private string _name = string.Empty;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _url = string.Empty;

        public string Url
        {
            get { return _url; }
            set { SetProperty(ref _url, value); }
        }
    }
}