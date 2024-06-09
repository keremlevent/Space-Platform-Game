using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Bu scripti her iki arka plana ayrı ayrı ekledik.Çünkü daha büyük üst sınıfına bu scripti eklemek
//her iki arkaplanın da aynı anda yapışık hareket etmesine neden oluyor.

public class ArkaPlanHareketKontrol : MonoBehaviour
{
    float arkaPlanKonum;
    float mesafe = 10.24f;//iki oyun objesinin orta noktaları arasındaki mesafedir.


    void Start()
    {
        arkaPlanKonum = transform.position.y;//scriptin ekli oldugu en alttaki oyun objesinin konumunu bir değişkene atadık.
        FindObjectOfType<Gezegenler>().GezegenYerlestir(arkaPlanKonum);
    }

    void Update()
    {
        if(arkaPlanKonum + mesafe < Camera.main.transform.position.y)
        {
            ArkaplanYerlestir();
        }
    }

    void ArkaplanYerlestir()
    {
        arkaPlanKonum += (mesafe * 2);//arada 1 adet görsel olduğu için 2 ile çarptık.
        FindObjectOfType<Gezegenler>().GezegenYerlestir(arkaPlanKonum);
        Vector2 yeniPozisyon = new Vector2(0, arkaPlanKonum);
        transform.position = yeniPozisyon;
    }
}
