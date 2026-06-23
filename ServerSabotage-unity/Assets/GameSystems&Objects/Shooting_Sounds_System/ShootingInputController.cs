using UnityEditor.Localization.Plugins.XLIFF.V12;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingInputController : MonoBehaviour
{
    InputAction fireAction;
    [SerializeField] Animator shotgunAnimator;
    int cachedFireTrigger, cachedMoveBool;
    [SerializeField] AudioSource shotAudioSource;
    [SerializeField] AudioClip shotAudioClip;
    public static bool WeaponReady = true;

    [SerializeField] float movingMagnitudeThreshold = 0.08f;
    [SerializeField] CharacterController characterController;

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

        Vector3 horizontalMoving = characterController.velocity;
        horizontalMoving.y = 0;
        shotgunAnimator.SetBool(cachedMoveBool, horizontalMoving.magnitude >= movingMagnitudeThreshold);

        float verticalSpeed = characterController.velocity.y; //use later for vertical speed to implify animations and sounds
    }
}
