using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamEkran : MonoBehaviour
{
    void Start()
    {
        // [Arkapalanın tüm ekran çözünürlüklerinde responsive şekilde ayarlanması]
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Vector2 tempScale = transform.localScale;//Transform componentindeki Scale değeri nesnenin eksenlerde kaç katına çıkacağını belirleyen bir çarpandır.
                                                 //Burada arkaplan objesinin scale çarpan değerleri bir vektör değişkene alınır.

        float spriteGenislik = spriteRenderer.size.x;//Objenin x eksenindeki boyutunu belirtir.
        float ekranYukseklik = Camera.main.orthographicSize * 2.0f;//ortohraphicSize kameranın orta noktasının yukarı/aşağı kenara olan uzaklığıdır.
        float ekranGenislik = ekranYukseklik / Screen.height * Screen.width;//Screen.height/Screen.width oyunun çalıştığı cihaza göre değerler alır.
        tempScale.x = ekranGenislik / spriteGenislik;//oran degiskene atanir.
        transform.localScale = tempScale;//Size çarpani editörden degisir.
    }

    void Update()
    {
        
    }
}

//İki sprite objesini birbirine yapıştırmak istiyorsan V tuşuna basılı tutarak kare imleçle yapıştırabilirsin.
