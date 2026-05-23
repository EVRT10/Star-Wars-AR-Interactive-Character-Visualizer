using UnityEngine;

public class MajuMundurXWing : MonoBehaviour
{
    [Header("Pengaturan Patroli")]
    public float jarakMaju = 5f; 
    public float kecepatan = 2f;  

    [Header("Koreksi Sumbu Blender")]
    [Tooltip("Centang kalau pesawat jalan mundur")]
    public bool benerinMundur = true; 
    
    [Tooltip("Centang kalau pas putar balik malah jungkir balik/miring")]
    public bool benerinManuver = true;

    private float jarakDitempuh = 0f;
    private bool bolehJalan = false;

    void Update()
    {
        // Tunggu layar di-tap
        if (Input.GetMouseButtonDown(0))
        {
            bolehJalan = true;
        }

        if (bolehJalan)
        {
            float langkah = kecepatan * Time.deltaTime;
            
            // Logika Koreksi Jalan: Kalau aslinya mundur, kita paksa gerak ke arah belakangnya (Vector3.back) biar di layar kelihatan maju
            Vector3 arahMaju = benerinMundur ? Vector3.back : Vector3.forward;
            
            transform.Translate(arahMaju * langkah);
            jarakDitempuh += langkah;

            // Kalau udah nyentuh jarak batas
            if (jarakDitempuh >= jarakMaju)
            {
                // Logika Koreksi Manuver: Muterin sumbu Z lokal, bukan Y lokal
                if (benerinManuver)
                {
                    transform.Rotate(0, 0, 180); 
                }
                else
                {
                    transform.Rotate(0, 180, 0); 
                }
                
                jarakDitempuh = 0f;
            }
        }
    }
}