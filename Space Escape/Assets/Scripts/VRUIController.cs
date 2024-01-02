using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRUIController : MonoBehaviour
{
    public Camera mainCamera; // ���� ī�޶� ���⿡ �Ҵ��մϴ�.
    public float distanceFromCamera = 1f; // UI�� ī�޶� ������ �Ÿ� ����

    void Start()
    {
        // UI�� �׻� �ֻ����� �������ǵ��� Sorting Layer ����
        Canvas canvas = GetComponent<Canvas>();
        canvas.sortingLayerName = "TimerUI";
        canvas.sortingOrder = 999; // ������ ���ڷ� ���� (�ٸ� ��ü�� �������� ���ƾ� ��)
    }

    void Update()
    {
        if (mainCamera == null)
        {
            Debug.LogError("Main Camera not assigned in VRUIController!");
            return;
        }

        // ī�޶��� ��ġ�� ȸ���� ����ϴ�.
        Vector3 cameraPosition = mainCamera.transform.position;
        Quaternion cameraRotation = mainCamera.transform.rotation;

        // UI�� ī�޶��� ���� ��ܿ� ������ŵ�ϴ�.
        Vector3 uiPosition = cameraPosition + cameraRotation * Vector3.forward * distanceFromCamera;
        transform.position = uiPosition;
        transform.rotation = cameraRotation;
    }
}
