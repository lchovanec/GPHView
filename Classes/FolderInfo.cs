namespace GPHView.Classes
{
    public class FolderInfo : FileSystemObjectInfo
    {
        public string title { get; set; }
        public string description { get; set; } 
        public string access { get; set; }
        public DateInfo date { get; set; }
        public string location { get; set; }
        public GeoDataInfo geoData { get; set; }
    }
}
