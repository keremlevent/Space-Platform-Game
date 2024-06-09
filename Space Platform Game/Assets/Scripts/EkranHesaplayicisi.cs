using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EkranHesaplayicisi : MonoBehaviour
{
    public static EkranHesaplayicisi instance;//Ekranı hesaplamak için Singleton tekniğini kullanıyoruz.

    float yukseklik;
    float genislik;



    public float Yukseklik
    {
        get
        {
            return yukseklik;
        }
    }

    public float Genislik
    {
        get
        {
            return genislik;
        }
    }


    void Awake()
    {
        //Singleton için if , else if yapısını aasagidaki gibi kullaniyoruz.
        if (instance == null)
        {
            instance = this;
        } else if(instance != this)
        {
            Destroy(gameObject);
        }

        yukseklik = Camera.main.orthographicSize;//yukseklik bu sekilde hesaplanir.
        genislik = yukseklik * Camera.main.aspect;//genislik bu sekilde hesaplanir.
    }

    void Update()
    {
        
    }
}
