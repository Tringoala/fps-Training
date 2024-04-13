using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cinemachinvePOVExtension : CinemachineExtension
{
    private InputManager iManager;
    private Vector3 startingRotation;



    [SerializeField]
    private float horizontalSpeed = 10f;
    [SerializeField]
    private float verticalSpeed = 10f;
    [SerializeField]
    private float clampAngle = 80f;
    protected override void Awake()
    {
        iManager = InputManager.Instance;
        base.Awake();
    }
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (vcam.Follow)
        {
            if(stage == CinemachineCore.Stage.Aim)
            {
                if(startingRotation ==null)startingRotation = transform.localRotation.eulerAngles;
                Vector2 deltaInput = iManager.getMouseDelta();
                startingRotation.x += deltaInput.x * Time.deltaTime * verticalSpeed;
                startingRotation.y += deltaInput.y * Time.deltaTime * horizontalSpeed;
                startingRotation.y = Mathf.Clamp(startingRotation.y, -clampAngle, clampAngle);
                state.RawOrientation = Quaternion.Euler(-startingRotation.y, startingRotation.x, 0f);

            }
        }

    }
}
