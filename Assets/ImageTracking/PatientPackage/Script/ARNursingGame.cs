using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARNursingGame : MonoBehaviour
{
    
    public GameObject patientPrefab;
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public List<GameObject>diagnosisPrefabs = new List<GameObject>();
    public static Dictionary<string, GameObject>diagnosisPrefabsDictionary = new Dictionary<string, GameObject>();

    public static string[] ids = new string[] { "1", "2", "3", "4" };
    public static List<Patient> patients = new List<Patient>();
    private void Awake()
    {
        Debug.Log("Awake");
        foreach (GameObject g in diagnosisPrefabs)
        {
            Debug.Log(g.name);
            diagnosisPrefabsDictionary.Add(g.name, g);
        }
    }
    void Start()
    {
        //playersCards.Add(p1Cards);
        PlayPatient();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayPatient()
    {
        patients = GenerateDeck();
        //Vector3 scalingVector = new Vector3(0.4f, 0.4f, 1f);
        //float yOffSet = 0;
        //float zOffSet = 0.03f;
       
        //foreach (Patient patient in patients)
        //{
        //    GameObject newPatient = Instantiate(patientPrefab, new Vector3(transform.position.x - yOffSet, transform.position.y, transform.position.z - zOffSet), Quaternion.identity);
        //    newPatient.name = patient.id;

        //    yOffSet = yOffSet + 6f;
        //    zOffSet = zOffSet + 0f;
        //}
    }

    public static List<Patient> GenerateDeck()
    {
        foreach (KeyValuePair<string, Diagnostic> k_d in Diagnostic.All())
        {
            Debug.Log(k_d.Value);
        }

        foreach (PatientDiagnosis p_d in PatientDiagnosis.All())
        {
            Debug.Log(p_d);
        }
        return Patient.getAll();
    }
}
