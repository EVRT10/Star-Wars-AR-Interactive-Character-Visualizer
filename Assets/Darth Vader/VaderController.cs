using UnityEngine;

public class VaderController : MonoBehaviour
{
    private Animator anim;
    private Vector3 posisiAwal;
    private Quaternion rotasiAwal;
    
    // Kita ganti saklar bool jadi Sistem Fase (Angka)
    // 0 = Standby / Santai
    // 1 = Nunggu animasi nyerang dimulai (keluar dari Idle)
    // 2 = Nunggu animasi selesai dan waktunya ditarik pulang
    private int faseBalik = 0;

    void Start()
    {
        anim = GetComponent<Animator>();
        posisiAwal = transform.localPosition;
        rotasiAwal = transform.localRotation;
    }

    void Update()
    {
        // FASE 1: Memastikan Unity udah bener-bener ganti gaya ke animasi nyerang
        if (faseBalik == 1)
        {
            // Kalau gayanya UDAH BUKAN "Idle" (berarti udah sukses mulai nyerang)
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                faseBalik = 2; // Lanjut ke Fase 2: Siap-siap ditarik pulang
            }
        }
        // FASE 2: Nungguin gaya nyerangnya kelar, lalu tarik pulang dengan smooth
        else if (faseBalik == 2)
        {
            // Kalau gayanya UDAH KEMBALI ke "Idle" (berarti gaya nyerang udah beres)
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                // Mulai proses narik mundur
                transform.localPosition = Vector3.Lerp(transform.localPosition, posisiAwal, Time.deltaTime * 5f);
                transform.localRotation = Quaternion.Lerp(transform.localRotation, rotasiAwal, Time.deltaTime * 5f);

                // Kalau posisinya udah nyaris pas di tengah persis
                if (Vector3.Distance(transform.localPosition, posisiAwal) < 0.01f)
                {
                    // Kunci posisinya, biar Lean Touch bisa bebas nyubit/nggeser lagi
                    transform.localPosition = posisiAwal;
                    transform.localRotation = rotasiAwal;
                    
                    faseBalik = 0; // Balik ke mode Standby
                }
            }
        }
    }

    // Sambungkan fungsi ini ke Tombol UI
    public void PemicuTombolMaju()
    {
        // Syarat faseBalik == 0 ini penting biar pas dia lagi nyerang, 
        // tombolnya nggak error walau lu pencet (spam) berkali-kali
        if (anim != null && faseBalik == 0)
        {
            anim.SetTrigger("Maju");
            faseBalik = 1; // Mulai jalankan Fase 1
        }
    }
}