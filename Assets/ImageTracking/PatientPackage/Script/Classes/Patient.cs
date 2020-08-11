using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Patient
{
    private static List<Patient> patientsList = new List<Patient>();
    public string id;
    public string name;
    internal static readonly string fileName = "patient.json";

    internal Dictionary<string, Diagnostic> getDiagnostics()
    {
        Dictionary <string,Diagnostic> diagnostics = PatientDiagnosis.getAllDiagnosisForPatient(this.id);
        return diagnostics;
    }

    public Patient(string id, string name)
    {
        this.id = id;
        this.name = name;
    }

    public static Patient get(string id)
    {
        //Debug.Log("number of patients: " + patientsList.Count );
        foreach(Patient p in patientsList)
        {
            if (p.id == id)
            {
                return p;
            }
        }
        return null;
    }
    override
   public string ToString()
    {
        return "{id: \"" + id + "\", name: \"" + name + "\"}";
    }
    public static List<Patient> getAll()
    {
        //if(patientsList.Count == 0)
            readAll();
        return patientsList;
    }
    static void readAll()
    {
        patientsList = new List<Patient>();
        string txt = FileManager.LoadFile(fileName);
        int i = 0;
        txt = txt.Replace("[", "");
        txt = txt.Replace("]", "");
        txt = txt.Replace("},{", "},\n{");
        //Debug.Log(txt);
        string[] lines = txt.Split('\n');
        foreach (string line in lines)
        {
            string l = line;
            //Debug.Log(l);
            
            if (i < lines.Length - 1)
            {
                l = line.Substring(0, line.Length - 1);
            }
            //Debug.Log(l);
            Patient p = JsonUtility.FromJson<Patient>(l);
            if (p != null)
            {
                //Debug.Log(p.name);
                patientsList.Add(p);
            }
            i++;
        }
    }
}
