using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzikKontrol : MonoBehaviour
{
    public static MuzikKontrol instance;

    AudioSource audioSource;
    
    void Awake()
    {
        Singleton();
        audioSource = GetComponent<AudioSource>();
    }

    void Singleton()
    {
        if(instance != null)//instance örnek demektir.
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
            DontDestroyOnLoad(instance);//Bu metot sayesinde sahneler arasında geçişte bu instance yok edilmez.
                                        //Tüm sahnelerde müzik çalacak.
        }
    }

    public void MuzikCal(bool play)
    {
        if(play)
        {
            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        } else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
