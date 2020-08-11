using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class FileManager
{
    public static void SaveFile(string fileName, string data)
    {
        //Debug.Log("start file saving: " + fileName);
        string destination = Application.persistentDataPath + "/" + fileName;
        FileStream file;
        //Debug.Log(destination);
        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
        //Debug.Log("end file saving");
    }

    public static string LoadFile(string fileName)
    {
        //Debug.Log($"start loading file:{fileName}...");
        string destination = Application.persistentDataPath + "/" + fileName;
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            return null;
        }

        BinaryFormatter bf = new BinaryFormatter();
        string data = (string)bf.Deserialize(file);
        file.Close();
        //Debug.Log(data);
        //Debug.Log($"loading end.");
        return data;
    }

    internal static bool exists(string fileName)
    {
        string source = Application.persistentDataPath + "/" + fileName;
        if (File.Exists(source)) return true;
        return false;
    }
}
