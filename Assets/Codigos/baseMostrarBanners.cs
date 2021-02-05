using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class baseMostrarBanners : MonoBehaviour
{
    


    public RawImage[] GetChildImagenes(string ruta) {
         RawImage[] imagenes = {};
        GameObject child = GameObject.Find(ruta);  // parent.transform.Find("Productos").gameObject;
            if (child != null) {
            int total = child.transform.childCount;
             Debug.Log("total de imagenes child" + total.ToString());
                    if (total > 0) {
                    imagenes= new RawImage[total];
                    for (int i  = 0; i < total; i++) {
                            var imagen = child.transform.GetChild(i).GetComponent<RawImage>(); // imagenes[i].GetComponent<RawImage>();
                            imagenes[i] = imagen;
                        }
                }
            }
            
        return imagenes;
    }
    public void cargarImagen( string imagenUrl, RawImage rawImage ) {
            if (!string.IsNullOrWhiteSpace(imagenUrl) && rawImage != null) {
                    StartCoroutine(ImagenRequest(imagenUrl, (UnityWebRequest req1) => {
                        if (req1.result == UnityWebRequest.Result.Success) {
                                rawImage.texture = DownloadHandlerTexture.GetContent(req1);
                        }
                    }));
            }
    }
    
    public IEnumerator JsonRequest(string url, Action<UnityWebRequest> callback)
    {
        using (UnityWebRequest req = UnityWebRequest.Get(url))
        {
            yield return req.SendWebRequest();
            callback(req);
        }
    }
    public IEnumerator ImagenRequest(string url, Action<UnityWebRequest> callback)
    {
        using (UnityWebRequest req = UnityWebRequestTexture.GetTexture(url))
        {
            yield return req.SendWebRequest();
            callback(req);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}