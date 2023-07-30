namespace GPHView.Classes
{
    public class DocInfo : FileSystemObjectInfo
    {
        public string title { get; set; }
        public string description { get; set; }
        public string imageViews { get; set; }
        public DateInfo creationTime { get; set; }
        public DateInfo photoTakenTime { get; set; }
        public GeoDataInfo geoData { get; set; }
        public GeoDataInfo geodataExif { get; set; }
        public string url { get; set; }
    }
}
