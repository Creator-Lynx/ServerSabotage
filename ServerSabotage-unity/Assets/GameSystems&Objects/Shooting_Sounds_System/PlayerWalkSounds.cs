using UnityEngine;

public class PlayerWalkSounds : MonoBehaviour
{
    [Header("Step sound variant")]
    [SerializeField] AudioSource stepSource;
    [SerializeField] AudioClip stepClip;

    [Header("Clang Sounds Variants")]
    [SerializeField] AudioSource weaponClang0Source;
    [SerializeField] AudioClip weaponClang0Clip;
    //[SerializeField] AudioSource weaponClang1Source;
    [SerializeField] AudioClip weaponClang1Clip;
    //[SerializeField] AudioSource weaponClang2Source;
    [SerializeField] AudioClip weaponClang2Clip;


    public void LeftStep()
    {
        Debug.Log("LeftStep");
    }

    public void RightStep()
    {
        Debug.Log("RightStep");
    }
}
