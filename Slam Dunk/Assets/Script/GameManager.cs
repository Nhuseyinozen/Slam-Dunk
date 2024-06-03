using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("---LEVEL TEMEL OBJELERÝ")]
    [SerializeField] private GameObject Platform;
    [SerializeField] private GameObject Pota;
    [SerializeField] private GameObject PotaBuyume;
    [SerializeField] private GameObject[] OzellikOlusmaNoktalari;
    [SerializeField] private AudioSource[] Sesler;
    [SerializeField] private ParticleSystem[] Efektler;
    SceneManager scene;

    [Header("---UI OBJELERÝ")]
    [SerializeField] public Image[] GorevDaire;
    [SerializeField] public Sprite GorevOk;
    [SerializeField] public int AtilmasiGerekenTop;
    [SerializeField] private GameObject[] Paneller;
    [SerializeField] private TextMeshProUGUI LevelSayisi;
    int BasketSayisi;
    float ParmakPozX;






    private void Start()
    {
        LevelSayisi.text = "LEVEL : " + SceneManager.GetActiveScene().name;

        for (int i = 0; i < AtilmasiGerekenTop; i++)

        {
            GorevDaire[i].gameObject.SetActive(true);

            Invoke("OzellikOlustur", 3f);


        }
    }
    void Update()
    {

        if (Time.timeScale != 0)
        {
            if (Input.touchCount > 0)  // Dokunma varmý yokmu ?
            {
                Touch touch = Input.GetTouch(0);  // Dokunmuþ olduðumuz parmak.
                Vector3 TouchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10)); // Parmak pozisyonu.
                // Camera.main.ScreenToWorldPoint PARMAÐIN EKRANDAKÝ POZÝYONU.
                switch (touch.phase) // Parmaðýn durumu.
                {

                    case TouchPhase.Began: // Dokunma Baþladýysa.

                        ParmakPozX = TouchPosition.x - Platform.transform.position.x; // Ýlk dokunduðumuz an.
                        break;

                    case TouchPhase.Moved: // Parmak hareket ettiriliyormu.
                        if (TouchPosition.x - ParmakPozX > -2.25f && TouchPosition.x - ParmakPozX < 2.25f)
                        {
                            Platform.transform.position = Vector3.Lerp(Platform.transform.position,
                            new Vector3(TouchPosition.x - ParmakPozX, Platform.transform.position.y, Platform.transform.position.z), 10f);

                        }
                        break;

                }

            }
        }




        #region Klavye hareket
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{

        //    if (Platform.transform.position.x > -2.25f)
        //    {
        //        Platform.transform.position = Vector3.Lerp(Platform.transform.position, new Vector3(Platform.transform.position.x - .35f,
        //            Platform.transform.position.y, Platform.transform.position.z), .25f);

        //    }

        //}
        //else if (Input.GetKey(KeyCode.RightArrow))
        //{


        //    Vector3 vectorsag = new Vector3(Platform.transform.position.x + .35f,
        //       Platform.transform.position.y, Platform.transform.position.z);


        //    if (Platform.transform.position.x < +2.25f)
        //    {
        //        Platform.transform.position = Vector3.Lerp(Platform.transform.position, vectorsag, .25f);
        //    }
        #endregion
    }

    public void OzellikOlustur()
    {
        int OlusacakDeger = Random.Range(1, 5);



        PotaBuyume.transform.position = OzellikOlusmaNoktalari[OlusacakDeger - 1].transform.position;

        PotaBuyume.SetActive(true);


    }



    public void basket(Vector3 Poz)
    {
        Sesler[1].Play();
        BasketSayisi++;
        Efektler[0].transform.position = Poz;
        Efektler[0].gameObject.SetActive(true);

        GorevDaire[BasketSayisi - 1].sprite = GorevOk;
        if (BasketSayisi == AtilmasiGerekenTop)
        {
            Kazandin();
        }
    }
    public void kaybettiniz()
    {

        Sesler[3].Play();
        Paneller[2].SetActive(true);
        Time.timeScale = 0;
    }

    public void Kazandin()
    {
        Sesler[2].Play();
        Paneller[1].SetActive(true);
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        Time.timeScale = 0;

    }


    public void potabuyutme()
    {
        Sesler[0].Play();
        Efektler[1].transform.position = PotaBuyume.transform.position;
        Efektler[1].gameObject.SetActive(true);
        Pota.transform.localScale = new Vector3(75F, 75F, 75F);

    }

    public void ButonOlaylari(string Deger)
    {
        switch (Deger)
        {
            case "Durdur":
                Time.timeScale = 0;
                Paneller[0].gameObject.SetActive(true);
                break;

            case "DevamEt":
                Time.timeScale = 1;
                Paneller[0].gameObject.SetActive(false);
                break;

            case "Next":

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Time.timeScale = 1;
                break;


            case "Tekrar":

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
                break;

            case "Ayarlar":
                //Ayarlar Paneli
                break;
            case "Cikis":
                Application.Quit();
                break;

            default:
                break;
        }

    }


}
