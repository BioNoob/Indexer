using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace Indexer
{
    public class IndxElements
    {
        public List<IndxElement> AllFiles { get; set; }
        public string RootFolderPath { get; set; }
        public IndxElements()
        {
            AllFiles = new List<IndxElement>();
            RootFolderPath = string.Empty;
        }
        public IndxElements(string path)
        {
            RootFolderPath = path;
            AllFiles = new List<IndxElement>();
        }
        public static void SaveIndexes(IndxElements ie)
        {
            Properties.Settings.Default.Indexes = JsonSerializer.Serialize(ie);
            Properties.Settings.Default.Save();
        }
        public static IndxElements LoadInexes() => !string.IsNullOrEmpty(Properties.Settings.Default.Indexes) ? JsonSerializer.Deserialize<IndxElements>(Properties.Settings.Default.Indexes) : null;
    }
    public class IndxElement
    {

        public string FullPath { get; set; }
        public string Name => new FileInfo(FullPath).Name;
        public string Extension  => new FileInfo(FullPath).Extension;
        public string DirPath => new FileInfo(FullPath).DirectoryName;


        public IndxElement()
        {

        }
        public IndxElement(string path)
        {
            FullPath = path;
        }
        public void OpenFolder()
        {
            //Process pr = new Process();
            //pr.StartInfo.FileName = "explorer.exe";
            //pr.StartInfo.UseShellExecute = true;
            //pr.StartInfo.ArgumentList.Add("/select ");
            //pr.StartInfo.ArgumentList.Add(DirPath);
            //pr.Start();
            Process.Start("explorer.exe", $"/select, {FullPath}");
        }
        public void OpenFile()
        {
            Process pr = new Process();
            pr.StartInfo.FileName = FullPath;
            pr.StartInfo.UseShellExecute = true;
            pr.Start();
        }
        public override string ToString()
        {
            return Name;
        }


    }
}
