using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // transform의 public 함수인 rotate와 translate를 이용하여 다음의 작업을 수행한다..
        // 왜 vector3인가? 라고 한다면,x축을 기준으로 돌리느냐, y축 기준으로 돌리느냐, z축 기준으로 돌리느냐인데,
        // 아시다시피 z축이 2d상에선 보이지 않는 점축이기 때문에, 이를 기준으로 돌려야지만 정상적으로 xy축에 뿌리를 두고 있는 오브젝트들이 회전이 가능하다.
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);  // deltatime을 곱하는 이유는, 
    }
}
