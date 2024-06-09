using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;//Biz importladık.

public class JoystickButon : MonoBehaviour, IPointerDownHandler, IPointerUpHandler//Interfaceler mobil platformda buton sayesinde karakterin ziplamasi icin tanımlanır.
                                                                                  //Interfacein kullaniabilmesi icin bu scripti butonona component olarak ekledik.
{
    [HideInInspector]//Asagidaki degisken public olsa dahi inspectorda gözükmesin diye yazildi.
    public bool tusaBasildi;

    public void OnPointerDown(PointerEventData eventData)//Butona basildiginda calisacak interface.
    {
        
        tusaBasildi = true;
    }

    public void OnPointerUp(PointerEventData eventData)//Buton birakildiginda calisacak interface.
    {
        tusaBasildi = false;
    }
}
