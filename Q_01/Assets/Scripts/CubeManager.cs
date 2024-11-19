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

        _cubeController.SetPoint = _cubeSetPoint; // cubeController의 SetPoint값에 _cubeSetPoint를 줬다.
                                                  // set 접근자에 엑세스할 수 없어 SetPoint의 private set을 public으로 바꿨다.
        _cubeController.SetPosition();

        Debug.Log($"{_cubeSetPoint}"); // 로그를 통해 x,y,z가 3,0,3 값을 받는건 확인했다.
    }

    private void CreateCube()
    {
        GameObject cube = Instantiate(_cubePrefab);
        _cubeController = cube.GetComponent<CubeController>();
        _cubeSetPoint = _cubeController.SetPoint; // 큐브 위치를 cubeController의 setPoint에서 결정
    }
}
