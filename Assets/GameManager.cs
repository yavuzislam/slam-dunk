using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("---LEVEL TEMEL OBJELER")]
    [SerializeField] private GameObject Platform;
    [SerializeField] private GameObject Pota;
    [SerializeField] private GameObject PotaBuyume;
    [SerializeField] private GameObject[] OzellikOlusmaNoktalari;
    [SerializeField] private AudioSource[] Sesler;
    [SerializeField] private ParticleSystem[] Efektler;

    [Header("---UI OBJELER")]
    [SerializeField] private Image[] GorevGorselleri;
    [SerializeField] private Sprite GorevTamamSprite;
    [SerializeField] private int AtilmasiGerekenTop;
    [SerializeField] private GameObject[] Paneller;
    [SerializeField] private TextMeshProUGUI LevelAd;
    int BasketSayisi;
    float ParmakPozX;
    void Start()
    {
        LevelAd.text = "LEVEL : " + SceneManager.GetActiveScene().name;//aktif sahnenin(level) adi
        for (int i = 0; i < AtilmasiGerekenTop; i++)
        {
            GorevGorselleri[i].gameObject.SetActive(true);
        }
        //Invoke("OzellikOlussun", 3f);//oyun basladýktan 3 saniye sonra calis
    }
    void OzellikOlussun()
    {
        int RandomSayi = Random.Range(0, OzellikOlusmaNoktalari.Length - 1);
        PotaBuyume.transform.position = OzellikOlusmaNoktalari[RandomSayi].transform.position;
        PotaBuyume.SetActive(true);
    }
    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (Input.touchCount > 0)//ekrana dokunma var mý?
            {
                Touch touch = Input.GetTouch(0);// dokunmamý aldý
                Vector3 TouchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));//kamerada dokundu noktayý aldýk
                switch (touch.phase)//touch.phase Parmak dokunuþunun aþamasýný açýklar.
                {
                    case TouchPhase.Began://dokuna baþladýysa
                        ParmakPozX = TouchPosition.x - Platform.transform.position.x;//ekrana dokunduðun nokta ile olatform arasýndaki farký aldýk
                        break;
                    case TouchPhase.Moved://parmak hareket ettiriliyorsa
                        if (TouchPosition.x - ParmakPozX > -1.15 && TouchPosition.x - ParmakPozX < 1.15)
                        {
                            Platform.transform.position = Vector3.Lerp(Platform.transform.position, new Vector3(TouchPosition.x - ParmakPozX,
                                Platform.transform.position.y, Platform.transform.position.z),.5f);
                        }
                        break;
                }
            }
            //if (Input.GetKey(KeyCode.LeftArrow)) //sol ok basildiysa
            //{
            //    if (Platform.transform.position.x > -1.15)
            //        Platform.transform.position = Vector3.Lerp(Platform.transform.position, new Vector3(Platform.transform.position.x - .3f,
            //            Platform.transform.position.y, Platform.transform.position.z), .50f);
            //}
            //else if (Input.GetKey(KeyCode.RightArrow)) //sað ok basildiysa
            //{
            //    if (Platform.transform.position.x < 1.15)
            //        Platform.transform.position = Vector3.Lerp(Platform.transform.position, new Vector3(Platform.transform.position.x + .3f,
            //        Platform.transform.position.y, Platform.transform.position.z), .50f);
            //}
        }
    }
    public void Basket(Vector3 Poz)
    {
        BasketSayisi++;//basket atýldýðý zaman artýcak
        GorevGorselleri[BasketSayisi - 1].sprite = GorevTamamSprite;
        //1.basket index=0 deðiþti  2.basket index=1 deðiþti sýrayla oluyor böyle.
        Efektler[0].transform.position = Poz;
        Efektler[0].gameObject.SetActive(true);
        Sesler[1].Play();
        if (BasketSayisi == AtilmasiGerekenTop)
        {
            Kazandin();
        }
        if (BasketSayisi == 1)
        {
            OzellikOlussun();
        }
    }
    public void Kaybettin()
    {
        Sesler[2].Play();
        Paneller[2].SetActive(true);
        Time.timeScale = 0;
    }
    void Kazandin()
    {
        Sesler[3].Play();
        Paneller[1].SetActive(true);
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        Time.timeScale = 0;
    }
    public void PotaBuyut(Vector3 Poz)
    {
        Efektler[1].transform.position = Poz;
        Efektler[1].gameObject.SetActive(true);
        Sesler[0].Play();
        Pota.transform.localScale = new Vector3(55f, 55f, 55f);
    }
    public void Butonislemleri(string Deger)
    {
        switch (Deger)
        {
            case "Durdur":
                Time.timeScale = 0;
                Paneller[0].SetActive(true);
                break;
            case "DevamEt":
                Time.timeScale = 1;
                Paneller[0].SetActive(false);
                break;
            case "Tekrar":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//o anki sahnenin indexsini tekrar yükleme komutuna attýk
                Time.timeScale = 1;                                              //yani ayný sahneyi tekrar yükledik
                break;
            case "SonrakiLevel":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
            case "Ayarlar":
                //ayarlar paneli ister yap ister yapma
                break;
            case "Cikis":
                Application.Quit();//emin misin paneli yapýlabilir runcontroldeki gibi
                break;

        }
    }
}
