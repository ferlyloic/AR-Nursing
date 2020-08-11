using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadPatientData : MonoBehaviour
{
    public TextMeshPro patientName;
    public GameObject diagnosticsGameObject;
    private float lastUpdate =-1;
    // Start is called before the first frame update
    void Start()
    {
        lastUpdate = ARNursingGame.currentTime;
        Debug.Log($"Start creating PatientObject :{this.name}");
        patientName.name = this.name;
        diagnosticsGameObject.name = this.name;
        //print($"This is {patientName.name}");
        patientName.text = Patient.get(this.name).name;
        Debug.Log($"Patient Text Mesh is {patientName.text}");
        Debug.Log("diagnostics for patient: " + diagnosticsGameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (lastUpdate!= ARNursingGame.currentTime)
        {
            Debug.Log("DIFFERENCE FOUND !!!!!!!!!!!!");
            lastUpdate = ARNursingGame.currentTime;
            patientName.text = Patient.get(this.name).name;
            //Patient.get(this.name);

        }
    }
}
