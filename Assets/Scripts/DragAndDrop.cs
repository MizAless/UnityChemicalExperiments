using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Vector3 mousePosition;

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
    }

    private void OnMouseUp()
    {

        var component = gameObject.GetComponent<Chemical>().chemicalName;
        var Flasks = GameObject.FindGameObjectsWithTag("Flask");
        var ActiveFlask = Flasks.FirstOrDefault(flask => flask.GetComponent<Flask>().IsActive());
        if (ActiveFlask != null && component != "")
        {
            //if (ActiveFlask.GetComponent<Flask>().chemical == null || ActiveFlask.GetComponent<Flask>().chemical.chemicalName == "NewChemicalElement")
            if (ActiveFlask.GetComponent<Flask>().IsFull())
            {
                ActiveFlask.GetComponent<Flask>().chemical = gameObject.GetComponent<Chemical>();
                ActiveFlask.GetComponent<Flask>().SetFull(false);
                ActiveFlask.GetComponent<Renderer>().material.color = UnityEngine.Color.white;
            }
            else
            {
                var newElement = ActiveFlask.GetComponent<Flask>().chemical.Reaction(gameObject);
                if (newElement != null)
                {
                    ActiveFlask.GetComponent<Flask>().chemical = newElement.GetComponent<Chemical>();
                    ActiveFlask.GetComponent<Renderer>().material.color = newElement.GetComponent<Renderer>().sharedMaterial.color;
                    ActiveFlask.GetComponent<Flask>().SetFull(true);
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
