using UnityEngine;

public class TogglePanel : MonoBehaviour
{
    [Header("--- PANEL DARTH VADER ---")]
    public GameObject vaderKiri;
    public GameObject vaderKanan;

    [Header("--- PANEL LUKE SKYWALKER ---")]
    public GameObject lukeKiri;
    public GameObject lukeKanan;

    [Header("--- PANEL YODA ---")]
    public GameObject yodaKiri;
    public GameObject yodaKanan;

    [Header("--- PANEL R2D2 ---")]
    public GameObject r2d2Kiri;
    public GameObject r2d2Kanan;

    [Header("--- PANEL X-WING ---")]
    public GameObject xwingKiri;
    public GameObject xwingKanan;

    [Header("--- PANEL AT-AT ---")]
    public GameObject atatKiri;
    public GameObject atatKanan;


    // Fungsi saklar pintar tunggal layar
    public void KlikTombolToggle()
    {
        // 1. Eksekusi Darth Vader
        if (vaderKiri != null && vaderKiri.transform.parent.gameObject.activeInHierarchy)
        {
            vaderKiri.SetActive(!vaderKiri.activeSelf);
            if (vaderKanan != null) vaderKanan.SetActive(!vaderKanan.activeSelf);
        }

        // 2. Eksekusi Luke Skywalker
        if (lukeKiri != null && lukeKiri.transform.parent.gameObject.activeInHierarchy)
        {
            lukeKiri.SetActive(!lukeKiri.activeSelf);
            if (lukeKanan != null) lukeKanan.SetActive(!lukeKanan.activeSelf);
        }

        // 3. Eksekusi Yoda
        if (yodaKiri != null && yodaKiri.transform.parent.gameObject.activeInHierarchy)
        {
            yodaKiri.SetActive(!yodaKiri.activeSelf);
            if (yodaKanan != null) yodaKanan.SetActive(!yodaKanan.activeSelf);
        }

        // 4. Eksekusi R2D2
        if (r2d2Kiri != null && r2d2Kiri.transform.parent.gameObject.activeInHierarchy)
        {
            r2d2Kiri.SetActive(!r2d2Kiri.activeSelf);
            if (r2d2Kanan != null) r2d2Kanan.SetActive(!r2d2Kanan.activeSelf);
        }

        // 5. Eksekusi X-Wing
        if (xwingKiri != null && xwingKiri.transform.parent.gameObject.activeInHierarchy)
        {
            xwingKiri.SetActive(!xwingKiri.activeSelf);
            if (xwingKanan != null) xwingKanan.SetActive(!xwingKanan.activeSelf);
        }

        // 6. Eksekusi AT-AT
        if (atatKiri != null && atatKiri.transform.parent.gameObject.activeInHierarchy)
        {
            atatKiri.SetActive(!atatKiri.activeSelf);
            if (atatKanan != null) atatKanan.SetActive(!atatKanan.activeSelf);
        }

        Debug.Log("BOOM! Semua panel kiri & kanan karakter yang aktif berhasil di-toggle!");
    }
}