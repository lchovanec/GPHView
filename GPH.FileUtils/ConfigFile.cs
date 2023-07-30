namespace GPH.FileUtils
{
    public class ConfigFile
    {
        public string Path { get; set; }

        public ConfigFile(string pth)
        {
            Path = pth;
        }
    }
}
