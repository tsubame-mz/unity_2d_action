using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
    // 背景がスクロールする速さ
    public Vector2 m_speed;

    // Start is called before the first frame update
    private void Start() { }

    // Update is called once per frame
    private void Update() {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        var material = spriteRenderer.material;

        // 背景のテクスチャをスクロールする
        material.mainTextureOffset += m_speed * Time.deltaTime;
    }
}
