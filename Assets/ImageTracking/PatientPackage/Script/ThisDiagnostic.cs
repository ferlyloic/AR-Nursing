using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThisDiagnostic : MonoBehaviour
{
    public TextMeshPro diagNameTextMesh;
    // Start is called before the first frame update
    void Start()
    {
        diagNameTextMesh.name = this.name;
        diagNameTextMesh.text = this.name;
        Debug.Log(diagNameTextMesh.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
