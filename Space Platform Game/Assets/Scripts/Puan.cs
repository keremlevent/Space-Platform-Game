using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UI objelerini kullanmak istediğimiz durumlarda importlarız.

public class Puan : MonoBehaviour
{
    int puan;
    int enYuksekPuan;

    int altin;
    int enYusekAltin;

    bool puanTopla = true;

    [SerializeField]
    Text puanText = default;


    [SerializeField]
    Text altinText = default;

    [SerializeField]
    Text oyunBittiPuanText = default;


    [SerializeField]
    Text oyunBittiAltinText = default;

    void Start()
    {
        altinText.text = " X " + altin;
    }

    void Update()
    {
        if(puanTopla)
        {
            puan = (int)Camera.main.transform.position.y;//Değişkenin başına (int) yazarsak onun sadece tam sayı kısmını almış oluyoruz.
            puanText.text = "Puan: " + puan;
        }
    }

    public void AltinKazan()
    {
        FindObjectOfType<SesKontrol>().AltinSes();
        altin++;
        altinText.text = " X " + altin;
    }

    public void OyunBitti()
    {
        if(Secenekler.KolayDegerOku() == 1)//En yuksek puanlari zorluklara gore kaydedelim:
        {
            enYuksekPuan = Secenekler.KolayPuanDegerOku();
            enYusekAltin = Secenekler.KolayAltinDegerOku();
            if(puan > enYuksekPuan)
            {
                Secenekler.KolayPuanDegerAta(puan);
            }
            if(altin > enYusekAltin)
            {
                Secenekler.KolayAltinDegerAta(altin);
            }
        }

        if (Secenekler.OrtaDegerOku() == 1)
        {
            enYuksekPuan = Secenekler.OrtaPuanDegerOku();
            enYusekAltin = Secenekler.OrtaAltinDegerOku();
            if (puan > enYuksekPuan)
            {
                Secenekler.OrtaPuanDegerAta(puan);
            }
            if (altin > enYusekAltin)
            {
                Secenekler.OrtaAltinDegerAta(altin);
            }
        }

        if (Secenekler.ZorDegerOku() == 1)
        {
            enYuksekPuan = Secenekler.ZorPuanDegerOku();
            enYusekAltin = Secenekler.ZorAltinDegerOku();
            if (puan > enYuksekPuan)
            {
                Secenekler.ZorPuanDegerAta(puan);
            }
            if (altin > enYusekAltin)
            {
                Secenekler.ZorAltinDegerAta(altin);
            }
        }

        puanTopla = false;
        oyunBittiPuanText.text = "Puan: " + puan;
        oyunBittiAltinText.text = " X " + altin;
    }
}
