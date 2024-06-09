using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuHareket : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;

    Vector2 velocity;

    [SerializeField]
    float hiz = default;

    [SerializeField]
    float hizlanma = default;

    [SerializeField]
    float yavaslama = default;

    [SerializeField]
    float ziplamaGucu = default;

    [SerializeField]
    int ziplamaLimiti = 3;

    int ziplamaSayisi;

    Joystick joystick;

    JoystickButon joystickButon;

    bool zipliyor;//varsayilan deger 'false' olur.

    void Start()
    {
        joystickButon = FindObjectOfType<JoystickButon>();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        joystick = FindObjectOfType<Joystick>();//Joystick tipinde olan bileşeni bul ve joystick'e ata.
                                                //Böylece sahnedeki joysstickin bize sagladigi ozellikleri kullanabiliriz.
    }

    void Update()
    {
        //** [Platform Depended Compilation] | Platforma Bağlı Durumlar **
#if UNITY_EDITOR
        KlavyeKontrol();
#else
                JoystickKontrol();
#endif
    }

    void KlavyeKontrol()
    {
        float hareketInput = Input.GetAxisRaw("Horizontal");
        Vector2 scale = transform.localScale;

        if(hareketInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInput * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);//Walk animasyonununun bool değerini true yaptık.
            scale.x = 0.3f;//karakter sola bakar.
        } else if(hareketInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInput * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = -0.3f;
        } else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, yavaslama * Time.deltaTime);
            animator.SetBool("Walk", false);
        }

        transform.localScale = scale;
        transform.Translate(velocity * Time.deltaTime);//velocity vektörünü transform bileşenine atadık.

        //Ziplama tusu kontrolü:

        if (Input.GetKeyDown("space"))//Tusa basildiginda
        {
            ZiplamayiBaslat();
        }

        if(Input.GetKeyUp("space"))//Tus birakildiginda
        {
            ZiplamayiDurdur();
        }
    }

    void JoystickKontrol()//*Bu metot sürekli çalışcaktır çünkü Update() metodu içerisindedir.
    {
        float hareketInput = joystick.Horizontal;//[Yukarıdaki KlavyeKontrol() metodundan tek farklı olan kısım.]
        Vector2 scale = transform.localScale;

        if (hareketInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInput * hiz, hizlanma * Time.deltaTime);//MoveTowards (yani ileriye hareket) bir çeşit hazır hareket metodudur.
            animator.SetBool("Walk", true);//Walk animasyonununun bool değerini true yaptık.
            scale.x = 0.3f;//karakter sağa bakar.
        }
        else if (hareketInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInput * hiz, hizlanma * Time.deltaTime);//MoveTowards yani ileriye hareket metodu hazır metottur.
            animator.SetBool("Walk", true);//Walk animasyonununun bool değerini true yaptık.
            scale.x = -0.3f;//karakter sola bakar.
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, yavaslama * Time.deltaTime);
            animator.SetBool("Walk", false);
        }

        transform.localScale = scale;
        transform.Translate(velocity * Time.deltaTime);//velocity vektörünü transform bileşenine atadık.

        if (joystickButon.tusaBasildi == true && zipliyor == false)//JoystickKontrol() parent metodu Update() içerisinde oldugundan dolayı bu blok sürekli calisacaktir.
                                                                   //Bu bloğun surekli calismamasi icin 'zipliyor' degiskeni tanimladik.
        {
            zipliyor = true;//Bu blok 1 kere calissin diye atama yaptik.
            ZiplamayiBaslat();
        }

        if (joystickButon.tusaBasildi == false && zipliyor == true)
        {
            zipliyor = false;
            ZiplamayiDurdur();
        }
    }

    void ZiplamayiBaslat()
    {
        if(ziplamaSayisi < ziplamaLimiti)
        {
            FindObjectOfType<SesKontrol>().ZiplamaSes();
            rb2d.AddForce(new Vector2(0, ziplamaGucu), ForceMode2D.Impulse);//Player objesini ziplatmak için kuvvet metodunu kullandık.
            animator.SetBool("Jump", true);//Ziplama anşmasyonu calissin.
            FindObjectOfType<SliderKontrol>().SliderDeger(ziplamaLimiti, ziplamaSayisi);
        }
    }

    void ZiplamayiDurdur()
    {
        animator.SetBool("Jump", false);
        ziplamaSayisi++;
        FindObjectOfType<SliderKontrol>().SliderDeger(ziplamaLimiti, ziplamaSayisi);
    }

    public void ZiplamayiSifirla()
    {
        ziplamaSayisi = 0;
        FindObjectOfType<SliderKontrol>().SliderDeger(ziplamaLimiti, ziplamaSayisi);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Olum")
        {
            FindObjectOfType<OyunKontrol>().OyunuBitir();
        }
    }

    public void OyunBitti()
    {
        Destroy(gameObject);
    }
}
