using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

public static class FileManagment
{
    public static T ReadFile<T>(string fileName) where T : class
    {
        string path = GetPath(fileName);

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = File.OpenRead(path);

            var loadedSave = formatter.Deserialize(stream) as T;
            stream.Close();
            return loadedSave;
        }

        return null;
    }

    public static void WriteFile<T>(string fileName, T saveData)
    {
        FileChecking();
        string path = GetPath(fileName);

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = File.OpenWrite(path);

        formatter.Serialize(stream, saveData);
        stream.Close();
    }

    public static void FileChecking()
    {
        List<string> pathElements = new List<string>
        {
            "My Games", "Wonzayy", "Saves"
        };

        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        while (pathElements.Count > 0)
        {
            path = Path.Combine(path, pathElements[0]);
            pathElements.RemoveAt(0);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }
    }

    public static string GetPath(string fileName)
    {
        return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "My Games\\Wonzayy\\Saves\\" + fileName);
    }
}
