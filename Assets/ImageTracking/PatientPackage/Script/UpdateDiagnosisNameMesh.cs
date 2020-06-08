using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateDiagnosisNameMesh : MonoBehaviour
{
    //public GameObject diagnosis;
    public TextMeshPro diagnosisNameMesh;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Entering " + this.GetType());
        Debug.Log(this.name);
        Debug.Log(diagnosisNameMesh);
        diagnosisNameMesh.text = this.name.Replace("(Clone)","");
        //Destroy(diagnosisNameMesh);
        //diagnosisNameMesh = Instantiate(diagnosisNameMesh);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
