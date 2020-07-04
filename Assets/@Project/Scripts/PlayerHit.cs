using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour {
    // アニメーション中の移動速度
    public Vector3 m_velocity = new Vector3(0, 15, 0);

    // アニメーション中にかかる重力の強さ
    public float m_gravity = 30;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        // 移動させる
        transform.localPosition += m_velocity * Time.deltaTime;

        // 落下するようにしていく
        m_velocity.y -= m_gravity * Time.deltaTime;
    }
}
