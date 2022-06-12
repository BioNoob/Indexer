using Newtonsoft.Json;
using System;
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
        public static void SaveIndexes(IndxElements ie, string file_to_save)
        {
            File.WriteAllText(file_to_save, JsonConvert.SerializeObject(ie, Formatting.Indented));

            //Properties.Settings.Default.Indexes = JsonSerializer.Serialize(ie);
            //Properties.Settings.Default.Save();
        }
        public static IndxElements LoadInexes(string file_to_load)
        {
            if (File.Exists(file_to_load))
            {
                try
                {
                    var a = JsonConvert.DeserializeObject<IndxElements>(File.ReadAllText(file_to_load));
                    return a;
                }
                catch (Exception)
                {
                    return null;
                }

            }
            else
            {
                return null;
            }

            //!string.IsNullOrEmpty(Properties.Settings.Default.Indexes);
            //JsonSerializer.Deserialize<IndxElements>(Properties.Settings.Default.Indexes);
        }
    }
    public class IndxElement
    {
        public enum Type
        {
            folder,
            file
        }
        public string FullPath { get; set; }
        [JsonIgnore]
        public string Name => new FileInfo(FullPath).Name;
        [JsonIgnore]
        public string Extension => new FileInfo(FullPath).Extension;
        [JsonIgnore]
        public string DirPath => new FileInfo(FullPath).DirectoryName;

        public Type Tp { get; set; }

        public IndxElement? Prnt { get; set; }

        public IndxElement()
        {

        }
        public IndxElement(string path)
        {
            FullPath = path;
        }
        public static bool operator ==(IndxElement a, IndxElement b)
        {
            if (a is null && b is null)
                return true;
            if (a is null)
                return false;
            if (b is null)
                return false;
            if (a.FullPath == b.FullPath && a.Tp == b.Tp)
                return true;
            else
                return false;


        }
        public static bool operator !=(IndxElement a, IndxElement b)
        {
            if (a is null && b is null)
                return false;
            if (a is null)
                return true;
            if (b is null)
                return true;
            if (a.FullPath == b.FullPath && a.Tp == b.Tp)
                return false;
            else
                return true;
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
