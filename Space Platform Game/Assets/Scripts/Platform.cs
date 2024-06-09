using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    PolygonCollider2D polygonCollider2D;

    float randomHiz;
    bool hareket;

    float min, max;
    
    public bool Hareket
    {
        get
        {
            return hareket;
        }
        set
        {
            hareket = value;
        }
    }


    void Start()
    {
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        

        if (Secenekler.KolayDegerOku() == 1)
        {
            randomHiz = Random.Range(0.2f, 0.8f);
        }

        if (Secenekler.OrtaDegerOku() == 1)
        {
            randomHiz = Random.Range(0.5f, 1.0f);
        }

        if (Secenekler.ZorDegerOku() == 1)
        {
            randomHiz = Random.Range(0.8f, 1.5f);
        }


        float objeGenislik = polygonCollider2D.bounds.size.x / 2;//platform objesinin yatay uzunlugunun yarısını aldık.

        if (transform.position.x > 0)//platform orjinin sağında olursa:
        {
            min = objeGenislik;
            max = EkranHesaplayicisi.instance.Genislik - objeGenislik;
        }
        else//orjinin solunda olursa:
        {
            min = -EkranHesaplayicisi.instance.Genislik + objeGenislik;
            max = -objeGenislik;
        }
    }

    void Update()
    {
        if(hareket)
        {
            float pingPongX = Mathf.PingPong(Time.time * randomHiz, max - min) + min;//Mathf.PingPong() metodu platformların sağa sola salınım yapmasını sağlayan hazır metottur.
                                                                                     //+min başlangıcı belirtmek için eklendi.
            Vector2 pingPong = new Vector2(pingPongX, transform.position.y);
            transform.position = pingPong;
        }
    }

    // Collider metodu bir araç objesinin duvara çarpması amacıyla kullanılırken
    // Trigger metodu yarış çizgisini geçen bir aracı temsil eder.
    // Yani Trigger'da iki obje birbirinin içinden geçer ama colliderlar gene de tetiklenirler.
    void OnTriggerEnter2D(Collider2D collider)//Trigger butonu açıkken kullanılacak collider temas metodu.
    {
        if(collider.gameObject.tag == "Ayaklar")
        {
            GameObject.FindGameObjectWithTag("Player").transform.parent = transform;//Player objesinin platformla
                                                                                    //aynı anda hareket etmesi için platforma child yaptık.
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<OyuncuHareket>().ZiplamayiSifirla();
        }  
    }
}
