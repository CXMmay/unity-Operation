using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 30f; // 球的速度

    // 當遊戲物件被實例化時執行
    void Start()
    {
        // 初始速度
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    // 當球碰撞到其他物體時執行
    void OnCollisionEnter2D(Collision2D col)
    {
        // 如果碰撞到的是球拍左邊的球拍
        if (col.gameObject.name == "RacketLeft")
        {
            // 計算撞擊因子
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

            // 計算方向，使長度為1
            Vector2 dir = new Vector2(1, y).normalized;

            // 設置速度
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        // 如果碰撞到的是球拍右邊的球拍
        if (col.gameObject.name == "RacketRight")
        {
            // 計算撞擊因子
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

            // 計算方向，使長度為1
            Vector2 dir = new Vector2(-1, y).normalized;

            // 設置速度
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }

    // 計算撞擊因子
    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        // ascii art:
        // ||  1 <- 在球的頂端
        // ||
        // ||  0 <- 在球的中間
        // ||
        // || -1 <- 在球的下面
        return (ballPos.y - racketPos.y) / racketHeight;
    }
}
