using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Actor))]
public class ActorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Actor myActor = target as Actor;

        Actor.ActionTarget actionTarget;

        int unitHealth = myActor.hitPoints;
        int maxUnitHealth = myActor.maxHitPoints;
        int unitDamage = myActor.damage;
        int unitInitiative = myActor.initiative;
        int hitChance = myActor.percentChanceToHit;

        bool showHealth = true;
        bool toggleHealth = true;
        bool showCombat = true;
        bool showActionOptions = true;

        string health = "Health";
        string combat = "Combat";
        string hitPoints = "Hit Points";
        string maxHitPoints = "Max Hit Points";
        string damage = "Damage";
        string initiative = "Initiative";
        string percent = "Percent Chance to Hit";
        string options = "Action Options";

        
        showHealth = EditorGUILayout.Foldout(showHealth, health, toggleHealth);
        if (showHealth)
        {
            myActor.hitPoints = EditorGUILayout.IntField(hitPoints, unitHealth);
            if(myActor.maxHitPoints < myActor.hitPoints)
            {
                myActor.hitPoints = myActor.maxHitPoints;
            }
            myActor.maxHitPoints = EditorGUILayout.IntField(maxHitPoints, maxUnitHealth);
            if(maxUnitHealth > 5000)
            {
                myActor.maxHitPoints = 5000;
            }
        }

        showCombat = EditorGUILayout.Foldout(showCombat, combat);
        if (showCombat)
        {
            myActor.damage = EditorGUILayout.IntSlider(damage, unitDamage, 0, 180);

            myActor.initiative = EditorGUILayout.IntField(initiative, unitInitiative);
            unitInitiative = (unitInitiative / 5) * 5;
            myActor.initiative = unitInitiative;

            myActor.percentChanceToHit = EditorGUILayout.IntSlider(percent, hitChance, 0, 100);
            showActionOptions = EditorGUILayout.Foldout(showActionOptions, options);
            if (showActionOptions)
            {
                actionTarget = (Actor.ActionTarget)EditorGUILayout.EnumFlagsField(actionTarget);
            }
        }
            
    }
}
