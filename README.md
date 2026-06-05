# Unity Folder Setup Tool

A Unity Editor tool that generates a customisable folder structure 
in new projects with one click.

> Built by [ajsgamedev](https://github.com/ajsgamedev)

 
<img width="447" height="848" alt="image" src="https://github.com/user-attachments/assets/6ee9432c-56d9-4b34-8de8-2caaca1c312c" />

## Features

- ✅ Pre-loaded with common Unity folder names based on best practices
- ✅ Toggle folders on/off before generating
- ✅ Add custom folders
- ✅ Rename any folder directly in the list
- ✅ Remove folders you don't need
- ✅ Skips folders that already exist — safe to run on existing projects

## Installation

### Option 1 — Unity Package (recommended)
1. Download `FolderSetupTool_v1.0.unitypackage` from the latest release
2. Open your Unity project
3. Drag the `.unitypackage` file into the Unity Assets panel
4. Click **Import** when prompted

### Option 2 — Manual
1. Download `FolderSetupWindow.cs`
2. Place it inside an `Editor` folder in your Unity project Assets
3. Unity will compile it automatically

## How to Use

1. Once installed, go to **Tools → Folder Setup** in the Unity menu bar
2. The tool will open with a default set of folders based on Unity best practices
3. **Toggle** folders on or off using the checkboxes
4. **Rename** any folder by clicking directly on the name and typing
5. **Add** a custom folder using the **+ Add Folder** button
6. **Remove** a folder using the **X** button
7. Click **Generate Folders** — only checked folders will be created

## Requirements

- Unity 2021.1 or later
- No additional packages or dependencies required

## Roadmap

- [ ] Select All / Deselect All toggle
- [ ] Save and load custom folder presets
- [ ] Unreal Engine version
