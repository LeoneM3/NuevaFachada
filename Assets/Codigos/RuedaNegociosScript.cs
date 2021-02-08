using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
public class RuedaNegociosScript : baseMostrarBanners
{
    
    void Start()
    {
       
    }

    public RawImage Banner1;
    public RawImage Banner2;
    public RawImage Banner3;
    public RawImage Banner4;
    public RawImage Banner5;
    public RawImage Banner6;
    public RawImage Banner7;

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
              RuedaNegocios anfiteatro = JsonUtility.FromJson<RuedaNegocios>(json_text);                     
              /**
                
              **/
              cargarImagen(anfiteatro.Banner1, this.Banner1 );
              cargarImagen(anfiteatro.Banner1, this.Banner2 );

              cargarImagen(anfiteatro.Banner2, this.Banner3 );
              cargarImagen(anfiteatro.Banner2, this.Banner4 );
              cargarImagen(anfiteatro.Banner3, this.Banner5 );
              cargarImagen(anfiteatro.Banner4, this.Banner6 );
              cargarImagen(anfiteatro.Banner5, this.Banner7 );

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
                            if (req1.result == UnityWebRequest.Result.Success) {
                                imagenes[n].texture = DownloadHandlerTexture.GetContent(req1);
                                imagenes[n].color = new Color(255,255,255,225);
                            }
                    }));     
                    }
                }

        }));

    }

}

[System.Serializable]
    public class RuedaNegocios
    {
        public string Banner1;
        public string Banner2;
        public string Banner3;
        public string Banner4;
        public string Banner5;
        public string Icono;

    }
