# 4번 문제

주어진 프로젝트는 다음의 기능을 구현하고자 생성한 프로젝트이다.

### 1. Player
- 상태 패턴을 사용해 Idle 상태와 Attack 상태를 관리한다.
- Idle상태에서 Q를 누르면 Attack 상태로 진입한다
  - 진입 시 2초 이후 지정된 구형 범위 내에 있는 데미지를 입을 수 있는 적을 탐색해 데미지를 부여하고 Idle상태로 돌아온다
- 상태 머신 : 각 상태들을 관리하는 객체이며, 가장 첫번째로 입력받은 상태를 기본 상태로 설정한다.

### 2. NormalMonster
- 데미지를 입을 수 있는 몬스터

### 3. ShieldeMonster
- 데미지를 입지 않는 몬스터

위 기능들을 구현하고자 할 때
제시된 프로젝트에서 발생하는 `문제들을 모두 서술`하고 올바르게 동작하도록 `소스코드를 개선`하시오.

## 답안

Q를 누르면 Attack 상태로 진입해 NormalMonster를 공격하고 Idle로 돌아와야 하는데 참조 에러가 뜨면서 계속 Attack 상태에 머무른다.
StateAttack 스크립트에서 
damagable = col.GetComponent<IDamagable>();
if (damagable != null)
{
    damagable.TakeHit(Controller.AttackValue);
}
다음과같이 null 값 검사를 추가했더니 StateMachine.ChangeState가 계속 뜨는 스택 오버플로우 에러가 발생했다.

StateAttack의 Exit()에서 ChangeState를 호출, ChangeState에서 CurrentState.Exit();를 호출하면서 StateAttack의 Exit가 계속 발생돼 에러가 생기는거같다.
Exit()를 주석처리하니 오류가 생기지 않는걸 확인했다.
Exit()에 있던 Machine.ChangeState(StateType.Idle);를 Attack()에서 공격 뒤로 이동시켰더니 정상적으로 돌아가는걸 확인햇다.
