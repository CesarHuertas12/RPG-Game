using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // abilita las opciones de interfaz de usuario

public class BrightnessControler : MonoBehaviour
{
    public Slider slider; // Variable para referirse al Slider
    public float sliderValue; // Valor que tendra
    public Image panelBrightness; // Se almacena el panel que cambiara el color;


    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("brightness", 0.5f); // Forma para que se guarde el valor que tenia antes.
        panelBrightness.color = new Color(panelBrightness.color.r, panelBrightness.color.g, panelBrightness.color.b,0.6f - slider.value); // Funciona para cambiar el color y transparencia. 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Funcion para cambiar el valor por el usuario.
    public void ChangeSlider(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("brightness",sliderValue); // Se guarda el valor nuevo cada vez que se modifica el slider.
        panelBrightness.color = new Color(panelBrightness.color.r, panelBrightness.color.g, panelBrightness.color.b, 0.6f - slider.value); //Actualiza el brillo en esta funcion.
    }
}
