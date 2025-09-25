namespace VA_11_Hall_A_Translate_Installer
{
    public static class InstallProcess
    {
        public static bool CheckDefaultPath()
        {
            // Verificando se a pasta  padrão do jogo existe
            string default_path = @"C:\Program Files (x86)\Steam\steamapps\common\VA-11 HALL-A";
            return Directory.Exists(default_path);
        }

        public static async Task DownloadFiles(Messenger messenger)
        {
            // Link da zip da tradução
            string file_link = "https://va11halla.blob.core.windows.net/translate/files.zip";
                
            // Criando diretório temporário de download
            string output_path = Path.Combine(Path.GetTempPath(), "VA-11 HALL-A");
            string filename = @"\translate.tmp";

            if (!File.Exists(output_path))
            {
                Directory.CreateDirectory(output_path);
            }

            // Criando arquivo temporário
            using FileStream fs = File.Create(output_path + filename);
                
            Uri download_uri = new(file_link);
            HttpClient client = new();

            messenger.Add("Baixando arquivos da traducao...");

            // Salvando arquivo
            var response = await client.GetAsync(download_uri);
            await response.Content.CopyToAsync(fs);

            messenger.Add($"translate.tmp baixado!");
        }

        public static bool CheckBackupFolder(string game_path)
        {
            // Verificando se a pasta .\backup existe
            return Directory.Exists(Path.Combine(game_path, ".backup"));
        }

        public static void BackupOriginalFiles(string game_path, Messenger messenger)
        {
            // Criando pasta de backup e ocultando
            string backup_folder = Path.Combine(game_path, ".backup");
            
            DirectoryInfo backup_dir = Directory.CreateDirectory(backup_folder);
            backup_dir.Attributes = FileAttributes.Hidden;

            messenger.Add("Diretorio de Backup criado!");

            // Backup data.win
            string data_win = Path.Combine(game_path, "data.win");

            File.Copy(data_win, Path.Combine(backup_folder, "data.win"), overwrite: true);
            messenger.Add("Backup: data.win");

            // Fazendo backup dos scripts
            string script_source = game_path + @"\scripts";
            string script_target = backup_folder + @"\scripts";

            Utils.CopyFilesRecursively(script_source, script_target);
            messenger.Add(@"Backup: \scripts");

            // Deletando arquivos originais
            File.Delete(data_win);
            Directory.Delete(script_source, recursive: true);
        }

        public static void RestoreBackup(string game_path)
        {
            // Deletando arquivos da tradução
            string data_win = Path.Combine(game_path, "data.win");
            string scripts = game_path + @"\scripts";

            File.Delete(data_win);
            Directory.Delete(scripts, recursive: true);

            // Copiando arquivos da pasta de backup
            string backup_folder = Path.Combine(game_path, ".backup");
            Utils.CopyFilesRecursively(backup_folder, game_path);

            // Excluindo pasta de backup
            Directory.Delete(backup_folder, recursive: true);
        }

        public static void ExtractFiles(string game_path)
        {
            string zip_path = Path.Combine(Path.GetTempPath(), "VA-11 HALL-A");
            string filename = @"\translate.tmp";

            System.IO.Compression.ZipFile.ExtractToDirectory(zip_path + filename, game_path);
        }
    }
}
