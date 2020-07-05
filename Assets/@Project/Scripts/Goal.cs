using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
    // ゴールしたかどうか
    private bool m_isGoal;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D other) {
        // 未ゴールでプレイヤーが触れた場合
        if (!m_isGoal && other.name.Contains("Player")) {
            // カメラを揺らす
            var cameraShaker = FindObjectOfType<CameraShaker>();
            cameraShaker.Shake();

            m_isGoal = true;

            // ゴール時のアニメーションを再生
            var animator = GetComponent<Animator>();
            animator.Play("Pressed");
        }
    }
}
