using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlumculPlatform : MonoBehaviour
{

    BoxCollider2D boxCollider2D;

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



    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        randomHiz = Random.Range(0.5f, 1.0f);

        float objeGenislik = boxCollider2D.bounds.size.x / 2;//platform objesinin yatay uzunlugunun yarısını aldık.

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
        if (hareket)
        {
            float pingPongX = Mathf.PingPong(Time.time * randomHiz, max - min) + min;//Mathf.PingPong() metodu platformların sağa sola salınım yapmasını sağlayan hazır metottur.
                                                                                     //+min başlangıcı belirtmek için eklendi.
            Vector2 pingPong = new Vector2(pingPongX, transform.position.y);
            transform.position = pingPong;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Ayaklar")
        {
            FindObjectOfType<OyunKontrol>().OyunuBitir();
        }
    }
}
