using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    public GameObject gameOverCutscene;
    private Animator _animator;

    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _animator = transform.parent.gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _meshRenderer.material.SetColor("_TintColor", new Color(0.6f, 0.11f, 0.11f, 0.0225f));
            StartCoroutine(freezeCamera());
            gameOverCutscene.SetActive(true);
        }
    }
    IEnumerator freezeCamera()
    {
        _animator.enabled = false;
        yield return new WaitForSeconds(0.5f);
    }
}
