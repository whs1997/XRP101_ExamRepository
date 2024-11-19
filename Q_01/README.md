# 1번 문제

주어진 프로젝트 내에서 CubeManager 객체는 다음의 책임을 가진다
- 해당 객체 생성 시 Cube프리팹의 인스턴스를 생성한다
- Cube 인스턴스의 컨트롤러를 참조해 위치를 변경한다.

제시된 소스코드에서는 큐브 인스턴스 생성 후 아래의 좌표로 이동시키는 것을 목표로 하였다
- x : 3
- y : 0
- z : 3

제시된 소스코드에서 문제가 발생하는 `원인을 모두 서술`하시오.

## 답안
큐브컨트롤러를 가진 큐브 프리팹이 생성되기 전에 SetCubePosition을 불러와서 생성되지 않은 큐브를 참조해 NullReferenceException 에러가 뜬다.
SetCubePosition을 CreateCube 뒤로 이동시켜 큐브가 생기는걸 확인했다.

cubeController의 SetPoint값에 _cubeSetPoint를 줬다.
set 접근자에 엑세스할 수 없어 SetPoint의 private set을 public으로 바꿨다.
큐브가 생기고 3,0,3 으로 이동하는걸 확인했다.
