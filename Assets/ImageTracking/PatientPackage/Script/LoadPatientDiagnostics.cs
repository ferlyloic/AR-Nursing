﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPatientDiagnostics : MonoBehaviour
{
    public GameObject defaultDiagnosticGameObject;
    public List<GameObject> diagnosisGameObjects = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("method start in " + this.GetType());
        Debug.Log(this.name);
        Patient p = Patient.get(this.name);
        Debug.Log(p);
        Debug.Log("number of diagnostic: " + p.getDiagnostics().Count);
        Vector3 scalingVector = new Vector3(0.4f, 0.4f, 1f);
        float yOffSet = 0;
        float zOffSet = 0.03f;
       
        foreach (KeyValuePair<string,Diagnostic> diagnostic in p.getDiagnostics())
        {
            Debug.Log(defaultDiagnosticGameObject);
            Debug.Log(diagnostic.Value);
            Debug.Log($"diag in Dictionary: {ARNursingGame.diagnosisPrefabsDictionary[diagnostic.Value.name]}");
            defaultDiagnosticGameObject.name = diagnostic.Value.name;
            Debug.Log("destroy default diagnostic");
            Destroy(defaultDiagnosticGameObject);
            Debug.Log("instatiating new Diagnostic");
            defaultDiagnosticGameObject = Instantiate(ARNursingGame.diagnosisPrefabsDictionary[diagnostic.Value.name]);
            Debug.Log("new instance name is:"+defaultDiagnosticGameObject);
            defaultDiagnosticGameObject.transform.SetParent(this.transform);
            defaultDiagnosticGameObject.transform.position = new Vector3(this.transform.position.x
                , this.transform.position.y - 0.1f
                , this.transform.position.z);
            //GameObject newDiagnosisObject = Instantiate(defaultDiagnosticGameObject, new Vector3(transform.position.x - yOffSet, transform.position.y, transform.position.z - zOffSet), Quaternion.identity);
            //newDiagnosisObject.name = diagnostic.Value.name;
            //diagnosisGameObjects.Add(newDiagnosisObject);

            yOffSet = yOffSet + 6f;
            zOffSet = zOffSet + 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
