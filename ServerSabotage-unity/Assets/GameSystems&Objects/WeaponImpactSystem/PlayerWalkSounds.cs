using UnityEngine;

public class PlayerWalkSounds : MonoBehaviour
{
    [Header("Step sound variant")]
    [SerializeField] AudioSource stepSource;
    [SerializeField] AudioClip stepClip;
    [SerializeField] float leftStepStepPitch = 1f;
    [SerializeField] float rigthStepPitch = 1.1f;

    [Header("Clang Sounds Variants")]
    [SerializeField] AudioSource weaponClangSource;
    [SerializeField] AudioClip[] weaponClangClip = new AudioClip[3];
    [SerializeField] float minimumClangPitch = 1f;
    [SerializeField] float maximumClangPitch = 1.05f;


    public void LeftStep()
    {
        stepSource.pitch = leftStepStepPitch;
        stepSource.PlayOneShot(stepClip);
        RandomClangPlay(0.15f);
    }

    public void RightStep()
    {
        stepSource.pitch = rigthStepPitch;
        stepSource.PlayOneShot(stepClip);
        RandomClangPlay(0.6f);
    }

    void RandomClangPlay(float chance)
    {
        if(Random.Range(0f, 1.0f) > chance) return;

        int i = Random.Range(0, 3);

        weaponClangSource.pitch = Random.Range(minimumClangPitch, maximumClangPitch);
        weaponClangSource.PlayOneShot(weaponClangClip[i]);
    }
}
