using UnityEngine;

public class PlayerWalkSounds : MonoBehaviour
{
    [Header("Step sound variant")]
    [SerializeField] AudioSource stepSource;
    [SerializeField] AudioClip stepClip;
    [SerializeField] float leftStepStepPitch = 1f;
    [SerializeField] float rigthStepPitch = 1.1f;

    [Header("Clang Sounds Variants")]
    [SerializeField] AudioSource weaponClang0Source;
    [SerializeField] AudioClip weaponClang0Clip;
    //[SerializeField] AudioSource weaponClang1Source;
    [SerializeField] AudioClip weaponClang1Clip;
    //[SerializeField] AudioSource weaponClang2Source;
    [SerializeField] AudioClip weaponClang2Clip;


    public void LeftStep()
    {
        stepSource.pitch = leftStepStepPitch;
        stepSource.PlayOneShot(stepClip);
    }

    public void RightStep()
    {
        stepSource.pitch = rigthStepPitch;
        stepSource.PlayOneShot(stepClip);
    }
}
