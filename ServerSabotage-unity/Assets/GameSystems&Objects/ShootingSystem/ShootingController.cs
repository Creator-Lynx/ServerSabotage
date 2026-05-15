using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingController : MonoBehaviour
{
    InputAction fire;
    [SerializeField] Animator shotgunAnimator;
    int cachedFireTrigger;
    [SerializeField] AudioSource shotAudioSource;
    [SerializeField] AudioClip shotAudioClip;
    public static bool WeaponReady = true;

    void Awake()
    {
        fire = InputSystem.actions.FindAction("Fire");
        cachedFireTrigger = Animator.StringToHash("Shot");
    }
    void Update()
    {
        if(WeaponReady)
        if(fire.WasPressedThisFrame()) 
        {
            shotgunAnimator.SetTrigger(cachedFireTrigger);
            shotAudioSource.PlayOneShot(shotAudioClip);
            WeaponReady = false;
        }
    }
}
