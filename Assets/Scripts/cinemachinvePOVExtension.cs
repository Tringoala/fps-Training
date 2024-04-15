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
        if (startingRotation == null) startingRotation = transform.localRotation.eulerAngles;
    }
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (vcam.Follow)
        {
            if(stage == CinemachineCore.Stage.Aim)
            {
                Vector2 deltaInput = iManager.getMouseDelta();
                startingRotation.x += deltaInput.x * Time.deltaTime * verticalSpeed;
                startingRotation.y += deltaInput.y * Time.deltaTime * horizontalSpeed;
                startingRotation.y = Mathf.Clamp(startingRotation.y, -clampAngle, clampAngle);
                state.RawOrientation = Quaternion.Euler(-startingRotation.y, startingRotation.x, 0f);
                
                vcam.Follow.parent.parent.rotation = Quaternion.Euler(0f, startingRotation.x - 90, 0f);//head->model->player

                vcam.Follow.rotation = Quaternion.Euler(vcam.Follow.rotation.x, startingRotation.x - 90, startingRotation.y);
                
            }
        }

    }
}
