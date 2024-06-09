﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Scriptin butonu/sprite tanıması için gerekli kütüphane.
using UnityEngine.SceneManagement;//Sahneleri kontrol etmek için kütüphaneyi importladık.

public class MenuKontrol : MonoBehaviour
{

    [SerializeField]
    Sprite[] muzikIkonlar = default;

    [SerializeField]
    Button muzikButon = default;


    // Start is called before the first frame update
    void Start()
    {
        if(Secenekler.KayitVarmi() == false)//Kayıt yoksa otomatik olarak kolay seçeneği seçilir.
        {
            Secenekler.KolayDegerAta(1);
        }
        if(Secenekler.MuzikAcikKayitVarmi() == false)
        {
            Secenekler.MuzikAcikDegerAta(1);
        }
        MuzikAyarlariniDenetle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OyunuBaslat()
    {
        SceneManager.LoadScene("Oyun");//Sahneyi çağırma metodu.
    }

    public void EnYuksekPuan()
    {
        SceneManager.LoadScene("Puan");
    }

    public void Ayarlar()
    {
        SceneManager.LoadScene("Ayarlar");
    }

    public void Muzik()
    {
        if(Secenekler.MuzikAcikDegerOku() == 1)
        {
            Secenekler.MuzikAcikDegerAta(0);//Kapattık.
            MuzikKontrol.instance.MuzikCal(false);//Singleton classları direkt kullanabiliyoruz yani referans almaya gerek yok.(Normalde direkt kullanamayız.)
            muzikButon.image.sprite = muzikIkonlar[0];//Müzik butonuna tıklandığında sprite açılıp kapanır.
        } else
        {
            Secenekler.MuzikAcikDegerAta(1);
            MuzikKontrol.instance.MuzikCal(true);
            muzikButon.image.sprite = muzikIkonlar[1];
        }
    }

    void MuzikAyarlariniDenetle()
    {
        if(Secenekler.MuzikAcikDegerOku() == 1)
        {
            muzikButon.image.sprite = muzikIkonlar[1];
            MuzikKontrol.instance.MuzikCal(true);
        } else
        {
            muzikButon.image.sprite = muzikIkonlar[0];
            MuzikKontrol.instance.MuzikCal(false);
        }
    }
}