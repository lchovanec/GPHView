namespace GPH.FileUtils
{
    public static class FileUtils
    {
        public static IEnumerable<FileSystemInfo> EnumFSI(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            return dir.EnumerateFileSystemInfos("metadata.json", new EnumerationOptions() { RecurseSubdirectories = true });
        }


    }
}