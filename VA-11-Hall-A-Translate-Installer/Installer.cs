namespace VA_11_Hall_A_Translate_Installer
{
    public partial class Installer : Form
    {
        string game_path = string.Empty;

        public Installer()
        {
            InitializeComponent();
        }

        private async void btn_install_Click(object sender, EventArgs e)
        {
            // Criando componente de log
            Messenger messenger = new(lb_status_text.Items);

            // Limpando mensagens cache de logs
            messenger.Clear();

            // Desabilitando btn_install e btn_uninstall 
            btn_install.Visible = false;
            btn_uninstall.Visible = false;
            
            btn_install.Enabled = false;
            btn_uninstall.Enabled = false;
            
            try
            {
                // Iniciando processo de instalação
                messenger.Add($"Instalando a Traducao... ");

                // Obtendo diretórios do jogo
                if (InstallProcess.CheckDefaultPath())
                {
                    game_path = @"C:\Program Files (x86)\Steam\steamapps\common\VA-11 HALL-A";
                    messenger.Add("Pasta default localizada");
                }
                else
                {
                    messenger.Add("Pasta default não localizada");
                
                    DialogResult result = folderBrowserDialog.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                    {
                        game_path = folderBrowserDialog.SelectedPath;
                        messenger.Add("Pasta selecionada com sucesso!");
                    }
                }

                // Realizando verificação se a tradução já foi instalada
                if (InstallProcess.CheckBackupFolder(game_path))
                {
                    messenger.Add(@"Backup: Pasta \.backup ja existe");
                    throw new Exception("A traducao ja esta instalada");
                }

                // Realizando backup de arquivos do jogo
                InstallProcess.BackupOriginalFiles(game_path, messenger);
                
                // Fazendo download dos arquivos da tradução
                await InstallProcess.DownloadFiles(messenger);

                // Descompactando arquivos da tradução
                InstallProcess.ExtractFiles(game_path);
                messenger.Add("Traducao instalada com sucesso!!!");
            }
            catch (Exception ex)
            {
                messenger.Add("Ocorreu um erro durante a instalacao");
                MessageBox.Show(ex.Message);
            }

            // Habilitando btn_install e btn_uninstall 
            btn_install.Visible = true;
            btn_uninstall.Visible = true;

            btn_install.Enabled = true;
            btn_uninstall.Enabled = true;
        }

        private void btn_uninstall_Click(object sender, EventArgs e)
        {
            // Criando componente de log
            Messenger messenger = new(lb_status_text.Items);

            // Limpando mensagens cache de logs
            messenger.Clear();

            // Desabilitando btn_install e btn_uninstall 
            btn_install.Visible = false;
            btn_uninstall.Visible = false;

            btn_install.Enabled = false;
            btn_uninstall.Enabled = false;

            try
            {
                // Iniciando processo de desinstalação
                messenger.Add($"Desinstalando a Traducao... ");

                // Obtendo diretórios do jogo
                if (InstallProcess.CheckDefaultPath())
                {
                    game_path = @"C:\Program Files (x86)\Steam\steamapps\common\VA-11 HALL-A";
                    messenger.Add("Pasta default localizada");
                }
                else
                {
                    messenger.Add("Pasta default não localizada");

                    DialogResult result = folderBrowserDialog.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                    {
                        game_path = folderBrowserDialog.SelectedPath;
                        messenger.Add("Pasta selecionada com sucesso!");
                    }
                }

                if (!InstallProcess.CheckBackupFolder(game_path))
                {
                    throw new Exception("Pasta de backup não foi encontrada");
                }

                InstallProcess.RestoreBackup(game_path);
                messenger.Add("Os arquivos do jogo foram restaurados com sucesso!");
            }
            catch (Exception ex)
            {
                messenger.Add("Ocorreu um erro durante a desinstalacao");
                MessageBox.Show(ex.Message);
            }

            // Habilitando btn_install e btn_uninstall 
            btn_install.Visible = true;
            btn_uninstall.Visible = true;

            btn_install.Enabled = true;
            btn_uninstall.Enabled = true;
        }
    }
}