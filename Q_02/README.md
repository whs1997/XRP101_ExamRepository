# 2번 문제

주어진 프로젝트 내에서 제공된 스크립트(클래스)는 다음의 책임을 가진다
- PlayerStatus : 플레이어 캐릭터가 가지는 기본 능력치를 보관하고, 객체 생성 시 초기화한다
- PlayerMovement : 유저의 입력을 받고 플레이어 캐릭터를 이동시킨다.

프로젝트에는 현재 2가지 문제가 있다.
- 유니티 에디터에서 Run 실행 시 윈도우에서는 Stack Overflow가 발생하고, MacOS의 유니티에서는 에디터가 강제종료된다.
- 플레이어 캐릭터가 X, Z축의 입력을 동시입력 받아서 대각선으로 이동 시 하나의 축 기준으로 움직일 때 보다 약 1.414배 빠르다.

두 가지 문제가 발생한 원인과 해결 방법을 모두 서술하시오.

## 답안
Assets/Scripts/PlayerStatus.cs:10
private set => MoveSpeed = value; 에서 문제가 발생한다.
뭔가에 무한루프가 걸려서 별도의 moveSpeed 값을 만들어 getter setter의 MoveSpeed 대신 moveSpeed를 넣어주니 에러가 사라졌다.
대각선으로 빠른건 이동할때 direction에 normalized를 넣어주니 해결됐다.
