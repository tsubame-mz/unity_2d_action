using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlatform : MonoBehaviour {
    // 落ちる速さ
    public float m_speed = 0.3f;

    // 上に乗ったかどうか
    private bool m_isHit;

    private void Awake() {
        var motor = GetComponent<MovingPlatformMotor2D>();
        motor.onPlatformerMotorContact += OnContact;
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (m_isHit) {
            // 下に移動させていく
            var motor = GetComponent<MovingPlatformMotor2D>();
            motor.velocity = Physics2D.gravity * m_speed;
        }
    }

    private void OnContact(PlatformerMotor2D player) {
        // プレイヤーが落下中の場合(上から乗った)
        if (player.IsFalling()) {
            m_isHit = true;
        }
    }

}
