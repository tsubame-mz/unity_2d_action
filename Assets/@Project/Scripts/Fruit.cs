using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {

    // アイテム獲得時のエフェクト
    public GameObject m_collectedPrefab;

    // 獲得時のSE
    public AudioClip m_collectedClip;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D other) {
        // プレイヤーと衝突した場合
        if (other.name.Contains("Player")) {
            // アイテム獲得時のエフェクトを生成
            var collected = Instantiate(m_collectedPrefab, transform.position, Quaternion.identity);

            // エフェクト再生時間(秒)を取得
            var animator = collected.GetComponent<Animator>();
            var info = animator.GetCurrentAnimatorStateInfo(0);
            var time = info.length;

            // エフェクトの再生が終了したら削除
            Destroy(collected, time);

            // 自身を削除
            Destroy(this.gameObject);

            // 獲得時のSEを再生
            var audioSource = FindObjectOfType<AudioSource>();
            audioSource.PlayOneShot(m_collectedClip);
        }
    }
}
