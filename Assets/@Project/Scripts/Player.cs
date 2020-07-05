using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    // プレイヤーの被弾アニメーション
    public PlayerHit m_playerHitPrefab;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    // プレイヤー被弾時
    public void Dead() {
        // 非表示にする
        this.gameObject.SetActive(false);

        // シーン内のCameraShakerスクリプトを検索する
        var cameraShaker = FindObjectOfType<CameraShaker>();
        cameraShaker.Shake();

        // 2秒後にリトライする
        Invoke("OnRetry", 2);

        // 被弾アニメーションを生成
        Instantiate(m_playerHitPrefab, transform.position, Quaternion.identity);

    }

    // シーンを読み直してリトライする
    private void OnRetry() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
