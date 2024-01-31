using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    private Enemy enemy;
    private ItemDrop myDropSystem;

    [Header("Level details")]
    [SerializeField] private int level = 1;

    [Range(0f, 1f)]
    [SerializeField] private float percentageModifier = .4f;
    protected override void Start()
    {
        applyLevelModifier();

        base.Start();

        enemy = GetComponent<Enemy>();
        myDropSystem = GetComponent<ItemDrop>();

    }

    private void applyLevelModifier()
    {
        modify(strength);
        modify(agility);
        modify(intelligence);
        modify(vitality);

        modify(damage);
        modify(critChance);
        modify(critPower);

        modify(maxHealth);
        modify(armor);
        modify(evasion);
        modify(magicResistance);

        modify(fireDamage);
        modify(iceDamage);
        modify(lightingDamage);


    }

    private void modify(Stat _stat)
    {
        for (int i = 1; i < level; i++)
        {
            float modifier = _stat.getValue() * percentageModifier;

            _stat.addModifier(Mathf.RoundToInt(modifier));
        }
    }
    public override void takeDamage(int _damage)
    {
        base.takeDamage(_damage);
    }

    protected override void die()
    {
        base.die();
        enemy.die();

        myDropSystem.generateDrop();
    }
}
