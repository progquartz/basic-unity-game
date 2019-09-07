using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    // public game object reference to the player
    // private vector3 to hold the vector value
    public GameObject player;

    private Vector3 offset; // 이 offset값은 스크립트 내에서 값을 지정할것이기 대문에, private이다.

    // offset 값은 현재의 카메라의 transform 의 위치를 받아낸 다음에, 이를 player의 transform으로 바꿔서 둘의 차이를 나타내는데에 사용할 것이다.
    void Start()
    { 
        offset = transform.position - player.transform.position;   // 신기하게, 앞에 그 객체가 없으면 굳이 this. 와 같은걸 하지 않더라도 가능하다.
                                                                   // 당연히, this도 된다. 걱정말것.

    }

    // Update is called once per frame
    void LateUpdate() // lateupdate는 무조건 Update가 다 완료된 다음에 되도록 만들어진 update 형식이다. 그러면 무조건적으로 플레이어는 이동이 된 상태일것이고, 이로 인해서 카메라는 확실한 이동이 가능하다.
    {
        // 매 프레임마다 업데이트를 진행. 
        transform.position = player.transform.position + offset; // player가 움직일때마다 매 프레임의 행동 전에 카메라가 플레이어의 위치에 맞게 함께 움직임을 뜻한다.
                                                                      // 하지만 이런 상황에서는 update가 최고는 아니다. 따라가는 카메라의 계속되는 움직임과 이전의 상태를 모아서 작동하는것은 lastupdate가 더 적합하다.                                                                             
    } 
}
