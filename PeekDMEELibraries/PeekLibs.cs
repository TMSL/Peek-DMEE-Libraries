using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PeekDCLibrary
{
    public partial class DMEEPeekLibs : Form
    {
        String libraryFileName = "";
        String libraryFolder = "";
        String moduleName = "";
        String libraryFilesFolder = "";
        FileStream inFile;
        FileStream outFile;

        private DcDictionary dictionary = new DcDictionary();
        protected IEnumerable<string> libraryFiles { get; private set; }

        public class LibraryFilesListBoxItem 
        {
            public String FileName { get; set; }
            public String FileFolder { get; set; }
            public String FullPath { get; set; }
        }
         
        public DMEEPeekLibs()
        {
            InitializeComponent();

            // Get the previous filename and library folder from the properties and check if it still exists.
            libraryFileName = Properties.Settings.Default.Filename;
            libraryFilesFolder = Properties.Settings.Default.InitialDirectory;

            GetLibraryFolderFiles();
            LoadLibrary();

            ModulesListBox.Items.Clear();
            Cursor.Current = Cursors.WaitCursor;  // show wait cursor
            UpdateModuleListTextBox();
            Cursor.Current = Cursors.Default;   // clear wait cursor

            menuStrip1.Select();

            Properties.Settings.Default.Save();
        }

        private void GetLibraryFolderFiles()
        {
            if (!File.Exists(libraryFilesFolder + "\\" + libraryFileName))
            {
                libraryFilesFolder = "";
                libraryFileName = "";
                Properties.Settings.Default.InitialDirectory = "";
                Properties.Settings.Default.Filename = "";
            }
            SelectedLibraryTextBox.Text = libraryFilesFolder + "\\" + libraryFileName;
            SelectedLibraryTextBox.Select(0, 0);

            libraryFolder = Properties.Settings.Default.LibraryFolder;
            if (!Directory.Exists(libraryFolder))
            {
                libraryFolder = "";
                Properties.Settings.Default.LibraryFolder = "";
            }

            if (Directory.Exists(libraryFolder))
            {
                libraryFiles = Directory.EnumerateFiles(libraryFolder, "*.lbr", SearchOption.TopDirectoryOnly);
                List<String> libList = new List<string>();
                libList = libraryFiles.ToList<String>();
                LibraryFilesListBox.Items.Clear();

                foreach (String str in libList)
                {
                    String s = str;

                    // extract filename from full path
                    int index = s.LastIndexOf(@"\") + 1;
                    s = str.Substring(index, s.Length - (index));

                    LibraryFilesListBox.DisplayMember = "fileName";
                    LibraryFilesListBox.ValueMember = "fullPath";

                    String x = str.Substring(0, str.LastIndexOf(@"\"));

                    LibraryFilesListBox.Items.Add(new LibraryFilesListBoxItem
                    {
                        FileName = s,
                        FileFolder = str.Substring(0, str.LastIndexOf(@"\")),
                        FullPath = str
                    });
                }
            }
            SetLibraryTextBox.Text = libraryFolder;
            SetLibraryTextBox.Select(0, 0);
        }

        private void ChooseLibraryFile()
        {
            libraryFileName = Properties.Settings.Default.Filename;
            libraryFilesFolder = Properties.Settings.Default.InitialDirectory;

            if (!Directory.Exists(libraryFilesFolder))
            {
                libraryFilesFolder = "";
                libraryFileName = "";
            }

            openFileDialog1.FileName = libraryFileName;
            openFileDialog1.InitialDirectory = libraryFilesFolder;
            openFileDialog1.ShowDialog();
            Cursor.Current = Cursors.Default;

            libraryFileName = openFileDialog1.FileName;

            if (libraryFileName != "")
            {
                Properties.Settings.Default.Filename = libraryFileName;
                if (libraryFileName.Contains("\\"))
                {
                    libraryFilesFolder = libraryFileName.Substring(0, libraryFileName.LastIndexOf("\\"));
                    libraryFileName = libraryFileName.Substring(libraryFileName.LastIndexOf("\\") + 1);
                }
                Properties.Settings.Default.InitialDirectory = libraryFilesFolder;
                Properties.Settings.Default.Filename = libraryFileName;
            }
            Properties.Settings.Default.Save();

            SelectedLibraryTextBox.Text = libraryFilesFolder + "\\" + libraryFileName;
            SelectedLibraryTextBox.Update();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private class DictionaryEntry
        {
            public String name = "";
            public String extension = "";
            public long filePos = 0;
            public int recordOffset = 0;
            public int elementSize = 0;
        }

        private class DcDictionary
        {
            public String fileName = ""; // full path to the library file from which the dictionary was read.
            public int entryCount = 0;
            public int size = 0;
            public List<DictionaryEntry> entries = new List<DictionaryEntry>();
        }

        private List<DcDictionary> dictionaryList = new List<DcDictionary>();

        private String ReadASCIILine(FileStream file, long filePos)
        {
            file.Position = filePos;

            string str = "";
            byte ch;
            while ((ch = (byte)file.ReadByte()) != 0x0D)
            {
                if (ch == 0x1A)
                {
                    str += (char)0x1A;
                    break;
                }
                else
                {
                    str += Convert.ToChar(ch);
                }
            }
            //skip past linefeed, if any
            ch = (byte)file.ReadByte();
            if (ch != 0x0A) filePos -=1;

            return str;
        }

        private int GetDictionary(FileStream inFile, DcDictionary dictionary)
        {
            Byte[] buffer = new Byte[100];
            String str = "";
            int entryCount = 0;
            int recordStartOffset = 0;
            int recordSizeInBytes = 0;

            dictionary.entries.Clear();

            inFile.Read(buffer, 0, 32);

            // Assumes that two-byte binary values in the dictionary portion of the library are 16-bit and little endian.
            // All records in the library start and end on 128-byte boundaries, including the dictionary itself.
            // buffer[14] and [15] are the file offset (in multiples of 128 bytes) to the NEXT record in the library.
            // The first occurrence of the offset thus corresponds to the amount of space taken by the dictionary itself.
            int recordsStart = 128 * Convert.ToInt16(buffer[14] + buffer[15] * 256);

            for (int i = 32; i < recordsStart; i += 32)
            {
                DictionaryEntry entry = new DictionaryEntry();
                long filePos = inFile.Position;
                inFile.Read(buffer, 0, 32);
                if (buffer[0] == 0xFF) break; // no more dictionary entries

                str = Encoding.ASCII.GetString(buffer, 1, 11);
                recordStartOffset = 128 * Convert.ToInt16(buffer[12] + buffer[13] * 256);
                recordSizeInBytes = 128 * Convert.ToInt16(buffer[14] + buffer[15] * 256);

                entry.name = str;
                entry.extension = str.Substring(8, 3).TrimEnd(' '); // extension is last 3 alphanumeric characters, if any.

                entry.recordOffset = recordStartOffset;
                entry.elementSize = recordSizeInBytes;
                entry.filePos = filePos;
                dictionary.entries.Add(entry);

                entryCount++;
            }
            dictionary.size = recordsStart;
            dictionary.entryCount = entryCount;
            return entryCount;
        }

        // search dictionary entries for name starting from startIndex and return
        // index of entry if match found. Return -1 if match not found.
        // Using startIndex supports finding multiple matches. Setting startIndex to 0 will
        // return index of first match.
        private int FindModuleInDictionary(DcDictionary dictionary, String moduleName, int startIndex)
        {
            int index;
            bool found = false;

            for (index = startIndex; index < dictionary.entries.Count; index++)
            {
                if (dictionary.entries[index].name == moduleName)
                {
                    found = true;
                    break;
                }
            }
            if (!found) return -1;
            return index;
        }

        private enum libStatus { LibraryNotFound, ModuleNotFound, ModuleLoaded }

        // Get command lines for module from Library file that corresponds to given dictionary entry.
        // The dictionary object holds the full name and path to the file.
        private libStatus GetModuleFromLibrary(DcDictionary dictionary, DictionaryEntry entry, ref String module)
        {
            String str;

            if (!File.Exists(dictionary.fileName))
            {
                str = String.Format("{0}\r\nFile may have been moved or deleted" +
                                            "since dictionaries were loaded.", libraryFileName);
                str += "  Dictionaries will be automatically reloaded from specified library folder location.";
                MessageBox.Show(str, "Library File Not Found");
                return libStatus.LibraryNotFound;
            }

            FileStream inFile = new FileStream(dictionary.fileName, FileMode.Open, FileAccess.Read);
            inFile.Position = entry.recordOffset;

            String line = "";
            module = "";
            //bool first = true;

            while (inFile.Position < entry.recordOffset + entry.elementSize)
            {
                line = ReadASCIILine(inFile, inFile.Position);
                if (line == ((char)0x1A).ToString()) break;
                module += line + "\r\n";
            }
            return libStatus.ModuleLoaded;
        }

        private void UpdateModuleListTextBox()
        {
            ModulesListBox.Items.Clear();
            foreach (DictionaryEntry entry in dictionary.entries)
            {
                String str = String.Format("0x{0:X4}: ", entry.filePos);
                str = String.Format("[{0}] ", entry.name);
                ModulesListBox.Items.Add(str);
            }
        }

        private void LoadLibraryButton_Click(object sender, EventArgs e)
        {
            ChooseLibraryFile();
            LoadLibrary();

            Cursor.Current = Cursors.WaitCursor;  // show wait cursor
            ModuleDataTextBox.Clear();
            UpdateModuleListTextBox();
            Cursor.Current = Cursors.Default;   // clear wait cursor
        }

        private void LoadLibrary()
        {
            String filePath = libraryFilesFolder + "\\" + libraryFileName;

            if (!File.Exists(libraryFilesFolder + "\\" + libraryFileName))
            {
                libraryFilesFolder = "";
                libraryFileName = "";
                return;
            }
            else
            {
                if (inFile != null) inFile.Close();
                inFile = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                dictionary.fileName = filePath;

                int entryCount = GetDictionary(inFile, dictionary);
            }
        }

        private void ModulesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String str = "";
            string ext = "";
            moduleName = ModulesListBox.SelectedItem.ToString().Substring(1, 11);
            str = moduleName.Substring(0, 8);
            str = str.TrimEnd(' ');
            ext = moduleName.Substring(8, 3);
            ext = ext.TrimEnd(' ');
            if (ext != "") str += "." + ext;
            SelectedModuleTextBox.Text = str;

            ExtractToWindow();
        }
      
        private void ExtractToFileButton_Click(object sender, EventArgs e)
        {
            String str = "";

            saveFileDialog1.FileName = SelectedModuleTextBox.Text;
            str = moduleName;
            DialogResult result = saveFileDialog1.ShowDialog();

            if (result == DialogResult.Cancel) return;
            if (saveFileDialog1.FileName == "") return;

            outFile = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write);

            foreach (DictionaryEntry entry in dictionary.entries)
            {
                if (str == entry.name)
                {
                    inFile.Position = entry.recordOffset;
                    while (inFile.Position < entry.recordOffset + entry.elementSize)
                    {
                        str = ReadASCIILine(inFile, inFile.Position);
                        if (str == ((char)0x1A).ToString()) break;
                        str += "\r\n";
                        outFile.Write(Encoding.ASCII.GetBytes(str), 0, str.Length);
                    }
                    outFile.Close();
                    MessageBox.Show("Extraction completed", "Done");
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (inFile != null) inFile.Close();
            if (outFile != null) outFile.Close();
            Properties.Settings.Default.InitialDirectory = libraryFilesFolder;
            Properties.Settings.Default.LibraryFolder = libraryFolder;
            Properties.Settings.Default.Filename = libraryFileName;
            Properties.Settings.Default.Save();
        }

        private void FindModuleButton_Click(object sender, EventArgs e)
        {
            String str = FindModuleTextBox.Text.ToUpper();

            if (ModulesListBox.Items.Count == 0)
            {
                MessageBox.Show("Select and load a library file first.", "Library not loaded");
                return;
            }

            if (str == "")
            {
                MessageBox.Show("Enter some text in \"search\" box first.", "Search text required");
                return;
            }

            bool found = false;
            if (FindInFileRadioButton.Enabled)
            {
                for (int index = 0; index < ModulesListBox.Items.Count; index++)
                {
                    if (ModulesListBox.Items[index].ToString().Contains(str))
                    {
                        ModulesListBox.SelectedIndex = index;
                        Console.WriteLine(ModulesListBox.SelectedItem.ToString());
                        found = true;
                        break;
                    }
                }
            }

            if (!found) MessageBox.Show("Not found.");

            ModulesListBox.Focus();  
        }

        private void SetLibraryFolderButton_Click(object sender, EventArgs e)
        {
            SetLibraryFolder();
            GetLibraryFolderFiles();
        }

        private void SetLibraryFolder()
        {
            if (!Directory.Exists(libraryFolder)) libraryFolder = "";
            folderBrowserDialog1.ShowDialog();
            if (folderBrowserDialog1.SelectedPath != "")
            {
                libraryFolder = folderBrowserDialog1.SelectedPath;
                SetLibraryTextBox.Text = libraryFolder;
                Properties.Settings.Default.LibraryFolder = libraryFolder;
                Properties.Settings.Default.Save();
            }
        }

        private void ExtractToWindow()
        {
            String str = moduleName;

            int index = FindModuleInDictionary(dictionary, moduleName, 0);
            if (index < 0) return;

            DictionaryEntry entry = dictionary.entries[index];

            String moduleData = "";
            libStatus status = GetModuleFromLibrary(dictionary, entry, ref moduleData);
            ModuleDataTextBox.Clear();
            // FYI: TEXT.LBR apparently holds three different character sets where the first three digits are
            // a number for the character set and the last three are the character value IN OCTAL. Yep. Octal.
            // 40 is SPACE, Octal 144 is lowercase "d". So C001040 is a space while C001144 is a "d", etc.
            // There are no commands in the module for drawing a "space" character. Consequently, the module only contains
            // a cr-lf pair followed by 0x1A pad bytes. This results in an empty display in the "module data" text box.
            // Since this means it's possible for a module to be "empty" rather than display an empty text box (which
            // could look like a bug) the text <empty> is displayed to explictly indicate an empty module record has been encountered.
            if (moduleData.Length <= 2 && moduleData[0] == 0x0D)   // handle display of "empty" module record
            {
                ModuleDataTextBox.Text = "<empty>";
            } else // display module record strings in text box
            {
                ModuleDataTextBox.Text = moduleData.Substring(0, moduleData.Length - 2);  // remove last cr-lf to eliminate blank line in text box
            }
        }

        private void LibraryListBoxItemSelected(object sender, EventArgs e)
        {
            LibraryFilesListBoxItem item = new LibraryFilesListBoxItem();
            item = (LibraryFilesListBoxItem)LibraryFilesListBox.SelectedItem;
            SelectedLibraryTextBox.Text = item.FullPath;
            SelectedModuleTextBox.Clear();
            SelectedModuleTextBox.Update();
            libraryFileName = item.FileName;
            libraryFilesFolder = item.FileFolder;

            LoadLibrary();

            ModuleDataTextBox.Clear();
            Cursor.Current = Cursors.WaitCursor;  // show wait cursor
            UpdateModuleListTextBox();
            Cursor.Current = Cursors.Default;   // clear wait cursor
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
        }
    }
}
