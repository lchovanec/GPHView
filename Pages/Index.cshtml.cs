using GPH.FileUtils;
using GPHView.Classes;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace GPHView.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> log;
        private readonly IConfiguration config;
        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            log = logger;
            config = configuration;

            Folders = new();
            Docs = new();
        }

        public HashSet<FolderInfo> Folders { get; set; }
        public HashSet<DocInfo> Docs { get; set; }

        public async Task OnGet()
        {
            var pth = config.GetValue<string>("GPHPath");
            var cfgs = FileUtils.EnumFSI(pth!);


            if (cfgs.Count() > 0)
            {
                foreach (var cf in cfgs)
                {
                    using (var reader = new StreamReader(cf.FullName))
                    {
                        var rd = await reader.ReadToEndAsync();

                        if (rd != null)
                        {
                            var fi = JsonSerializer.Deserialize<FolderInfo>(rd!);

                            if (fi != null)
                            {
                                Folders.Add(fi);
                                fi.FullPath = Path.GetDirectoryName(cf.FullName) ?? "";
                                fi.Type = 'D';
                            }
                        }
                    }
                }

                if (Folders.Count > 0)
                {
                    foreach (var folder in Folders)
                    {
                        var fs = Directory.EnumerateFiles(folder.FullPath, "*.json");
                        if (fs.Count() > 0)
                        {
                            foreach (var f in fs)
                            {
                                if (f == "metadata.json")
                                    continue;

                                using (var reader = new StreamReader(f))
                                {
                                    var rd = await reader.ReadToEndAsync();

                                    if (rd != null)
                                    {
                                        var di = JsonSerializer.Deserialize<DocInfo>(rd!);

                                        if (di != null)
                                        {
                                            Docs.Add(di);
                                            di.FullPath = f;
                                            di.Parent = folder;
                                            di.Type = 'F';
                                        }
                                    }
                                }
                            }
                        }
                    }
                }


            }
        }
    }
}