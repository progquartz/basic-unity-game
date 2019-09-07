using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float Horizontal_speed;
    public float Vertical_speed;
    public Text countText;
    public Text winText;
    private Rigidbody2D rb2d;
    private int count;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        SetCountText(); // 이런 경우는 무조건 count value뒤에 count를 두어야만 한다.
    }

    private void FixedUpdate()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal"); // movehorizontal 은 키보드로 제어되는 horizontal 에서 나온 입력값을 받아 저장한다.
        float moveVertical = Input.GetAxis("Vertical"); // movehorizontal 은 키보드로 제어되는 horizontal 에서 나온 입력값을 받아 저장한다.
        // 이 GetAxis를 받아내는 키들은 모두 다 InputManager에서 확인 / 수정 가능하다고 한다.

        // 무튼 한번 플레이어를 움직일 수 있도록 해보도록 노력해보자.
        // 오브젝트 하나에 힘을 주는 그렇고 그러한 일들을 어떻게 하는지 보도록 하자. 
        // rigidbody2D를 사용했음. 이를 사용했기 때문에 2D상에서 움직이는 '강체' 표현이 가능함 (유체는 또 다른 컴포넌트로 만들어질듯.)

        Vector2 movement = new Vector2(moveHorizontal, moveVertical); // Vector2에 moveHorizontal 과 moveVertical 값을 넣어준다.
        movement.x = movement.x * Horizontal_speed; // public float인 Horizontal_speed 를 이용해, 이를 movement.x 값에 곱해 넣음으로써 x값의 이동정도를 조절 가능함.
        movement.y = movement.y * Vertical_speed;
        rb2d.AddForce(movement); 

        /*
        추후, backgrount 와 player 에 collider를 넣는다. player의 경우에는 원인 형태를 따라 circle collider를 , background에는 box collider의 집합으로 이를만들었다.
        player와 같은 경우는, 다른 collider와 겹치게 되면, rigidbody2d이기 때문에 힘을 받아 이동이 된다. 그에 반해, background에는 rigidbody 컴포넌트가 없기 때문에, 힘을 받지 않는다.

         */
    }

    private void OnTriggerEnter2D(Collider2D other) // OnTriggerEnter2D는 이 오브젝트 (Player gmae object)가 처음으로 2D의 trigger collider를 만졌을때 된다.
        // 이를 조금 다른 용도로 사용할 건데, 이를 가지고 만약 충돌하였을 경우 충돌한 pickup object를 deactivate하게 할 예정이다
        // 이를 하기 위해서는 tag와 SetActive의 도움이 필요하다. 
        // tag는 게임의 오브젝트를 string 형태의 tag로 구별할 수 있도록 해주는 착한 친구이며,
        // Setactive는 해당 오브젝트를 activate 하는지, deactivate할지에 대해 찾을 수 있도록 해준다.
        // CompareTag도 사용할것인데, 이는 게임 오브젝트를 효율적으로 string 값으로 비교할 수 있게 해준다.
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();  
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 10)
        {
            winText.text = "you win!";
        }
    }
}
