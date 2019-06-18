using Microsoft.Win32.SafeHandles;
using Shell32;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace BiPA.Rozszerzenia
{
    /// <summary>
    /// Klasa pozwalająca na działanie na ścieżkach do plików
    /// </summary>
    class PathResolver
    {
        [DllImport("kernel32.dll", EntryPoint = "CreateFileW", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern SafeFileHandle CreateFile(string lpFileName, int dwDesiredAccess, int dwShareMode, IntPtr SecurityAttributes, int dwCreationDisposition, int dwFlagsAndAttributes, IntPtr hTemplateFile);

        [DllImport("kernel32.dll", EntryPoint = "GetFinalPathNameByHandleW", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int GetFinalPathNameByHandle([In] IntPtr hFile, [Out] StringBuilder lpszFilePath, [In] int cchFilePath, [In] int dwFlags);

        private const int CREATION_DISPOSITION_OPEN_EXISTING = 3;
        private const int FILE_FLAG_BACKUP_SEMANTICS = 0x02000000;

        /// <summary>
        /// Metoda pobierająca plik z którego utworzono skrót
        /// </summary>
        /// <param name="shortcutFilename">Nazwa skrótu</param>
        /// <returns>Ścieżkę prowadzącą z skrótu do pliku</returns>
        public string GetShortcutTargetFile(string shortcutFilename)
        {
            string realPath = GetRealPath(shortcutFilename),
                   pathOnly = Path.GetDirectoryName(realPath),
                   filenameOnly = Path.GetFileName(realPath);

            Shell shell = new Shell();
            Folder folder = shell.NameSpace(pathOnly);
            FolderItem folderItem = folder.ParseName(filenameOnly);

            if (folderItem != null)
            {
                ShellLinkObject link = (ShellLinkObject)folderItem.GetLink;

                return link.Path;
            }

            return string.Empty;
        }

        /// <summary>
        /// Metoda pobierająca ścieżkę bezwzględną do pliku
        /// </summary>
        /// <param name="path">Ścieżka do pliku</param>
        /// <returns>Ścieżkę bezwględną ze ścieżki względnej</returns>
        private string GetRealPath(string path)
        {
            if (!Directory.Exists(path) && !File.Exists(path))
            {
                throw new IOException("Path not found");
            }

            DirectoryInfo symlink = new DirectoryInfo(path);
            SafeFileHandle directoryHandle = CreateFile(symlink.FullName, 0, 2, System.IntPtr.Zero, CREATION_DISPOSITION_OPEN_EXISTING, FILE_FLAG_BACKUP_SEMANTICS, System.IntPtr.Zero); //Handle file / folder

            if (directoryHandle.IsInvalid)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            StringBuilder result = new StringBuilder(512);
            int mResult = GetFinalPathNameByHandle(directoryHandle.DangerousGetHandle(), result, result.Capacity, 0);

            if (mResult < 0)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            if (result.Length >= 4 && result[0] == '\\' && result[1] == '\\' && result[2] == '?' && result[3] == '\\')
            {
                return result.ToString().Substring(4);
            }
            else
            {
                return result.ToString();
            }
        }
    }
}
