using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Transform _body;
    [SerializeField] private ParticleSystem _bloodParticle;
    [SerializeField] private Blood _blood;

    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        StartCoroutine(RotateRoutine());
    }
    private IEnumerator RotateRoutine()
    {
        var rotationSpeed = 1;

        while (rotationSpeed < _rotationSpeed)
        {
            Rotate(rotationSpeed);
            yield return null;
            rotationSpeed++;
        }

        while (true)
        {
            Rotate(_rotationSpeed);
            yield return null;
        }
    }
    private void Rotate(float speed)
    {
        _transform.Rotate(0, 0, speed * Time.deltaTime);
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        Instantiate(_bloodParticle, collision.transform.position,Quaternion.identity);
        CameraShaker.instance.Shake();
        var blood = Instantiate(_blood, collision.transform.position + new Vector3(Random.value * 4, Random.value * 4), Quaternion.identity);
        blood.transform.localScale = Vector3.one * Random.Range(1f, 3f);
        blood.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 90));
        if (Random.value < 0.5f)
        {
            blood.transform.SetParent(_transform);
            blood.transform.localScale = Vector3.one * Random.Range(.5f, 1f);
            blood.transform.position = _transform.position + new Vector3(Random.Range(2.5f,2.7f),Random.Range(2.5f, 2.7f));
            blood.SpriteRenderer.sortingLayerName = "BloodBody";
            blood.SpriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        }
        if(Random.value < 0.25f)
        {
            blood.transform.SetParent(_body);
            blood.transform.position = _body.position + new Vector3(Random.Range(-2f,2f),Random.Range(-2f,2f));
            blood.transform.localScale = Vector3.one * Random.Range(.1f, 1f);
            blood.SpriteRenderer.sortingLayerName = "BloodBody";
            blood.SetAlpha(Random.Range(0.1f, 0.5f));
            blood.SpriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        }
        if(Random.value > 0.2f)
        {
            var enemy = collision.transform.GetComponentInChildren<SpriteRenderer>().transform;
            blood.transform.SetParent(enemy);
            blood.transform.position = enemy.position + new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
            blood.transform.localScale = Vector3.one * Random.Range(.1f, 1f);
            blood.SpriteRenderer.sortingLayerName = "BloodBody";
            blood.SetAlpha(Random.Range(0.1f, 0.5f));
            blood.SpriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        }
        if (Random.value < 0.05f)
        {
            blood = Instantiate(_blood, collision.transform.position, Quaternion.identity);
            blood.transform.localScale = Vector3.one * Random.Range(1f, 3f);
            blood.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 90));
            Destroy(collision.gameObject);
        }
    }
}
