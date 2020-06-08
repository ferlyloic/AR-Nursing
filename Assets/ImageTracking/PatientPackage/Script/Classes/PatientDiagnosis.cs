using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientDiagnosis
{
    public string patient_id;
    public string diagnosis_id;
    static List<PatientDiagnosis> patientDiagnoses = new List<PatientDiagnosis>();
    PatientDiagnosis(string patient_id, string diagnosis_id)
    {
        this.patient_id = patient_id;
        this.diagnosis_id = diagnosis_id;
    }
    public static List<PatientDiagnosis> All()
    {
        if (patientDiagnoses.Count == 0) readAll();
        return patientDiagnoses;
    }

        static void readAll()
        {
            TextAsset patientDiagnosisData = (TextAsset)Resources.Load("patientDiagnosisData");
            string txt = patientDiagnosisData.text;
            int i = 0;
            string[] lines = patientDiagnosisData.text.Split('\n');
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
                PatientDiagnosis patientDiagnosis = JsonUtility.FromJson<PatientDiagnosis>(l);
                if (patientDiagnosis != null)
                {
                    Debug.Log($"diagnosis = {patientDiagnosis}");
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
            Debug.Log(pd.patient_id);
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
