using System;
using System.Collections;
using System.Collections.Generic;
using Tobii.Gaming;
using UnityEngine;

public class LeapMotionMoveFollowingEyeTracker : MonoBehaviour
{
    //-------------------------------------------------------------------------
    // Public members
    //-------------------------------------------------------------------------

    /* Extended View settings - passed to underlying API */
    public TobiiExtendedViewSettings ExtendedViewSettings;

    /* Control how how Extended View angles collapse/expand when entering/leaving aim mode */
    //public bool CollapseWhenAiming = true;
    //public float AimAtGazeCollapseSpeed = 5;
    //public float AimAtGazeExpandTime = 5;

    public Vector3 OriginPoint = Vector3.zero;
    public float Radius = 1f;
    public float TurnMultiplier = 1.5f;
    public Transform HandParentTransform;
    public Camera _usedCamera;

    //public bool IsAiming { get; set; }

    public float Yaw { get; private set; }

    public float Pitch { get; private set; }

    public float HeadRotationScalar { get; set; }


    //-------------------------------------------------------------------------
    // Private members
    //-------------------------------------------------------------------------

    private Camera _cameraWithoutExtendedView;
    private Camera _cameraWithExtendedView;

    private float _extendedViewYaw;
    private float _extendedViewPitch;

    private DateTime _lastAimatGazeTime = DateTime.Now;


    //-------------------------------------------------------------------------
    // Public properties
    //-------------------------------------------------------------------------

    public virtual Camera CameraWithoutExtendedView
    {
        get
        {
            if (_cameraWithoutExtendedView != null && _cameraWithoutExtendedView.gameObject != null)
                return _cameraWithoutExtendedView;

            var cameraGo = new GameObject("CameraTransformWithoutExtendedView");

            cameraGo.transform.parent = null;

            _cameraWithoutExtendedView = cameraGo.AddComponent<Camera>();
            _cameraWithoutExtendedView.enabled = false;
            return _cameraWithoutExtendedView;
        }
    }

    public virtual Camera CameraWithExtendedView
    {
        get
        {
            if (_cameraWithExtendedView != null && _cameraWithExtendedView.gameObject != null)
                return _cameraWithExtendedView;

            var cameraGo = new GameObject("CameraTransformWithExtendedView");

            cameraGo.transform.parent = null;

            _cameraWithExtendedView = cameraGo.AddComponent<Camera>();
            _cameraWithExtendedView.enabled = false;
            TobiiAPI.SetCurrentUserViewPointCamera(CameraWithExtendedView);
            return _cameraWithExtendedView;
        }
    }

    protected virtual void UpdateSettings()
    {
        ExtendedViewSettings.Clamp();

        TobiiAPI.SetExendedViewSettings(ExtendedViewSettings);
    }

    protected virtual void UpdateTransform()
    {
        var localRotation = transform.localRotation;

        UpdateCameraWithoutExtendedView(_usedCamera);
        var worldUp = Vector3.up;
        Rotate(transform, fovScalar: TurnMultiplier, up: worldUp);
        UpdateCameraWithExtendedView(_usedCamera);

        StartCoroutine(ResetCameraLocal(localRotation, transform));
    }

    protected virtual void Start()
    {
        //_usedCamera = GetComponentInChildren<Camera>();
    }


    //--------------------------------------------------------------------
    // MonoBehaviour event functions (messages)
    //--------------------------------------------------------------------
    protected virtual void LateUpdate()
    {
        UpdateSettings();


        // Fetch Yaw & Pitch from API
        var extendedViewAngles = TobiiAPI.GetExtendeViewAngles();

        /*if (IsAiming && CollapseWhenAiming)
        {
            // while entering aim mode, collapse Extended View angles to zero
            var lerpStep = Time.unscaledDeltaTime * AimAtGazeCollapseSpeed;
            _extendedViewYaw = Mathf.Lerp(_extendedViewYaw, 0.0f, lerpStep);
            _extendedViewPitch = Mathf.Lerp(_extendedViewPitch, 0.0f, lerpStep);
            _lastAimatGazeTime = DateTime.Now;
        }
        else if (DateTime.Now < _lastAimatGazeTime.AddSeconds(AimAtGazeExpandTime))
        {
            // when leaving aim mode, expand lerp towards latest Extended View angles
            float t = (float)(DateTime.Now - _lastAimatGazeTime).TotalSeconds / (AimAtGazeExpandTime);
            var lerpStep = Mathf.Clamp01(t);

            _extendedViewYaw = Mathf.Lerp(_extendedViewYaw, extendedViewAngles.Yaw, lerpStep);
            _extendedViewPitch = Mathf.Lerp(_extendedViewPitch, extendedViewAngles.Pitch, lerpStep);
        }*/
        /*else
        {*/
        // or else use Extended View angles unmodified
        _extendedViewYaw = extendedViewAngles.Yaw;
        _extendedViewPitch = extendedViewAngles.Pitch;
        //}

        Yaw = _extendedViewYaw;
        Pitch = _extendedViewPitch;


        UpdateTransform();
    }


    //-------------------------------------------------------------------------
    // Protected/public virtual functions
    //-------------------------------------------------------------------------

    public virtual void AimAtWorldPosition(Vector3 worldPosition)
    {
        /* empty default implementation */
    }

    //-------------------------------------------------------------------------
    // Protected functions
    //-------------------------------------------------------------------------

    protected void InitAimAtGazeOffset(float yaw, float pitch)
    {
        _extendedViewYaw = yaw;
        _extendedViewPitch = pitch;
    }

    protected void UpdateCameraWithoutExtendedView(Camera mainCamera)
    {
        UpdateCamera(CameraWithoutExtendedView, mainCamera);
    }

    protected void UpdateCameraWithExtendedView(Camera mainCamera)
    {
        UpdateCamera(CameraWithExtendedView, mainCamera);
    }

    protected void UpdateCamera(Camera cameraToUpdate, Camera mainCamera)
    {
        cameraToUpdate.transform.position = mainCamera.transform.position;
        cameraToUpdate.transform.rotation = mainCamera.transform.rotation;
        cameraToUpdate.fieldOfView = mainCamera.fieldOfView;
    }

    protected void Rotate(Component componentToRotate, float fovScalar = 1f, Vector3 up = new Vector3())
    {
        var componenetAsTransform = componentToRotate as Transform;
        var transformToRotate = componenetAsTransform != null ? componenetAsTransform : componentToRotate.transform;

        transformToRotate.Rotate(Pitch * fovScalar, 0.0f, 0.0f, Space.Self);

        if (up == new Vector3())
        {
            transformToRotate.Rotate(0.0f, Yaw * fovScalar, 0.0f, Space.World);
        }
        else
        {
            transformToRotate.Rotate(up, Yaw * fovScalar, Space.World);
        }

        var worldPos = transformToRotate.TransformPoint(Vector3.forward * Radius);
        HandParentTransform.position = worldPos + GameObject.Find("PlayerOBJ").transform.position;
        //HandParentTransform.rotation = transformToRotate.rotation;

        //HandParentTransform.rotation = transformToRotate.rotation;
    }

    protected IEnumerator ResetCameraLocal(Quaternion? rotation = null, Transform camTransform = null)
    {
        camTransform = camTransform ? camTransform : transform;
        rotation = rotation.HasValue ? rotation : Quaternion.identity;

        yield return new WaitForEndOfFrame();
        camTransform.localRotation = rotation.Value;
    }
}