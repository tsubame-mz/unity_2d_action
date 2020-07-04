using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour {
    // 移動距離
    public Vector3 m_distance = new Vector3(5, 0, 0);

    // 移動速度
    public float m_speed = 0.5f;

    // 開始位置
    private Vector3 m_startPosition;

    // 終了位置
    private Vector3 m_endPosition;


    private void Awake() {
        m_startPosition = transform.localPosition;
        m_endPosition = m_startPosition + m_distance;
    }

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        var t = Mathf.PingPong(Time.time * m_speed, 1); // 0～1を往復する
        // 次の位置を計算
        var newPosition = Vector3.Lerp(m_startPosition, m_endPosition, t);
        transform.localPosition = newPosition;
    }
}
