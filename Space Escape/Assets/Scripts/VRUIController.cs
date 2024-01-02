using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRUIController : MonoBehaviour
{
    public Camera mainCamera; // 메인 카메라를 여기에 할당합니다.
    public float distanceFromCamera = 1f; // UI와 카메라 사이의 거리 조정

    void Start()
    {
        // UI가 항상 최상위에 렌더링되도록 Sorting Layer 설정
        Canvas canvas = GetComponent<Canvas>();
        canvas.sortingLayerName = "TimerUI";
        canvas.sortingOrder = 999; // 적절한 숫자로 설정 (다른 객체의 순서보다 높아야 함)
    }

    void Update()
    {
        if (mainCamera == null)
        {
            Debug.LogError("Main Camera not assigned in VRUIController!");
            return;
        }

        // 카메라의 위치와 회전을 얻습니다.
        Vector3 cameraPosition = mainCamera.transform.position;
        Quaternion cameraRotation = mainCamera.transform.rotation;

        // UI를 카메라의 우측 상단에 고정시킵니다.
        Vector3 uiPosition = cameraPosition + cameraRotation * Vector3.forward * distanceFromCamera;
        transform.position = uiPosition;
        transform.rotation = cameraRotation;
    }
}
