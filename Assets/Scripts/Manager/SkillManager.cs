using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoSingleton<SkillManager>
{
    [SerializeField]
    private GameObject _thunderSkill = null;

    private float _thunderCurrentCoolTime = 0f;

    [SerializeField]
    private Transform[] _enemyBundle = null;

    private Image _thunderCoolTimeImage = null;

    private void Start()
    {
        _thunderCoolTimeImage = FindObjectOfType<CombatCanvasButtonManager>().transform.GetChild(1).GetChild(0).GetComponent<Image>();
        _thunderCurrentCoolTime = 10f;
    }

    private void Update()
    {
        if (_thunderCurrentCoolTime > 0f)
        {
            _thunderCurrentCoolTime -= Time.deltaTime;
        }

        if (_thunderCoolTimeImage != null)
        {
            _thunderCoolTimeImage.fillAmount = 1 - (_thunderCurrentCoolTime / 10f);
        }
    }

    public void ThunderSkill()
    {
        if (_thunderCurrentCoolTime > 0f)
            return;

        Debug.Log("ThunderSkill");
        Transform nearestEnemy = null;

        _thunderCurrentCoolTime = 10f;

        for (int i = 0; i < _enemyBundle.Length; i++)
        {
            if (nearestEnemy == null)
            {
                nearestEnemy = _enemyBundle[i];
            }
            else
            {
                if (Vector3.Distance(nearestEnemy.position, Camera.main.transform.position) > Vector3.Distance(_enemyBundle[i].position, Camera.main.transform.position))
                {
                    nearestEnemy = _enemyBundle[i];
                }
            }
        }

        if (nearestEnemy != null)
        {
            GameObject thunder = Instantiate(_thunderSkill, nearestEnemy.position, Quaternion.identity);
            nearestEnemy.gameObject.GetComponent<Tank>().TakeDamage(10f);
            Destroy(thunder, 0.5f);
        }
    }
}
