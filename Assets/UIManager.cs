using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject mainMenuPanel;
    public GameObject howToPlayPanel;
    public GameObject infoPanel; // Panel yang ada tombol Back saat lagi scan AR

    // Fungsi ini dipanggil otomatis saat game mulai
    void Start()
    {
        // Pastikan pas mulai, cuma Main Menu yang kelihatan
        ShowMainMenu();
    }

    // Fungsi untuk tombol "BACK" atau ke menu utama
    public void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);
        howToPlayPanel.SetActive(false);
        infoPanel.SetActive(false);
    }

    // Fungsi untuk tombol "HOW TO PLAY"
    public void ShowHowToPlay()
    {
        mainMenuPanel.SetActive(false);
        howToPlayPanel.SetActive(true);
        infoPanel.SetActive(false);
    }

    // Fungsi untuk tombol "START SCAN"
    public void StartScan()
    {
        mainMenuPanel.SetActive(false);
        howToPlayPanel.SetActive(false);
        infoPanel.SetActive(true); // Nyalakan UI untuk mode AR (misal ada overlay target/tombol back)
        
        // Catatan: Kamera AR biasanya udah nyala dari awal di background. 
        // Kita cuma perlu menghilangkan UI menu yang nutupin kameranya.
    }

    // Fungsi untuk tombol "QUIT"
    public void QuitGame()
    {
        Debug.Log("Aplikasi Keluar!"); // Ini cuma muncul di Unity Editor buat nge-test
        Application.Quit(); // Ini yang beneran nutup aplikasi pas di-build ke HP/PC
    }
}