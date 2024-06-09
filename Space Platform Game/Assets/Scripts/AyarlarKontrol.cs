using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//* [RESPONSIVE YAPIMI] | Unity 401 dersi Puan Sahnesi videosunda açıklanıyor.
//Unity'de arayüzlerin farklı cihazlarda çalışması düzgün görünmesi için iki taktiğmiz var:
// 1)Rect Transform with Anchors
// 2)Canvas Renderer and Scaler Component

public class AyarlarKontrol : MonoBehaviour
{
    public Button kolayButon, ortaButon, zorButon;
    
    void Start()
    {
        if(Secenekler.KolayDegerOku() == 1)//if satırları sayesinde önceden kayıtlı verileri kullanarak butonların durumlarını ayarladık.
        {
            kolayButon.interactable = false;//kolay butonu tekrar seçilemez.
            ortaButon.interactable = true;
            zorButon.interactable = true;
        }
        if(Secenekler.OrtaDegerOku() == 1)
        {
            kolayButon.interactable = true;
            ortaButon.interactable = false;
            zorButon.interactable = true;
        }
        if(Secenekler.ZorDegerOku() == 1)
        {
            kolayButon.interactable = true;
            ortaButon.interactable = true;
            zorButon.interactable = false;
        }
    }

    public void SecenekSecildi(string seviye)
    {
        //[Radio Button] yapmak: (seçilen tekrar seçilemez)
        switch (seviye)
        {
            case "kolay":
                Secenekler.KolayDegerAta(1);
                Secenekler.OrtaDegerAta(0);
                Secenekler.ZorDegerAta(0);
                kolayButon.interactable = false;//kolay butonu tekrar seçilemez.
                ortaButon.interactable = true;
                zorButon.interactable = true;
                break;
            case "orta":
                Secenekler.KolayDegerAta(0);
                Secenekler.OrtaDegerAta(1);
                Secenekler.ZorDegerAta(0);
                kolayButon.interactable = true;
                ortaButon.interactable = false;
                zorButon.interactable = true;
                break;
            case "zor":
                Secenekler.KolayDegerAta(0);
                Secenekler.OrtaDegerAta(0);
                Secenekler.ZorDegerAta(1);
                kolayButon.interactable = true;
                ortaButon.interactable = true;
                zorButon.interactable = false;
                break;
            default:
                break;
        }
    }

    public void AnaMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
