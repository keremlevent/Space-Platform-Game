using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderKontrol : MonoBehaviour
{
    Slider slider;
    
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 1.0f;
    }
    public void SliderDeger(int maxDeger, int gecerliDeger)
    {
        //Sliderın (ziplama barı) görsel ve oransal olarak degismesi icin yazmamiz gereken kod blogu:
        int sliderDeger = maxDeger - gecerliDeger;//cikardik cunku slider kalan hak kadar dolu olacak.
        slider.maxValue = maxDeger;
        slider.value = sliderDeger;
    }
}
