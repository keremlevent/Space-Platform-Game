using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EkrandaTut : MonoBehaviour
{
    void Update()
    {
        //Player objesinin ekrandan taşmamasını sağlayacak kod bloğunu yazalim:
        if (transform.position.x < -EkranHesaplayicisi.instance.Genislik)
        {
            Vector2 temp = transform.position;
            temp.x = -EkranHesaplayicisi.instance.Genislik;
            transform.position = temp;
        }
        if (transform.position.x > EkranHesaplayicisi.instance.Genislik)
        {
            Vector2 temp = transform.position;
            temp.x = EkranHesaplayicisi.instance.Genislik;
            transform.position = temp;
        }
    }
}
