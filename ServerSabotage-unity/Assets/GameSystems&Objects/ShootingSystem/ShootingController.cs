using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingController : MonoBehaviour
{
    InputAction fireAction;
    [SerializeField] Animator shotgunAnimator;
    int cachedFireTrigger, cachedMoveBool;
    [SerializeField] AudioSource shotAudioSource;
    [SerializeField] AudioClip shotAudioClip;
    public static bool WeaponReady = true;

    InputAction moveAction;

    void Awake()
    {
        fireAction = InputSystem.actions.FindAction("Fire");
        cachedFireTrigger = Animator.StringToHash("Shot");
        cachedMoveBool = Animator.StringToHash("IsWalk");
        moveAction = InputSystem.actions.FindAction("Move");
    }
    void Update()
    {
        if(WeaponReady)
        if(fireAction.WasPressedThisFrame()) 
        {
            shotgunAnimator.SetTrigger(cachedFireTrigger);
            shotAudioSource.PlayOneShot(shotAudioClip);
            WeaponReady = false;
        }


        shotgunAnimator.SetBool(cachedMoveBool, moveAction.inProgress);

    }
}
