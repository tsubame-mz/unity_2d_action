using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour {
    // カメラを揺らす時間
    public float m_duration = 0.25f;

    // カメラを揺らす強さ
    public float m_magnitude = 0.1f;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    // カメラを揺らす
    public void Shake() {
        StartCoroutine(DoShake());
    }

    private IEnumerator DoShake() {
        // カメラの元の位置
        var pos = transform.localPosition;

        // カメラを揺らし始めてからの経過時間
        var elapsed = 0f;

        while (elapsed < m_duration) {
            // ランダムに動かす
            var x = pos.x + Random.Range(-1f, +1f) * m_magnitude;
            var y = pos.y + Random.Range(-1f, +1f) * m_magnitude;
            transform.localPosition = new Vector3(x, y, pos.z);

            elapsed += Time.deltaTime;
            yield return null;  // 1フレーム待機
        }

        // 揺らし終わったらカメラの位置を戻す
        transform.localPosition = pos;
    }

}
