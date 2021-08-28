using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public static LightManager Instance;
    private void Awake() { Instance = this; }

    public Light directionalLight; 
    public Light spotLight;          
    public Light changeableLight;

    public List<float> IntensityDirectional;
    public List<float> IntensitySpot;
    public List<float> IntensityChangeable;

    public List<Color> ColorDirectional;
    public List<Color> ColorSpot;
    public List<Color> ColorChangeable;

    public void Update()
    {
        //≤‚ ‘”√
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            LightTurn(0);
        }
        //≤‚ ‘”√
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            LightTurn(1);
        }
        //≤‚ ‘”√
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            LightTurn(2);
        }
    }


    public void LightTurn(int state)
    {
        directionalLight.intensity = IntensityDirectional[state];
        spotLight.intensity = IntensitySpot[state];
        changeableLight.intensity = IntensityChangeable[state];

        directionalLight.color = ColorDirectional[state];
        spotLight.color = ColorSpot[state];
        changeableLight.color = ColorChangeable[state];
    }

}
