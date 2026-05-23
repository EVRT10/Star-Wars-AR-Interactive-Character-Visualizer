using UnityEngine;

public class TapCharacter : MonoBehaviour
{
    private AudioSource audioKarakter;

    void Start()
    {
        // Ngambil komponen AudioSource yang nempel di objek ini
        audioKarakter = GetComponent<AudioSource>();
    }

    // Fungsi bawaan Unity yang kepanggil pas objek ini di-klik/tap
    void OnMouseDown()
    {
        // Kalau audionya ada dan lagi nggak bunyi, play audionya!
        if (audioKarakter != null && !audioKarakter.isPlaying)
        {
            audioKarakter.Play();
            Debug.Log("Karakter disentuh! Audio dimainkan.");
        }
    }
}