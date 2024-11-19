using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;

    private CubeController _cubeController;
    private Vector3 _cubeSetPoint;

    private void Awake()
    {
        // SetCubePosition(3, 0, 3);
    }

    private void Start()
    {
        // ť����Ʈ�ѷ��� ���� ť�� �������� �����Ǳ� ���� SetCubePosition�� �ҷ��ͼ�
        // �������� ���� ť�긦 ������ NullReferenceException ������ ���.
        // SetCubePosition�� CreateCube �ڷ� �̵����� ť�갡 ����°� Ȯ���ߴ�.
        CreateCube();

        SetCubePosition(3, 0, 3);
    }

    private void SetCubePosition(float x, float y, float z)
    {
        _cubeSetPoint.x = x;
        _cubeSetPoint.y = y;
        _cubeSetPoint.z = z;
        _cubeController.SetPosition();
    }

    private void CreateCube()
    {
        GameObject cube = Instantiate(_cubePrefab);
        _cubeController = cube.GetComponent<CubeController>();
        _cubeSetPoint = _cubeController.SetPoint;
    }
}
