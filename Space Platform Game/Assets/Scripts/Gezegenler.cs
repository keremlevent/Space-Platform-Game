using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gezegenler : MonoBehaviour
{
    List<GameObject> gezegenler = new List<GameObject>();
    List<GameObject> kullanilanGezegenler = new List<GameObject>();
    
    void Awake()
    {
        Object[] sprites = Resources.LoadAll("Gezegenler");//Resources.LoadAll() metodu Resources dosyası içindeki tüm sprite'ları bir diziye yükler.
                                                           //LoadAll() metotu tüm içerikleri obje kabul eder bu yüzden array Object tipinde tanımlandı. 
        for (int i = 1; i < 17; i++)//0. obje Gezegenler klasörünün kendisidir.(Diğer 16 tane kalan objemiz var)
        {
            GameObject gezegen = new GameObject();
            SpriteRenderer sRenderer = gezegen.AddComponent<SpriteRenderer>();//Hem component ekledik hem de componenti değişkene aldık.
            sRenderer.sprite = (Sprite)sprites[i];//Obje veri tipini Sprite  veri tipine dönüştürmek için (Sprite) yazdık..
            Color spriteColor = sRenderer.color;//Spriteların parlaklığını ayarlıyoruz.(.a=Alpha yani parlaklık degeri)
            spriteColor.a = 0.5f;
            sRenderer.color = spriteColor;
            gezegen.name = sprites[i].name;
            sRenderer.sortingLayerName = "Gezegen";//Sorting layer scriptten atandı.
                                                   //Sorting Layer'da en üstteki layer en az öncelikli olur.(Ters)
            Vector2 pozisyon = gezegen.transform.position;
            pozisyon.x = -10;
            gezegen.transform.position = pozisyon;
            gezegenler.Add(gezegen);
        }
    }

    public void GezegenYerlestir(float refY)
    {
        float yukseklik = EkranHesaplayicisi.instance.Yukseklik;
        float genislik = EkranHesaplayicisi.instance.Genislik;

        //Koordinat 1. Bölge
        float xDeger1 = Random.Range(0.0f, genislik);
        float yDeger1 = Random.Range(refY, refY + yukseklik);
        GameObject gezegen1 = RandomGezegen();
        gezegen1.transform.position = new Vector2(xDeger1, yDeger1);

        //2.Bölge
        float xDeger2 = Random.Range(-genislik, 0.0f);
        float yDeger2 = Random.Range(refY, refY + yukseklik);
        GameObject gezegen2 = RandomGezegen();
        gezegen2.transform.position = new Vector2(xDeger2, yDeger2);


        //3.Bölge
        float xDeger3 = Random.Range(-genislik, 0.0f);
        float yDeger3 = Random.Range(refY - yukseklik, refY);
        GameObject gezegen3 = RandomGezegen();
        gezegen3.transform.position = new Vector2(xDeger3, yDeger3);


        //4.Bölge
        float xDeger4 = Random.Range(0.0f, genislik);
        float yDeger4 = Random.Range(refY - yukseklik, refY);
        GameObject gezegen4 = RandomGezegen();
        gezegen4.transform.position = new Vector2(xDeger4, yDeger4);
    }

    GameObject RandomGezegen()
    {
        if(gezegenler.Count > 0)
        {
            int random;
            if(gezegenler.Count == 1)//Gezgenler.Count()==0 ise hata vermemesi için if yazdık.
            {
                random = 0;
            } else
            {
                random = Random.Range(0, gezegenler.Count - 1);
            }
            GameObject gezegen = gezegenler[random];
            gezegenler.Remove(gezegen);
            kullanilanGezegenler.Add(gezegen);
            return gezegen;
        } else
        {
            for (int i = 0; i < 8; i++)
            {
                gezegenler.Add(kullanilanGezegenler[i]);
            }
            kullanilanGezegenler.RemoveRange(0, 8);//0'dan 7. indise kadar olan elemanları kaldırır.
            int random = Random.Range(0, 8);
            GameObject gezegen = gezegenler[random];
            gezegenler.Remove(gezegen);
            kullanilanGezegenler.Add(gezegen);
            return gezegen;
        }
    }
}
