using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Runtime.InteropServices;
using System;
using System.IO;
public class AnfiteatroScript : baseMostrarBanners
{
    // Start is called before the first frame update
    void Start()
    {
    }
    public RawImage BannerIzq;
    public RawImage BannerDer;
    public RawImage BannerFondoDer;
    public RawImage BannerFondoIzq;
    public RawImage PantallaFondo;

    // Update is called once per frame
    void Update()
    {
        
    }
     public void FocusCanvas (string p_focus) {
    #if !UNITY_EDITOR && UNITY_WEBGL
    if (p_focus == "0") {
        WebGLInput.captureAllKeyboardInput = false;
    } else {
        WebGLInput.captureAllKeyboardInput = true;
    }
    #endif
    }

    void ImagenDb(string url){

         StartCoroutine(JsonRequest(url, (UnityWebRequest req) => {
              var json_text = req.downloadHandler.text;
              Anfiteatro anfiteatro = JsonUtility.FromJson<Anfiteatro>(json_text);                     

                cargarImagen(anfiteatro.BannerDer, this.BannerDer );
                cargarImagen(anfiteatro.BannerIzq, this.BannerIzq );
                cargarImagen(anfiteatro.BannerFondoIzq, this.BannerFondoIzq );
                cargarImagen(anfiteatro.BannerFondoDer, this.BannerFondoDer );
                cargarImagen(anfiteatro.PantallaFondo, this.PantallaFondo );
               

                var imagenes = this.GetChildImagenes("Canvas");
                if (imagenes.Length > 0) {
                    int t = (int)DateTime.Now.Ticks;
                    UnityEngine.Random.InitState( t );
                    foreach ( RawImage image in imagenes ) {
                        image.color = new Color(255,255,255,0);
                    }
                    int n = UnityEngine.Random.Range(0, imagenes.Length);
                    if (!string.IsNullOrWhiteSpace(anfiteatro.Icono)) {
                    StartCoroutine(ImagenRequest(anfiteatro.Icono, (UnityWebRequest req1) => {
                            imagenes[n].texture = DownloadHandlerTexture.GetContent(req1);
                            imagenes[n].color = new Color(255,255,255,225);
                    }));     
                    }
                }

        }));

    }
}

[System.Serializable]
    public class Anfiteatro
    {
        public string Icono;
        public string BannerIzq;
        public string BannerDer;
        public string BannerFondoDer;
        public string BannerFondoIzq;
        public string PantallaFondo;

    }
