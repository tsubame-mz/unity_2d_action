using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PC2D;

public class Enemy : MonoBehaviour {
    // 移動制御用
    private PlatformerMotor2D m_motor;

    // スプライト表示用
    private SpriteRenderer m_renderer;

    // 当たり判定管理用
    private BoxCollider2D m_colider;

    // 被弾アニメーション
    public GameObject m_hitPrefab;

    private void Awake() {
        m_motor = GetComponent<PlatformerMotor2D>();
        m_motor.normalizedXMovement = -1;   // 左に移動する

        m_renderer = GetComponent<SpriteRenderer>();
        m_renderer.flipX = false;   // 左向き

        m_colider = GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        // 現在の進行方向を取得
        var dir = (0 < m_motor.normalizedXMovement) ? Vector3.right : Vector3.left;

        // 進行方向にタイルマップがあるかチェックする
        var offset = m_colider.size.y * 0.5f;
        var hit = Physics2D.Raycast(
            transform.position - new Vector3(0, offset, 0), dir,
            m_colider.size.x * 0.55f, Globals.ENV_MASK
        );

        if (hit.collider != null) {
            // 移動方向を反転させる
            m_motor.normalizedXMovement *= -1;
            m_renderer.flipX = !m_renderer.flipX;
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        // プレイヤーと衝突した場合
        if (other.name.Contains("Player")) {
            var motor = other.GetComponent<PlatformerMotor2D>();

            // プレイヤーが落下中の場合(踏まれた)
            if (motor.IsFalling()) {
                // 自身を削除
                Destroy(this.gameObject);

                // プレイヤーをジャンプさせる
                motor.ForceJump();

                // カメラを揺らす
                var cameraShaker = FindObjectOfType<CameraShaker>();
                cameraShaker.Shake();

                // 被弾アニメーションを生成
                Instantiate(m_hitPrefab, transform.position, Quaternion.identity);
            }
            else {
                // プレイヤーの被弾時イベントを呼び出す
                var player = other.GetComponent<Player>();
                player.Dead();
            }
        }
    }
}
