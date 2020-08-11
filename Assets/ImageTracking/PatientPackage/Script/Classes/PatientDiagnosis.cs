using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientDiagnosis
{
    public string patient_id;
    public string diagnosis_id;
    static List<PatientDiagnosis> patientDiagnoses = new List<PatientDiagnosis>();
    internal static readonly string fileName = "patientDiagnosis.json";

    PatientDiagnosis(string patient_id, string diagnosis_id)
    {
        this.patient_id = patient_id;
        this.diagnosis_id = diagnosis_id;
    }
    public static List<PatientDiagnosis> All()
    {
        //if (patientDiagnoses.Count == 0)
            readAll();
        return patientDiagnoses;
    }

        static void readAll()
        {
        patientDiagnoses = new List<PatientDiagnosis>();
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
                PatientDiagnosis patientDiagnosis = JsonUtility.FromJson<PatientDiagnosis>(l);
                if (patientDiagnosis != null)
                {
                    //Debug.Log($"diagnosis = {patientDiagnosis}");
                    patientDiagnoses.Add(patientDiagnosis);
                }
                i++;
            }
        }

        public static Dictionary<string, Diagnostic> getAllDiagnosisForPatient(string patient_id)
    {
        Debug.Log($"start searching Diagnostics for Patient: {patient_id}");
        Dictionary<string, Diagnostic> result = new Dictionary<string, Diagnostic>();
        foreach(PatientDiagnosis pd in patientDiagnoses)
        {
            //Debug.Log(pd.patient_id);
            if (pd.patient_id == patient_id)
            {
                Debug.Log("found!");
                Diagnostic d = Diagnostic.get(pd.diagnosis_id);
                if (d != null) result.Add(d.id, d);
            }
        }
        return result;
    }
    override
    public string ToString()
    {
        return "{patient_id: \"" + this.patient_id + "\", name: \"" + this.patient_id + "\"}";
    }
}
