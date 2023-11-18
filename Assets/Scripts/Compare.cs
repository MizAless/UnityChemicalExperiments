using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChemPair
{
    public string element1;
    public string element2;
    public string res;

    public ChemPair()
    {
        this.element1 = "";
        this.element2 = "";
        this.res = "";
    }
    public ChemPair(string element1, string element2, string res)
    {
        this.element1 = element1;
        this.element2 = element2;
        this.res = res;
    }

}

public class EnvTypePair
{
    public string element;
    public EnvType envType;

    public EnvTypePair(string element, EnvType envType)
    {
        this.element = element;
        this.envType = envType;
    }

}

public class ColorEnvTypePair
{
    public string elementName;
    public EnvType envType;
    public string hexColor;

    public ColorEnvTypePair(string elementName, EnvType envType, string hexColor)
    {
        this.elementName = elementName;
        this.envType = envType;
        this.hexColor = hexColor;
    }

}

public class Compare : MonoBehaviour
{

    public List<ChemPair> ListChimicalsPair = new List<ChemPair>();
    public List<ColorEnvTypePair> IndicatorReactList = new List<ColorEnvTypePair>();
    public List<EnvTypePair> EnvTypePairs = new List<EnvTypePair>();



    // Start is called before the first frame update
    void Awake()
    {
        /*
        H2O
        H2
        O2
        HCl
        NaOH
        CuSO4
        H2SO4
        NaCl

        litmus лакмус
        methylorange метилоранж
        phenolphthalein фенолфталеин

         */
        EnvTypePairs.Add(new EnvTypePair("H2O", EnvType.Neutral));
        EnvTypePairs.Add(new EnvTypePair("H2", EnvType.Neutral));
        EnvTypePairs.Add(new EnvTypePair("O2", EnvType.Acidic));
        EnvTypePairs.Add(new EnvTypePair("HCl", EnvType.Neutral));
        EnvTypePairs.Add(new EnvTypePair("NaOH", EnvType.Alkaline));
        EnvTypePairs.Add(new EnvTypePair("CuSO4", EnvType.Acidic));
        EnvTypePairs.Add(new EnvTypePair("H2SO4", EnvType.Acidic));
        EnvTypePairs.Add(new EnvTypePair("NaCl", EnvType.Neutral));


        ListChimicalsPair.Add(new ChemPair("HCl", "H2O", "H3O+Cl"));
        ListChimicalsPair.Add(new ChemPair("NaOH", "NaCl", "NaCl+H2O"));
        //ListChimicalsPair.Add(new ChemPair("NaOH", "H2O", "Na+OH"));
        //ListChimicalsPair.Add(new ChemPair("HCl", "H2O", "H3O+Cl"));
        //ListChimicalsPair.Add(new ChemPair("HCl", "H2O", "H3O+Cl"));
        //ListChimicalsPair.Add(new ChemPair("HCl", "H2O", "H3O+Cl"));

        IndicatorReactList.Add(new ColorEnvTypePair("litmus", EnvType.Alkaline, "13516E"));
        IndicatorReactList.Add(new ColorEnvTypePair("methylorange", EnvType.Alkaline, "9B4C00"));
        IndicatorReactList.Add(new ColorEnvTypePair("phenolphthalein", EnvType.Alkaline, "DE52C6"));

        IndicatorReactList.Add(new ColorEnvTypePair("litmus", EnvType.Acidic, "CB6656"));
        IndicatorReactList.Add(new ColorEnvTypePair("methylorange", EnvType.Acidic, "A5A5A5"));
        IndicatorReactList.Add(new ColorEnvTypePair("phenolphthalein", EnvType.Acidic, "FC6767"));

        IndicatorReactList.Add(new ColorEnvTypePair("litmus", EnvType.Neutral, "45A4FF"));
        IndicatorReactList.Add(new ColorEnvTypePair("methylorange", EnvType.Neutral, "A5A5A5"));
        IndicatorReactList.Add(new ColorEnvTypePair("phenolphthalein", EnvType.Neutral, "F06B15"));


    }

    // Update is called once per frame
    void Update()
    {

    }
}
