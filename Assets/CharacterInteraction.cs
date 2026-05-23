using UnityEngine;
using UnityEngine.EventSystems; // WAJIB buat deteksi klik

// Kita pake interface IPointerClickHandler biar support Mouse & Layar Sentuh
public class CharacterInteraction : MonoBehaviour, IPointerClickHandler
{
    [Header("Referensi Komponen")]
    // Tarik objek Animator Darth Vader ke sini
    public Animator characterAnimator; 

    [Header("UI Panels yang mau dihilangkan")]
    // Tarik objek "DARTH VADER 2" (Panel Kiri) ke sini
    public GameObject leftInfoPanel;
    // Tarik objek "DARTVADER" (Panel Kanan) ke sini
    public GameObject rightInfoPanel;

    [Header("Pengaturan Animasi")]
    // Nama parameter Trigger di Animator Controller lu
    public string animationTriggerName = "PlayAction"; 

    // Fungsi ini otomatis jalan pas objek 3D (Vader) di-klik/sentuh
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Karakter diklik! Menjalankan aksi...");

        // 1. Jalankan Animasi
        if (characterAnimator != null)
        {
            // Pemicu animasi jalan (pake SetTrigger biar sekali jalan)
            characterAnimator.SetTrigger(animationTriggerName);
        }
        else
        {
            Debug.LogError("Animator belum dipasang di script " + gameObject.name);
        }

        // 2. Hilangkan Panel UI (Lenyap total)
        if (leftInfoPanel != null)
        {
            leftInfoPanel.SetActive(false); // Panel Kiri Hilang
        }

        if (rightInfoPanel != null)
        {
            rightInfoPanel.SetActive(false); // Panel Kanan Hilang
        }
    }
}