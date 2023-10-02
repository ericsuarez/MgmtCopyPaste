# MgmtCopyPaste

👽 MgmtCopyPaste is a clipboard management utility designed to simplify copy-paste operations. With this utility, you can keep track of clipboard history and easily copy previous items back to the clipboard. The application is developed in C# and uses WinForms for the graphical user interface.

![GIF](IMG/GIF.gif)

## Features

- **Clipboard History**: Keeps a history of items that you've copied to the clipboard.
- **Pinning**: Allows you to pin important clipboard items so they remain accessible.
- **Clear History**: You can clear the clipboard history with a simple click.
- **Double-Click to Copy**: Easily copy any item from the history back to the clipboard with a double-click.
- **Visual Feedback**: Provides visual feedback when an item is copied to the clipboard.
- **Sequential Shift+Click Copying**: Sequential Shift+Click copying mechanism. By pressing Shift and performing a single click, the first item from the clipboard history is copied. With Shift and two clicks, the second item is copied, and so on. This unique feature significantly streamlines the process of selecting and copying previous clipboard items, making your copy-paste tasks swift and effortless.

## Getting Started

### Prerequisites

- .NET Framework

### Building

- Open the solution in Visual Studio.
- Build the solution to produce the `MgmtCopyPaste.exe` executable.

### Usage

1. Run `MgmtCopyPaste.exe`.
2. The application will start monitoring the clipboard.
3. Any text you copy will be added to the clipboard history which can be viewed in the main window.
4. You can double-click on any item in the history to copy it back to the clipboard.
5. Right-clicking on an item in the history will show a context menu allowing you to pin the item or clear the clipboard history.
6. To quickly copy items from the clipboard history, use the Shift+Click feature: Press Shift and perform a single click to copy the first item, Shift plus two clicks for the second item, and so on. This feature is especially useful when dealing with multiple clipboard items in rapid succession.




