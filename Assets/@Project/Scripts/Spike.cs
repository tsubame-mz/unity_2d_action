using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour {
    // プレイヤーの被弾アニメーション
    public PlayerHit m_playerHitPrefab;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D other) {
        // プレイヤーと衝突した場合
        if (other.name.Contains("Player")) {
            // プレイヤーを削除する
            Destroy(other.gameObject);

            // シーン内のCameraShakerスクリプトを検索する
            var cameraShaker = FindObjectOfType<CameraShaker>();
            cameraShaker.Shake();

            // 2秒後にリトライする
            Invoke("OnRetry", 2);

            // 被弾アニメーションを生成
            Instantiate(m_playerHitPrefab, other.transform.position, Quaternion.identity);
        }
    }

    // シーンを読み直してリトライする
    private void OnRetry() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
