namespace GPHView.Classes
{
    public class FileSystemObjectInfo
    {
        public string FullPath { get; set; }
        public char Type { get; set; }
        public FileSystemObjectInfo Parent { get; set; }

        public bool IsFolder => Type == 'D';
    }
}
