using System.Text.RegularExpressions;
using TagLibFile = TagLib.File;
using File = System.IO.File;

namespace ArGsFolderOrganizer;

public static partial class FolderOrganizer
{
    private static readonly string[] _musicExtensions = [".mp3", ".wav", ".flac", ".m4a"];

    [GeneratedRegex(@"^\P{L}+", RegexOptions.CultureInvariant)]
    private static partial Regex LeadingNonAlphabetRegex();

    [GeneratedRegex(@"\s*\[.*?\]\s*", RegexOptions.CultureInvariant)]
    private static partial Regex BracketContentRegex();

    [GeneratedRegex(@"^.+ - .+$", RegexOptions.CultureInvariant)]
    private static partial Regex ArtistTitlePatternRegex();

    public static Task OrganizeByTypeAsync(string folderPath)
    {
        return Task.Run(() =>
        {
            var originalSubs = Directory.EnumerateDirectories(folderPath).ToList();

            foreach (var file in Directory.EnumerateFiles(folderPath))
            {
                var ext = Path.GetExtension(file)?.TrimStart('.').ToLowerInvariant();
                if (string.IsNullOrWhiteSpace(ext))
                    continue;

                var destDir = Path.Combine(folderPath, ext);
                Directory.CreateDirectory(destDir);
                var dest = Path.Combine(destDir, Path.GetFileName(file));

                HandleMove(file, dest);
            }

            foreach (var sub in originalSubs)
            {
                OrganizeByTypeAsync(sub).Wait();
            }
        });
    }

    public static Task CleanMusicNamesAsync(string folderPath)
    {
        return Task.Run(() =>
        {
            var originalSubs = Directory.EnumerateDirectories(folderPath).ToList();

            foreach (var file in Directory.EnumerateFiles(folderPath))
            {
                var ext = Path.GetExtension(file)?.ToLowerInvariant();
                if (!_musicExtensions.Contains(ext))
                    continue;

                var name = Path.GetFileNameWithoutExtension(file);
                var clean = LeadingNonAlphabetRegex().Replace(name, "");
                if (clean.Equals(name, StringComparison.OrdinalIgnoreCase))
                    continue;
                if (string.IsNullOrWhiteSpace(clean))
                {
                    RenameMusicFileByTagsAsync(file);
                    continue;
                }

                var dest = Path.Combine(Path.GetDirectoryName(file)!, clean + ext);
                HandleMove(file, dest);
            }

            foreach (var sub in originalSubs)
            {
                CleanMusicNamesAsync(sub).Wait();
            }
        });
    }

    public static Task TrimSpacesAsync(string folderPath)
    {
        return Task.Run(() =>
        {
            var originalSubs = Directory.EnumerateDirectories(folderPath).ToList();

            foreach (var file in Directory.EnumerateFiles(folderPath))
            {
                var name = Path.GetFileNameWithoutExtension(file);
                var trimmed = name.Trim();
                if (trimmed.Equals(name, StringComparison.OrdinalIgnoreCase))
                    continue;

                var ext = Path.GetExtension(file);
                var dest = Path.Combine(Path.GetDirectoryName(file)!, trimmed + ext);
                HandleMove(file, dest);
            }

            foreach (var sub in originalSubs)
            {
                TrimSpacesAsync(sub).Wait();
            }
        });
    }

    public static Task ReplaceUnderscoresAsync(string folderPath)
    {
        return Task.Run(() =>
        {
            var originalSubs = Directory.EnumerateDirectories(folderPath).ToList();

            foreach (var file in Directory.EnumerateFiles(folderPath))
            {
                var name = Path.GetFileNameWithoutExtension(file);
                var replaced = name.Replace('_', ' ');
                if (replaced.Equals(name, StringComparison.OrdinalIgnoreCase))
                    continue;

                var ext = Path.GetExtension(file);
                var dest = Path.Combine(Path.GetDirectoryName(file)!, replaced + ext);
                HandleMove(file, dest);
            }

            foreach (var sub in originalSubs)
            {
                ReplaceUnderscoresAsync(sub).Wait();
            }
        });
    }

    public static Task RemoveBracketsAsync(string folderPath)
    {
        return Task.Run(() =>
        {
            var originalSubs = Directory.EnumerateDirectories(folderPath).ToList();

            foreach (var file in Directory.EnumerateFiles(folderPath))
            {
                var name = Path.GetFileNameWithoutExtension(file);
                var stripped = BracketContentRegex().Replace(name, "");
                if (stripped.Equals(name, StringComparison.OrdinalIgnoreCase) || string.IsNullOrWhiteSpace(stripped))
                    continue;

                var ext = Path.GetExtension(file);
                var dest = Path.Combine(Path.GetDirectoryName(file)!, stripped + ext);
                HandleMove(file, dest);
            }

            foreach (var sub in originalSubs)
            {
                RemoveBracketsAsync(sub).Wait();
            }
        });
    }
    public static Task RenameAllMusicFilesByTagsAsync(string folderPath)
    {
        return Task.Run(() =>
        {
            var originalSubs = Directory.EnumerateDirectories(folderPath).ToList();

            foreach (var file in Directory.EnumerateFiles(folderPath))
            {
                RenameMusicFileByTagsAsync(file);
            }

            foreach (var sub in originalSubs)
            {
                RenameAllMusicFilesByTagsAsync(sub).Wait();
            }
        });
    }
    public static void RenameMusicFileByTagsAsync(string file)
    {
        var ext = Path.GetExtension(file)?.ToLowerInvariant();
        if (!_musicExtensions.Contains(ext))
            return;

        var fileName = Path.GetFileNameWithoutExtension(file);

        if (ArtistTitlePatternRegex().IsMatch(fileName))
            return;

        try
        {
            var tagFile = TagLibFile.Create(file);
            var artist = tagFile.Tag.FirstPerformer ?? tagFile.Tag.Performers.FirstOrDefault() ?? string.Empty;
            var title = tagFile.Tag.Title ?? string.Empty;
            if (string.IsNullOrWhiteSpace(artist) || string.IsNullOrWhiteSpace(title))
                return;

            var newName = $"{artist} - {title}";
            var dest = Path.Combine(Path.GetDirectoryName(file)!, newName + ext);
            HandleMove(file, dest);
        }
        catch
        {
            // skip files without valid tags
        }
    }
    private static void HandleMove(string file, string dest)
    {
        var dir = Path.GetDirectoryName(file)!;

        if (Path.GetDirectoryName(dest)!.Equals(Path.Combine(dir, "duplicate"), StringComparison.OrdinalIgnoreCase))
            return; // skip if dest is in duplicate folder-

        if (!File.Exists(dest))
            File.Move(file, dest);
        else
        {
            var dupDir = Path.Combine(dir, "duplicate");
            Directory.CreateDirectory(dupDir);
            var dupDest = Path.Combine(dupDir, Path.GetFileName(file));
            File.Move(file, dupDest);
        }
    }
}
