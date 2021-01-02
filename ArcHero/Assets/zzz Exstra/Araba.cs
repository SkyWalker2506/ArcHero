using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class Araba : MonoBehaviour
{
    public Transform OnSolT, OnSagT, ArkaSolT, ArkaSagT;
    public WheelCollider OnSolCol, OnSagCol, ArkaSolCol, ArkaSagCol;


    //Hiz dediğin aslında hiz limiti olması lazım public float Hiz;
    public float HizLimiti;
    //Hiz farklı olacak ve gaz ve fren ile değişecek
    public float Hiz = 0;

    //ToolTip, inspector de bu bölümün üstüne mouse ile gelince altta yazan yazıyı göstermeye yarıyor. Istersen diğer değerler için de kullanabilirsin.
    [Tooltip("Hiz, hiz sınırını aşınca onu ne kadar hızlı düşüreceğini ayarlar. Bu değeri deneme yanılma ile artırıp düşürebilirsin")]
    public float HizDüzenleyeci=.1f;

    // public objeler büyük harf ile başlar, Privatelar küçük  
    //public float maxDonusAcisi, donus;
    public float MaxDonusAcisi, Donus;
    public bool OtomatikVites;

    //Range inspectorde verebileceğin değerleri kısıtlar. Bunu kullanarak aralığı belli olan değerlere yanlış değerler verilmesini engelleyebilirsin.
    [Range(-1,6)]
    public int Vites;
    public GameObject ArabaFren;
    public GameObject HizIbresi, HizGostergesi;
    //public float IbreDegeri;

    public int Para, OdenecekPara;

    //public JointMotor motorgücü;
    public Text VitesYazi;
    public Text HizYazi;

    public bool KontakAcikmi;

    //private için _rb yerine sadece küçük harf ile rb yazman yeter 
    private Rigidbody rb;

    public float HizCarpani;

    public bool DireksiyonAktifmi = true;
        //, SagSolYonTuslarıAktifmi = false; Gerek Yok
    public GameObject Direksiyon, YonTuslari;

    public GameObject ımlec;

    public int hizdeger;

    void Start()
    {
        KontakAcikmi = false;
        rb = GetComponent<Rigidbody>();


        MaxDonusAcisi = 30;
        HizLimiti = 25;
        ArabaFren.GetComponent<Rigidbody>().drag = 0;
        OtomatikVites = false;
        Vites = 0;

        if (Vites == 0)
        {
            HizLimiti = 0;
        }
    }

    void Update()
    {
        // -----Eski Kod-----
        /* 
        Direksiyon.SetActive(DireksiyonAktifmi == false);
        YonTuslari.SetActive(SagSolYonTuslarıAktifmi == false);
        if (DireksiyonAktifmi && Input.GetKeyDown(KeyCode.Y))
        {
            DireksiyonAktifmi = false;
            SagSolYonTuslarıAktifmi = true;
        }
        else if (!DireksiyonAktifmi && Input.GetKeyDown(KeyCode.Y))
        {
            DireksiyonAktifmi = true;
            SagSolYonTuslarıAktifmi = false;
        }
        */

        // -----Yeni Kod-----
        Direksiyon.SetActive(DireksiyonAktifmi);
        YonTuslari.SetActive(!DireksiyonAktifmi);
        if ( Input.GetKeyDown(KeyCode.Y))
        {
            DireksiyonAktifmi = !DireksiyonAktifmi;
        }

    }
    void gostergekontroll()
    {

    }
    //private void GostergeKontrol(){
    //	float arac_hiz = Mathf.Abs (speed);
    //	RectTransform _gosterge = ımlec.GetComponent<RectTransform> ();
    //	_gosterge.localEulerAngles = new Vector3 (0, 0, arac_hiz);
    //}


    void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.X)) KontakAcikmi = !KontakAcikmi;
        if (KontakAcikmi)
        {
            Hiz = transform.InverseTransformDirection(rb.velocity).z * -HizCarpani;
            HızıLimitle(HizDüzenleyeci);
            //Bu kısım hız textini değiştiriyor.
            HizYazi.text = Hiz.ToString();

            //otovites ise diyip üst if e yön tuşunu koymamalısın;
            //if (Input.GetKeyDown(KeyCode.DownArrow))
            //{
            //    if (OtomatikVites)
            //    {
            //        HizLimiti = 150;
            //    }
            //    else if (Input.GetKeyDown(KeyCode.LeftArrow))
            //    {
            //        HizLimiti = -25;
            //    }
            //}

            if (OtomatikVites)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    HizLimiti = 150;
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    HizLimiti = -25;
                }
            }

            if (Input.GetKeyDown(KeyCode.W) && Vites == 1)
            {
                HizLimiti = 25;
            }
            else if (Input.GetKeyDown(KeyCode.S) && Vites > 0)
            {
                //Vites = Vites;
                HizLimiti = 0;

                //ArabaFren.GetComponent<Rigidbody> ().drag = 0;
            }
            if (Input.GetKeyDown(KeyCode.W) && Vites == 6)
            {
                HizLimiti = -25;
            }
            else if (Input.GetKeyDown(KeyCode.S) && Vites < 0)
            {
                //Vites = Vites;
                HizLimiti = 0;
            }


            ArkaSolCol.motorTorque = Input.GetAxis("Vertical") * -Hiz;//dikey//
            ArkaSagCol.motorTorque = Input.GetAxis("Vertical") * -Hiz;
            OnSolCol.steerAngle = Input.GetAxis("Horizontal") * MaxDonusAcisi;//yatay//
            OnSagCol.steerAngle = Input.GetAxis("Horizontal") * MaxDonusAcisi;

            //OnSolT.Rotate (OnSolCol.rpm / -60 * 360 * Time.deltaTime, 0, 0);
            //OnSagT.Rotate (OnSagCol.rpm / -60 * 360 * Time.deltaTime, 0, 0);
            ArkaSolT.Rotate(ArkaSolCol.rpm / 60 * 360 * Time.deltaTime, 0, 0);
            ArkaSagT.Rotate(ArkaSagCol.rpm / -60 * 360 * Time.deltaTime, 0, 0);
            //OnSolT.localEulerAngles = new Vector3 (0, OnSolCol.steerAngle, 0);
            //OnSagT.localEulerAngles = new Vector3 (0, OnSagCol.steerAngle, 0);


            Vector3 pozisyon;
            Quaternion aci;
            OnSolCol.GetWorldPose(out pozisyon, out aci);
            OnSolT.position = pozisyon;
            OnSolT.rotation = aci;

            OnSagCol.GetWorldPose(out pozisyon, out aci);
            OnSagT.position = pozisyon;
            OnSagT.rotation = aci;

            ArkaSolCol.GetWorldPose(out pozisyon, out aci);
            ArkaSolT.position = pozisyon;
            ArkaSolT.rotation = aci;

            ArkaSagCol.GetWorldPose(out pozisyon, out aci);
            ArkaSagT.position = pozisyon;
            ArkaSagT.rotation = aci;

            //vitessistemi;//
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (OtomatikVites)
                {
                    OtomatikVites = true;
                }
                else
                {
                    OtomatikVites = false;
                    HizLimiti = 25;
                }
            }
            if (OtomatikVites == false)
            {


                //        PC İÇİN        //
                if (Input.GetKeyDown(KeyCode.F))
                {
                    //Vites = 1;
                    //HizLimiti = 25;
                    //VitesYazi.text = "1";
                    VitesiDeğiştir(1);
                }
                if (Input.GetKeyDown(KeyCode.G))
                {
                    //Vites = 2;
                    //HizLimiti = 50;
                    //VitesYazi.text = "2";
                    VitesiDeğiştir(2);

                }
                if (Input.GetKeyDown(KeyCode.H))
                {
                    //Vites = 3;
                    //HizLimiti = 75;
                    //VitesYazi.text = "3";
                    VitesiDeğiştir(3);

                }
                if (Input.GetKeyDown(KeyCode.J))
                {
                    //Vites = 4;
                    //HizLimiti = 100;
                    //VitesYazi.text = "4";
                    VitesiDeğiştir(4);

                }
                if (Input.GetKeyDown(KeyCode.K))
                {
                    //Vites = 5;
                    //HizLimiti = 125;
                    //VitesYazi.text = "5";
                    VitesiDeğiştir(5);
                }

                if (Input.GetKeyDown(KeyCode.L))
                {
                    //Bu kısmı geri viteste yaptığım gibi değiştirebilirsin istersen
                    Vites = 0;
                    HizLimiti = 0;
                    VitesYazi.text = "N";
                }
                if (Input.GetKeyDown(KeyCode.V))
                {
                    GeriVites();
                    //Vites = ;
                    //HizLimiti = -25;
                    //VitesYazi.text = "R";
                }
            }
            //FREN//
            if (Input.GetKey(KeyCode.Space))
            {
                ArabaFren.GetComponent<Rigidbody>().drag = 1;
                //IbreDegeri -= 7;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                ArabaFren.GetComponent<Rigidbody>().drag = 0;
                //IbreDegeri -= 7;
            }
        }
    }


    //Hızı hız limitine göre sınırlarda tutmak için bu metodu kullanabilirsin
    void HızıLimitle(float hızDeğiştirmeDeğeri)
    {
        if (Hiz > 0 && Hiz > HizLimiti)
            Hiz -= hızDeğiştirmeDeğeri;
        if (Hiz < 0 && Hiz < HizLimiti)
            Hiz += hızDeğiştirmeDeğeri;
    }

    // Eski Vites Sistemi
    //public void vites()
    //        {
    //            if (Vites >= 1)
    //            {

    //                Vites = 1;
    //            }
    //            else
    //            {
    //                //Vites += 1;
    //                Vites = 1;

    //            }
    //            VitesYazi.text = "1";
    //            HizLimiti = 25;
    //            Speed = 25;

    //        }
    //        public void vites1()
    //        {
    //            if (Vites >= 2)
    //            {

    //                Vites = 2;
    //            }
    //            else
    //            {
    //                //Vites += 1;
    //                Vites = 2;

    //            }
    //            VitesYazi.text = "2";
    //            HizLimiti = 50;
    //            Speed = 50;

    //        }
    //        public void vites2()
    //        {
    //            if (Vites >= 3)
    //            {

    //                Vites = 3;
    //            }
    //            else
    //            {
    //                //Vites += 1;
    //                Vites = 3;
    //            }
    //            VitesYazi.text = "3";
    //            HizLimiti = 75;
    //            Speed = 75;
    //        }
    //        public void vites3()
    //        {
    //            if (Vites >= 4)
    //            {

    //                Vites = 4;
    //            }
    //            else
    //            {
    //                //Vites += 1;
    //                Vites = 4;
    //            }
    //            VitesYazi.text = "4";
    //            HizLimiti = 100;
    //            Speed = 100;
    //        }
    //        public void vites4()
    //        {
    //            if (Vites >= 5)
    //            {

    //                Vites = 5;
    //            }
    //            else
    //            {
    //                //Vites += 1;
    //                Vites = 5;
    //            }
    //            VitesYazi.text = "5";
    //            HizLimiti = 125;
    //            Speed = 125;
    //        }
    //        public void vites5()
    //        {
    //            if (Vites <= 6)
    //            {
    //                Vites = 6;
    //            }
    //            else
    //            {
    //                //Vites += 0;
    //                Vites = 0;
    //            }
    //            VitesYazi.text = "N";
    //            HizLimiti = 0;
    //        }


    // Yeni vites ayarı
    public void VitesiDeğiştir(int vites)
    {
        Vites = vites;
        VitesYazi.text = Vites.ToString();
        HizLimiti = 25*Vites;
       //Hızı burdan ayarlamayacaksın
        // Speed = 25;
    }


    //Eski Geri Vites
    //public void vites6()
    //{
    //    if (Vites <= -1)
    //    {
    //        Vites = -1;
    //    }
    //    else
    //    {
    //        //Vites += 0;
    //        Vites = -1;
    //    }
    //    VitesYazi.text = "R";
    //    HizLimiti = -25;

    //}

    public void GeriVites()
    {
            Vites = -1;
        VitesYazi.text = "R";
        HizLimiti = -25;
    }

    // eski Otomatik vites
    //public void vites7()
    //{
    //    if (OtomatikVites)
    //    {
    //        OtomatikVites = false;
    //        HizLimiti = 0;
    //        Vites = 0;
    //        VitesYazi.text = "N";
    //    }
    //    else
    //    {
    //        OtomatikVites = true;
    //        HizLimiti = 150;
    //        VitesYazi.text = "oto";
    //    }
    //}

    //Yeni Otomatik vites Ama normalde otomatik vitesten normal vitese çevirirken bu şekilde direk 0 olmaması lazım.
    //Şimdilik o kısmı kendimce bir şey ile değişiyorum. Sen istersen sonra değiştirirsin.
    public void OtomatikVitesDeğiştirici()
    {
        OtomatikVites = !OtomatikVites;
        if (OtomatikVites)
        {
            HizLimiti = 150;
            VitesYazi.text = "oto";
        }
        else
        {
            VitesiDeğiştir(1+(int)Hiz/25);
        }
    }


    //Eski Kontak
    //public void kontakk()
    //        {
    //            if (KontakAcikmi)
    //            {
    //                KontakAcikmi = false;
    //            }
    //            else
    //            {
    //                KontakAcikmi = true;
    //            }
    //        }
    //        

    // Yeni Kontak
    public void Kontak()
    {
        KontakAcikmi = !KontakAcikmi;
    }

    void OnTriggerEnter(Collider temas)
    {
        if (temas.gameObject.name == "hızsınırı" && Hiz > 50)
        {
            Debug.Log("Hız Sınırını Astınız");
        }
    }
}