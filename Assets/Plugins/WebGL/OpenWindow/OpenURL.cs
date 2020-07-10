using UnityEngine;
using UnityEngine.EventSystems;
#if UNITY_WEBGL && !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif

public class OpenURL : MonoBehaviour , IPointerDownHandler
{
    public string url;

#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void openWindow(string url);
#else
    private static void openWindow(string url) { Debug.Log(string.Format("openWindow:{0}", url)); }
#endif

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!string.IsNullOrEmpty(url))
        {
            openWindow(url);
        }
    }
}
