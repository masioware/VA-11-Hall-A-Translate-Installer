using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VA_11_Hall_A_Translate_Installer
{
    public static class InstallProcess
    {
        public static bool CheckDefaultPath()
        {
            string default_path = @"C:\Program Files (x86)\Steam\steamapps\common\VA-11 HALL-A";
            return Directory.Exists(default_path);
        }
        public static async Task DownloadFiles(Messenger messenger)
        {
            try
            {
                string file_link = "https://va11halla.blob.core.windows.net/translate/files.zip";
                string output_path = Path.Combine(Path.GetTempPath(), "VA-11 HALL-A");
                string filename = @"\translate.tmp";

                if (!File.Exists(output_path))
                {
                    Directory.CreateDirectory(output_path);
                }

                using FileStream fs = File.Create(output_path + filename);
                
                Uri download_uri = new(file_link);
                HttpClient client = new();

                messenger.Add("Baixando arquivos da traducao...");

                var response = await client.GetAsync(download_uri);
                await response.Content.CopyToAsync(fs);

                messenger.Add($"translate.tmp baixado!");
            }
            catch (Exception ex)
            {
                messenger.Add("Erro na instalacao.");
                MessageBox.Show(ex.Message);
            }
        }
        public static void BackupOriginalFiles(string game_path)
        {

        }
    }
}
