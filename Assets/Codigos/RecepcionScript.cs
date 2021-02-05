using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Networking;
using System;
public class RecepcionScript : baseMostrarBanners
{
    
    public RawImage recepcionista1;
    public RawImage recepcionista2;
    public RawImage banner1;
    public RawImage banner2;
    public RawImage PublicidadVert1;
    public RawImage PublicidadVert2;
    public RawImage PublicidadVert3;
    public RawImage PublicidadVert4;
    public RawImage Banderin1;
    public RawImage Banderin2;
    public RawImage Pantalla;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ImagenDb(string url){
        #if !UNITY_EDITOR && UNITY_WEBGL
            WebGLInput.captureAllKeyboardInput = false;
        #endif
        
         StartCoroutine(JsonRequest(url, (UnityWebRequest req) => {
              var json_text = req.downloadHandler.text;
              CentroEvento centroEventos = JsonUtility.FromJson<CentroEvento>(json_text);
              int t = (int)DateTime.Now.Ticks;
              UnityEngine.Random.InitState( t );
                int totalEdecanes = centroEventos.Edecanes.Length;
                int n1 = UnityEngine.Random.Range(0, centroEventos.Edecanes.Length);  
                int n2 = UnityEngine.Random.Range(0, centroEventos.Edecanes.Length); 
                if ( n2 == n1 ) {
                    if ( (totalEdecanes - 1) == n1 ) {
                        n2 = n2 - 1;
                    } else {
                        n2 = n2 + 1;
                    }
                }
                cargarImagen(centroEventos.Edecanes[n1].url, this.recepcionista1 );
                cargarImagen(centroEventos.Edecanes[n2].url, this.recepcionista2 );
                cargarImagen(centroEventos.BannerExpoHorz, this.Pantalla );

                cargarImagen(centroEventos.Banner1, this.banner1 );
                cargarImagen(centroEventos.Banner2, this.banner2 );
                cargarImagen(centroEventos.PublicidadVert1, this.PublicidadVert1 );
                cargarImagen(centroEventos.PublicidadVert2, this.PublicidadVert2 );
                cargarImagen(centroEventos.PublicidadVert3, this.PublicidadVert3 );
                cargarImagen(centroEventos.PublicidadVert4, this.PublicidadVert4 );

                cargarImagen(centroEventos.Banderin1, this.Banderin1 );
                cargarImagen(centroEventos.Banderin1, this.Banderin2 );

        }));

    }

}

[System.Serializable]
public class Edecane
    {
        public string url;
    }
[System.Serializable]
    public class CentroEvento
    {
        public string IdFeriasEventos ;
        public string Nombre_Edificio ;
        public string Direccion ;
        public string LogoDer ;
        public string LogoIzq ;
        public string BannerExpoHorz ;
        public string Banner1;
        public string Banner2;
        public string PublicidadVert1;
        public string PublicidadVert2;
        public string PublicidadVert3;
        public string PublicidadVert4;
        public string Banderin1;
        public string Banderin2;
        public Edecane[] Edecanes ;
    }

