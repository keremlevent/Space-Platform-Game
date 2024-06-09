using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltinAlgilayici : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Ayaklar")
        {
            GetComponentInParent<Altin>().AltiniKapat();//GetComponentInParent<Altin> Bu scriptin ekli oldugu oyun objesinin parent objesindeki Altin isimli script componentini isaret eder.
            FindObjectOfType<Puan>().AltinKazan();//Scripte erişmenin hızlı yoludur.GetComponent'e gerek kalmadı.
        }
    }
}
