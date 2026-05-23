using UnityEngine;

public class QuitAplikasi : MonoBehaviour
{
    public void KeluarDariGame()
    {
        // 1. Perintah keluar kalau sudah jadi APK di HP Android
        Application.Quit();

        // 2. Perintah biar stop play otomatis pas lo tes di Simulator Unity laptop
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}