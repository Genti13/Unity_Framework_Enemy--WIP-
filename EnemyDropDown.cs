using System;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyPanel))]
public class EnemyDropDown : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EnemyPanel script = (EnemyPanel)target;


        script.codeIA = EditorGUILayout.Popup("IA Type", script.codeIA, script.listOfIA.ToArray());
        showSelectedIAInfo(script.codeIA, script);

        showStats(script);
    }

    private void cargaDeScript(EnemyPanel enemy, Type script)
    {
        if (enemy.GetComponent(script) != null)
            return;
        enemy.gameObject.AddComponent(script);
    }

    private void eliminarScript(EnemyPanel enemy, Type script)
    {
        DestroyImmediate(enemy.gameObject.GetComponent(script));
    }

    private Boolean selectedIASection = true;
    private void showSelectedIAInfo(int indexIA, EnemyPanel enemy)
    {
        selectedIASection = EditorGUILayout.Foldout(selectedIASection, "IA Configuration", true);

        if (selectedIASection)
        {
            switch (indexIA)
            {
                case 0:
                    enemy.bullet = (Bullet)EditorGUILayout.ObjectField("Bullet", enemy.bullet, typeof(Bullet), true);
                    break;
                case 1:
                    EditorGUILayout.LabelField("Sword");
                    break;
            }
        }
    }

    private Boolean statsSection = true;
    private void showStats(EnemyPanel enemy)
    {
        statsSection = EditorGUILayout.Foldout(statsSection, "Stats", true);

        if (statsSection)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField("HP", GUILayout.MaxWidth(75));
            enemy.maxHP = EditorGUILayout.IntField(enemy.maxHP, GUILayout.MaxWidth(50));


            EditorGUILayout.LabelField("Speed", GUILayout.MaxWidth(100));
            enemy.speed = EditorGUILayout.IntField(enemy.speed, GUILayout.MaxWidth(50));

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField("Damage", GUILayout.MaxWidth(75));
            enemy.dmg = EditorGUILayout.IntField(enemy.dmg, GUILayout.MaxWidth(50));

            EditorGUILayout.LabelField("Contact Damage", GUILayout.MaxWidth(100));
            enemy.contactDamage = EditorGUILayout.IntField(enemy.contactDamage, GUILayout.MaxWidth(50));

            EditorGUILayout.LabelField("Attack Rate", GUILayout.MaxWidth(75)); //Timer
            enemy.attackRate = EditorGUILayout.FloatField(enemy.attackRate, GUILayout.MaxWidth(50));

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField("Attack Range", GUILayout.MaxWidth(75));
            enemy.attackRange = EditorGUILayout.FloatField(enemy.attackRange, GUILayout.MaxWidth(50));

            EditorGUILayout.LabelField("Detection Range", GUILayout.MaxWidth(100));
            enemy.detectionRange = EditorGUILayout.FloatField(enemy.detectionRange, GUILayout.MaxWidth(50));

            EditorGUILayout.EndHorizontal();

        }


    }

}
