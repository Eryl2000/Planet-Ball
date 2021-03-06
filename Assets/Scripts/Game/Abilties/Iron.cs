﻿using System.Collections;
using UnityEngine;

public class Iron : Ability
{
    public float Duration = 1f;
    public float IncreasedMass = 15f;
    public Sprite IronSprite;
    public Color IronColor = new Color32(167, 167, 167, 255);

    private float orignalMass;
    private Sprite originalSprite;
    private Color originalColor;
    private SpriteRenderer spriteRenderer;

    protected override void DerivedUpdate() { }

    protected override void UseAbility()
    {
        StartCoroutine(SetIron());
    }

    protected override void DerivedStart()
    {
        spriteRenderer = player.GetComponent<SpriteRenderer>();
        orignalMass = player.Body.mass;
        originalSprite = spriteRenderer.sprite;
        originalColor = spriteRenderer.color;
    }

    IEnumerator SetIron()
    {
        spriteRenderer.sprite = IronSprite;
        spriteRenderer.color = IronColor;
        player.Body.mass = IncreasedMass;
        yield return new WaitForSeconds(Duration);
        player.Body.mass = orignalMass;
        spriteRenderer.sprite = originalSprite;
        spriteRenderer.color = originalColor;
    }
}
