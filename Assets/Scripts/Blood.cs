using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer => _renderer;
    private SpriteRenderer _renderer;
    public void SetAlpha(float alpha)
    {
        _renderer.color = new Color(_renderer.color.r, _renderer.color.g, _renderer.color.b, alpha);
    }
    private void Awake()
    {
        _renderer = GetComponentInChildren<SpriteRenderer>();
        SetAlpha(Random.Range(0.7f, 1));
        StartCoroutine(ÑlottingRoutine());
    }
    private IEnumerator ÑlottingRoutine()
    {
        for(var i = 1f; i >= 0.5f; i-=0.005f)
        {
            _renderer.color = new Color(i,_renderer.color.g,_renderer.color.b);
            yield return new WaitForSeconds(1);
        }
        StartCoroutine(DisappearanceRoutine());
    }
    private IEnumerator DisappearanceRoutine()
    {
        for (var i = _renderer.color.a; i >= 0; i -= 0.01f)
        {
            _renderer.color = new Color(_renderer.color.r, _renderer.color.g, _renderer.color.b, i);
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(gameObject);
    }
}
