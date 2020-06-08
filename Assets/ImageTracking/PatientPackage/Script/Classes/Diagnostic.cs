using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diagnostic
{
    static Dictionary<string, Diagnostic> diagnostics = new Dictionary<string, Diagnostic>();
    public string id;
    public string name;

    public Diagnostic(string id, string name)
    {
        this.id = id;
        this.name = name;
    }

    public static Diagnostic get(string id)
    {
        Debug.Log("method get in Diagnostic");
        Debug.Log("All Diag: " + diagnostics.Count);
        foreach(string k in diagnostics.Keys)
        {
            Debug.Log($"diag key: {k}");
            if(k == id) return diagnostics[id];
        }
        Debug.Log($"Diag with id [{id}]not found. null returned.");
        return null;
    }
    public static Dictionary<string, Diagnostic> All()
    {
        if (diagnostics.Count == 0) readAll();
        return diagnostics;
    }
    static void readAll()
    {
        TextAsset diagnosisData = (TextAsset)Resources.Load("diagnosisData");
        string txt = diagnosisData.text;
        int i = 0;
        string[] lines = diagnosisData.text.Split('\n');
        foreach (string line in lines)
        {
            string l = line;
            Debug.Log(l);
            if (i == 0)
            {
                l = "";
            }
            else if (i < lines.Length - 2)
            {
                l = line.Substring(0, line.Length - 1);
            }
            else if (i == lines.Length - 2)
            {
                l = line;
            }
            else if (i >= lines.Length - 1)
            {
                Debug.Log(line.Length - 2);
                l = "";

            }
            Debug.Log(l);
            Diagnostic diagnosis = JsonUtility.FromJson<Diagnostic>(l);
            if (diagnosis != null)
            {
                Debug.Log($"diagnosis = {diagnosis}");
                diagnostics.Add(diagnosis.id, diagnosis);
            }
            i++;
        }
    }
    override
    public string ToString()
    {
        return "{id: \"" + this.id + "\", name: \"" + this.name + "\"}";
    }
}

