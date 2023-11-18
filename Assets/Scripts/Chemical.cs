using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.UI;

public enum EnvType
{
    Acidic,   //Кислотная 
    Alkaline, //Щелочная 
    Neutral,  //Нейтральная
    None
}

public class Chemical : MonoBehaviour
{
    public string chemicalName;
    public GameObject chemical;
    private Compare compare;
    public Material material;
    private EnvType envType;

    // Start is called before the first frame update
    void Start()
    {
        GameObject compareObj = GameObject.Find("Compare");
        compare = compareObj.GetComponent<Compare>();
        gameObject.GetComponentInChildren<TextMesh>().text = chemicalName;
        var pair = compare.EnvTypePairs.FirstOrDefault(pair => pair.element == chemicalName);
        if (pair != null)
        {
            envType = pair.envType;
        }
        else
        {
            envType = EnvType.None;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject Reaction(GameObject other)
    {
        if (other.GetComponent<Chemical>() == null || other.GetComponent<Chemical>().chemicalName == chemicalName)
        {
            return null;
        }
        string otherChemicalName = other.GetComponent<Chemical>().chemicalName;
        var res = compare.ListChimicalsPair.FirstOrDefault(pair => pair.element1 == chemicalName && pair.element2 == otherChemicalName || pair.element2 == chemicalName && pair.element1 == otherChemicalName);

        ColorEnvTypePair indicatorRes;
        if (envType != EnvType.None)
        {
            indicatorRes = compare.IndicatorReactList.FirstOrDefault(pair => pair.elementName == otherChemicalName && pair.envType == envType);
        }
        else
        {
            indicatorRes = compare.IndicatorReactList.FirstOrDefault(pair => pair.elementName == chemicalName && pair.envType == other.GetComponent<Chemical>().envType);
        }
        //var indicatorRes = compare.IndicatorReactList.FirstOrDefault(pair => pair.elementName == chemicalName && pair.element2 == otherChemicalName || pair.element2 == chemicalName && pair.element1 == otherChemicalName);


        if (res != null && res.res != "")
        {
            //Destroy(gameObject);
            //Destroy(other.gameObject);
            chemical.GetComponent<Chemical>().chemicalName = res.res;
            chemical.GetComponent<Renderer>().sharedMaterial.color = UnityEngine.Color.white;
            return chemical;
            //Instantiate(chemical, transform.position, Quaternion.identity);
            //return chemical;
        }

        if (indicatorRes != null && indicatorRes.hexColor != "")
        {
            //Destroy(gameObject);
            //Destroy(other.gameObject);

            var position = transform.position;

            bool isIndicator = chemicalName == "litmus" || chemicalName == "methylorange" || chemicalName == "phenolphthalein";


            if (isIndicator)
            {
                chemical.GetComponent<Chemical>().chemicalName = otherChemicalName;
                position = other.transform.position;
            }
            else
            {
                chemical.GetComponent<Chemical>().chemicalName = chemicalName;
            }
            UnityEngine.Color color = UnityEngine.Color.white;
            if (UnityEngine.ColorUtility.TryParseHtmlString("#" + indicatorRes.hexColor, out color))
            {
                chemical.GetComponent<Renderer>().sharedMaterial.color = color;
            }
            if (!isIndicator)
            {
                //Instantiate(chemical, position, Quaternion.identity);
                
            }


        }

        return chemical;

    }
}
