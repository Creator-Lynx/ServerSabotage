using Unity.Multiplayer.PlayMode;
using UnityEngine;

public class WeaponInertAnimation : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;
    [SerializeField] float smoothing;
    [SerializeField] Vector2 extremumRotation;
    [SerializeField] Vector2 extremumShift;

    Vector3 defaultPosition;
    Vector3 defaultRotation;

    Vector3 cameraCachedRotation;
    [Header("current camera velocity (test)")]
    [SerializeField] Vector2 deltaRotation;
    void Update()
    {
        //part 1: get a camera velocity
        deltaRotation.x = (cameraTransform.eulerAngles - cameraCachedRotation).y;
        deltaRotation.y = (cameraTransform.eulerAngles - cameraCachedRotation).x;
        cameraCachedRotation = cameraTransform.eulerAngles;

        //part 2: shift by velocity

        //part 3?: move to default position

    }


    void Start()
    {
        defaultPosition = transform.localPosition;
        defaultRotation = transform.localEulerAngles;
    }
}
