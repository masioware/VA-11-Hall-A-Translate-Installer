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
            Messenger messenger = new(lb_status_text.Items);
            messenger.Add($"Instalando a Traducao... ");

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
                else
                {
                    messenger.Add("Pasta selecionada invalida");
                    return;
                }

            }

            //await InstallProcess.DownloadFiles(messenger);
        }
    }
}