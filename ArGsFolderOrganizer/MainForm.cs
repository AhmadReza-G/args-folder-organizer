namespace ArGsFolderOrganizer;

public partial class MainForm : Form
{
    private string _selectedFolder = string.Empty;

    public MainForm()
    {
        InitializeComponent();
    }

    private void BtnSelectFolder_Click(object sender, EventArgs e)
    {
        using var dlg = new FolderBrowserDialog
        {
            Description = "Choose a folder to organize",
            ShowNewFolderButton = true
        };

        if (dlg.ShowDialog(this) != DialogResult.OK)
            return;

        TxtFolderPath.Text = _selectedFolder = dlg.SelectedPath;
    }

    private async void BtnOrganize_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_selectedFolder) || !Directory.Exists(_selectedFolder))
        {
            MessageBox.Show(this,
                "Please select a valid folder first.",
                "No Folder Selected",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }

        BtnOrganize.Enabled = false;
        BtnSelectFolder.Enabled = false;
        UseWaitCursor = true;

        try
        {
            if (ChkOrganizeByType.Checked)
                await FolderOrganizer.OrganizeByTypeAsync(_selectedFolder);

            if (ChkCleanMusicNames.Checked)
                await FolderOrganizer.CleanMusicNamesAsync(_selectedFolder);

            if (ChkTrimSpaces.Checked)
                await FolderOrganizer.TrimSpacesAsync(_selectedFolder);

            if (ChkReplaceUnderscores.Checked)
                await FolderOrganizer.ReplaceUnderscoresAsync(_selectedFolder);

            if (ChkRemoveBrackets.Checked)
                await FolderOrganizer.RemoveBracketsAsync(_selectedFolder);

            if (ChkRemoveBrackets.Checked)
                await FolderOrganizer.RenameAllMusicFilesByTagsAsync(_selectedFolder);

            MessageBox.Show(this,
                "Organization complete!",
                "Done",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this,
                $"Error: {ex.Message}",
                "Organization Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        finally
        {
            BtnOrganize.Enabled = true;
            BtnSelectFolder.Enabled = true;
            UseWaitCursor = false;
        }
    }
}
