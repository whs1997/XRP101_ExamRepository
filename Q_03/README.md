# 3번 문제

주어진 프로젝트 는 다음의 기능을 구현하고자 생성한 프로젝트이다.

### 1. Turret
- Trigger 범위 내로 플레이어가 들어왔을 때 1.5초에 한번씩 플레이어를 바라보면서 총알을 발사한다
- Trigger 범위 바깥으로 플레이어가 나가면 발사를 중지한다.
- 오브젝트 풀을 사용해 총알을 관리한다.

### 2. Bullet :
- 20만큼의 힘으로 전방을 향해 발사된다
- 발사 후 5초 경과 시 비활성화 처리된다
- 플레이어를 가격했을 경우 2의 데미지를 준다

### 3. Player
- 총알과 충돌했을 때, 데미지를 입는다
- 체력이 0 이하가 될 경우 효과음을 재생하며 비활성화된다.
- 플레이어의 이동은 씬 뷰를 사용해 이동하도록 한다.

위 기능들을 구현하고자 할 때
제시된 프로젝트에서 발생하는 `문제들을 모두 서술`하고 올바르게 동작하도록 `소스코드를 개선`하시오.

## 답안

플레이어를 터렛 옆으로 이동시켜도 총알을 발사하지 않는다.
플레이어 body에 Rigidbody를 추가해 발사하는걸 확인했다. 총알에도 Rigidbody가 없는데 불러오려고 하는 오류가 나와 Rigidbody를 넣었다.

NullReferenceException: Object reference not set to an instance of an object
BulletController.OnTriggerEnter (UnityEngine.Collider other) (at Assets/Scripts/BulletController.cs:29)
플레이어컨트롤러한테 _damageValue만큼 TakeHit을 시켜야 하는데 참조 에러가 뜬다.

body의 부모 오브젝트 Player에서 PlayerController를 가져와 TakeHit을 하게 했더니 체력이 닳는걸 확인했다.
총알이 플레이어를 뚫고 지나가 코드를 살펴보니 ReturnPool로 구현이 돼있어 TakeHit 이후 ReturnPool을 하게 했다.

총알이 계속 빨라지는 문제가 생겨 ReturnPool 에서 _rigidbody.velocity = Vector3.zero;를 추가해 오브젝트풀에 돌아갈 때 속도가 없어지게 만들었다.

플레이어가 죽을 때 소리가 안난다.
별도의 사운드매니저 오브젝트를 만들고 싱글톤 인스턴스를 만들어 Die에서 인스턴스의 PlaySound를 재생하게했다.
