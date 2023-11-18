using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flask : MonoBehaviour
{
    public Chemical chemical;
    private bool isActive = false;
    private bool isFull = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (chemical != null)
        {
            gameObject.GetComponentInChildren<TextMesh>().text = chemical.chemicalName;
        }
        else
        {
            gameObject.GetComponentInChildren<TextMesh>().text = "Empty Flask";
        }

    }

    public void SetFull(bool state)
    {
        isFull = state;
    }

    public bool IsFull() { return isFull; }

    public bool IsActive() { return isActive; }

    private void OnTriggerEnter(Collider other)
    {
        isActive = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isActive = false;
    }


}
