using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Vector3 _positionOffset;
    [SerializeField] private Transform _cameraTarget;

    private void LateUpdate()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        transform.position = _cameraTarget.position - _positionOffset;
    }
}
