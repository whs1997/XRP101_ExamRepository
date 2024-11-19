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
        // 큐브컨트롤러를 가진 큐브 프리팹이 생성되기 전에 SetCubePosition을 불러와서
        // 생성되지 않은 큐브를 참조해 NullReferenceException 에러가 뜬다.
        // SetCubePosition을 CreateCube 뒤로 이동시켜 큐브가 생기는걸 확인했다.
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
