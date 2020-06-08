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


    internal Dictionary<string, Diagnostic> getDiagnostics()
    {
        Dictionary <string,Diagnostic> diagnostics = PatientDiagnosis.getAllDiagnosisForPatient(this.id);
        return diagnostics;
    }

    public Patient(int id, string name)
    {
        this.id = "p00000000" + id;
        this.name = name;
    }
    //public Patient(int id, string name, Diseases suit)
    //{
    //    this.id = "p00000000" + id;
    //    this.name = name;
    //}
    public static Patient get(string id)
    {
        Debug.Log("number of patients: " + patientsList.Count );
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
        if(patientsList.Count == 0) readAll();
        return patientsList;
    }
    static void readAll()
    {
        TextAsset patientsData = (TextAsset)Resources.Load("patientsData");
        string txt = patientsData.text;
        int i = 0;
        string[] lines = patientsData.text.Split('\n');
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
            Patient p = JsonUtility.FromJson<Patient>(l);
            if (p != null)
            {
                Debug.Log(p.name);
                patientsList.Add(p);
            }
            i++;
        }
    }
}
