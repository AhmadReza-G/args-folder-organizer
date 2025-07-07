# ArG's Folder Organizer

A simple and effective C# tool to organize and clean up your folders.

## Features

* Organize files by their type (extension) into corresponding folders
* Clean music file names by removing unwanted leading characters
* Trim whitespace from file names
* Replace underscores with spaces in file names
* Remove brackets and the content inside them from file names
* Handles duplicates by moving conflicting files to a `duplicate` folder
* Recursively processes subfolders while ignoring newly created ones

## Getting Started

1. Clone or download the repository.
2. Open the solution in Visual Studio.
3. Build and run the application.
4. Select the folder you want to organize.
5. Choose which operations to perform using the checkboxes.
6. Click **Organize** and let the tool do the rest!

## How it works

The app scans your selected folder and its existing subfolders (ignoring folders created during the operation), then applies selected transformations to file names and file locations safely. If a rename conflicts with an existing file, the original file is moved to a `duplicate` folder inside the same directory.

## License

MIT License — see the LICENSE file for details.
