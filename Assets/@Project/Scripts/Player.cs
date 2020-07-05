using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    // プレイヤーの被弾アニメーション
    public PlayerHit m_playerHitPrefab;

    // ジャンプ時のSE
    public AudioClip m_jumpClip;

    // 被弾時のSE
    public AudioClip m_hitClip;

    // ジャンプ時のSEをスキップするかどうか
    public bool IsSkipJumpSe;

    private void Awake() {
        var motor = GetComponent<PlatformerMotor2D>();
        motor.onJump += OnJump;
    }

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

        // 被弾時のSEを再生
        var audioSource = FindObjectOfType<AudioSource>();
        audioSource.PlayOneShot(m_hitClip);
    }

    // シーンを読み直してリトライする
    private void OnRetry() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // ジャンプ時
    private void OnJump() {
        if (IsSkipJumpSe) {
            IsSkipJumpSe = false;
        }
        else {
            // ジャンプ時のSEを再生
            var audioSource = FindObjectOfType<AudioSource>();
            audioSource.PlayOneShot(m_jumpClip);
        }
    }

}
