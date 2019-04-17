using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Actor))]
public class ActorEditor : Editor
{
    bool showHealth = false;
    bool showCombat = false;
    bool showActionOptions = false;

    
    public override void OnInspectorGUI()
    {
        Actor myActor = target as Actor;

       
        int unitHealth = myActor.hitPoints;
        int maxUnitHealth = myActor.maxHitPoints;
        int unitDamage = myActor.damage;
        int unitInitiative = myActor.initiative;
        int hitChance = myActor.percentChanceToHit;

        
        bool toggleHealth = true;      
        

        string health = "Health";
        string combat = "Combat";
        string hitPoints = "Hit Points";
        string maxHitPoints = "Max Hit Points";
        string damage = "Damage";
        string initiative = "Initiative";
        string percent = "Percent Chance to Hit";
        string options = "Action Options";

        myActor.actorName = EditorGUILayout.TextField("Unit Name", myActor.actorName);
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
                myActor.actionTarget = (Actor.ActionTarget)EditorGUILayout.EnumPopup("Select a target", myActor.actionTarget);
                myActor.actionEffect = (Actor.ActionEffect)EditorGUILayout.EnumPopup("Select an effect", myActor.actionEffect);
                myActor.actionEffectSource = (Actor.ActionSource)EditorGUILayout.EnumPopup("Select an effect source", myActor.actionEffectSource);
                
            }
            myActor.targetSelectionRule = (Actor.TargetSelectionRule)EditorGUILayout.EnumPopup("Select an AI type", myActor.targetSelectionRule);
        }

        EditorGUILayout.LabelField("Current Target: ", myActor.targetName);
        
        myActor.boardPosition = (Actor.Position)EditorGUILayout.EnumPopup("Select a board position", myActor.boardPosition);
            
    }
}
