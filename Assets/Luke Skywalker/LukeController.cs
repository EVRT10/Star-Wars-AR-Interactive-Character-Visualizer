using UnityEngine;

public class LukeController : MonoBehaviour
{
    private Animator anim;
    private Vector3 posisiAwal;
    private Quaternion rotasiAwal;
    private int faseBalik = 0;

    void Start()
    {
        anim = GetComponent<Animator>();
        posisiAwal = transform.localPosition;
        rotasiAwal = transform.localRotation;
    }

    void Update()
    {
        if (faseBalik == 1)
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                faseBalik = 2; 
            }
        }
        else if (faseBalik == 2)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, posisiAwal, Time.deltaTime * 5f);
                transform.localRotation = Quaternion.Lerp(transform.localRotation, rotasiAwal, Time.deltaTime * 5f);

                if (Vector3.Distance(transform.localPosition, posisiAwal) < 0.01f)
                {
                    transform.localPosition = posisiAwal;
                    transform.localRotation = rotasiAwal;
                    faseBalik = 0; 
                }
            }
        }
    }

    public void PemicuTombolLuke()
    {
        if (anim != null && faseBalik == 0)
        {
            anim.SetTrigger("LukeMaju");
            faseBalik = 1; 
        }
    }
}