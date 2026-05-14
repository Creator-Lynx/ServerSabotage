using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingController : MonoBehaviour
{
    InputAction fire;
    [SerializeField] Animator shotgunAnimator;
    int cachedFireTrigger;

    void Awake()
    {
        fire = InputSystem.actions.FindAction("Fire");
        cachedFireTrigger = Animator.StringToHash("Shot");
    }
    void Update()
    {
        if(fire.WasPressedThisFrame()) shotgunAnimator.SetTrigger(cachedFireTrigger);
    }
}
