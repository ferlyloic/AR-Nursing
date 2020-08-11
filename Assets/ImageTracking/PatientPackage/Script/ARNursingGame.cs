using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;


public class ARNursingGame : MonoBehaviour
{
    //private static readonly string apiURL = "http://192.168.0.195/clinic/public/api/";
    private static readonly string apiURL = "http://dursolid-45138.portmap.host:45138/clinic/public/api/";


    public GameObject patientPrefab;
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public List<GameObject>diagnosisPrefabs = new List<GameObject>();
    public static Dictionary<string, GameObject>diagnosisPrefabsDictionary = new Dictionary<string, GameObject>();
    string response;
    public static List<Patient> patients = new List<Patient>();
    internal static float currentTime = -1;
    private void Awake()
    {
        Debug.Log("Entering Awake method...");
        ////if (!FileManager.exists(Patient.fileName))
        //    FileManager.SaveFile(Patient.fileName, ((TextAsset)Resources.Load("patientsData")).text);
        ////if (!FileManager.exists(Diagnostic.fileName))
        FileManager.SaveFile(Diagnostic.fileName, ((TextAsset)Resources.Load("diagnosisData")).text);
        ////if (FileManager.exists(PatientDiagnosis.fileName))
        FileManager.SaveFile(PatientDiagnosis.fileName, ((TextAsset)Resources.Load("patientDiagnosisData")).text);

        //Debug.Log(FileManager.LoadFile(Patient.fileName));
        //Debug.Log(FileManager.LoadFile(Diagnostic.fileName));
        //Debug.Log(FileManager.LoadFile(PatientDiagnosis.fileName));
        //var json = JSON.Parse();
        //StartCoroutine(GetText());
        //while (response.Length==0) {
        //    print($"response: {response}");
        //}
        FetchData();
        foreach (GameObject g in diagnosisPrefabs)
        {
            Debug.Log(g.name);
            diagnosisPrefabsDictionary.Add(g.name, g);
        }
        currentTime = Time.time;
        Debug.Log("End Awake method.");
    }
    void FetchData()
    {
        StartCoroutine(FetchPatientData());
        //StartCoroutine(FetchDiagnosisData());
        //StartCoroutine(FetchPatientDiagnosisData());
    }
    IEnumerator FetchPatientData()
    {
        // we fetch first the patients.
        UnityWebRequest www = UnityWebRequest.Get(apiURL + "patient");
        var resp = www.SendWebRequest();
           
        yield return resp;
        if (string.IsNullOrEmpty(www.error))
        {
            //Success
        }
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
        // Show results as text
        string response = www.downloadHandler.text;
         //Debug.Log(response);

         // save data into patientData.json
         FileManager.SaveFile(Patient.fileName, response);
        Debug.Log(FileManager.LoadFile(Patient.fileName));
        Debug.Log(Patient.getAll()[0]);
        
        // Or retrieve results as binary data
        //byte[] results = www.downloadHandler.data;
        }
    }
    IEnumerator FetchDiagnosisData()
    {
        // we fetch first the patients.
        UnityWebRequest www = UnityWebRequest.Get(apiURL + "diagnosis");
        var resp = www.SendWebRequest();

        yield return resp;
        if (string.IsNullOrEmpty(www.error))
        {
            //Success
        }
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            string response = www.downloadHandler.text;
            Debug.Log(response);

            // save data into patientData.json
            FileManager.SaveFile(Diagnostic.fileName, response);
            Diagnostic.All();

            // Or retrieve results as binary data
            //byte[] results = www.downloadHandler.data;
        }
    }
    IEnumerator FetchPatientDiagnosisData()
    {
        // we fetch first the patients.
        UnityWebRequest www = UnityWebRequest.Get(apiURL + "patient/diagnosis");
        var resp = www.SendWebRequest();

        yield return resp;
        if (string.IsNullOrEmpty(www.error))
        {
            //Success
        }
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            string response = www.downloadHandler.text;
            Debug.Log(response);

            // save data into patientData.json
            FileManager.SaveFile(PatientDiagnosis.fileName, response);
            PatientDiagnosis.All();

            // Or retrieve results as binary data
            //byte[] results = www.downloadHandler.data;
        }
    }

    void Start()
    {
        foreach (KeyValuePair<string, Diagnostic> k_d in Diagnostic.All())
        {
            Debug.Log(k_d.Value);
        }

        foreach (PatientDiagnosis p_d in PatientDiagnosis.All())
        {
            Debug.Log(p_d);
        }
        Patient.getAll();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - currentTime > 10)
        {
            currentTime = Time.time;
            Debug.Log(Time.time);
            FetchData();
        }
    }
}
