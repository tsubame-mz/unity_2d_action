using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour {
    // ジャンプする高さ
    public float m_jumpHeight = 10;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D other) {
        // プレイヤーと衝突した場合
        if (other.name.Contains("Player")) {
            // プレイヤーをジャンプさせる
            var motor = other.GetComponent<PlatformerMotor2D>();
            motor.ForceJump(m_jumpHeight);

            // トランポリンのジャンプ時アニメーションを再生する
            var animator = GetComponent<Animator>();
            animator.Play("Jump");
        }
    }
}
