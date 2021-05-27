using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FullScreen : MonoBehaviour
{
    public Toggle toggle;
    public TMP_Dropdown resolutionsDropDown;
    private Resolution[] resolutions;
    
    // Start is called before the first frame update
    void Start()
    {
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }

        CheckResolution();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FullScreenActivater(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }

    public void CheckResolution()
    {
        resolutions = Screen.resolutions; // Almacena en un arreglo las resoluciones de la computadora.
        resolutionsDropDown.ClearOptions(); // Borra las opcioens predefinidas de el Drop
        List<string> options = new List<string>();
        int currentResolution = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(Screen.fullScreen && resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) // Con este if comparamos si la resolucion es la actual que tenemos
            {
                currentResolution = i;
            }
        }

        resolutionsDropDown.AddOptions(options); // Se guardan las opciones en el drop
        resolutionsDropDown.value = currentResolution; // Se escoge la resolucion actual para hacer las modificaciones.
        resolutionsDropDown.RefreshShownValue(); // Actualiza la lista 

        resolutionsDropDown.value = PlayerPrefs.GetInt("resolutionNum", 0);
    }

    public void ChangeResolution(int indexResolution)
    {
        PlayerPrefs.SetInt("resolutionNum", resolutionsDropDown.value);

        Resolution resolution = resolutions[indexResolution];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen); //Esta funcion es la que cambia la resolucion.
    }
}
