﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EGamePlay.Combat
{
    /// <summary>
    /// 
    /// </summary>
    public class ExecutionEffectComponent : Component
    {
        public List<ExecutionEffect> ExecutionEffects { get; private set; } = new List<ExecutionEffect>();
        //public ExecutionEffect DamageExecutionEffect { get; set; }
        //public ExecutionEffect CureExecutionEffect { get; set; }


        public override void Setup(object initData)
        {
            var abilityEffects = initData as List<AbilityEffect>;
            foreach (var abilityEffect in abilityEffects)
            {
                //var executionEffect = Entity.AddChild<ExecutionEffect>(abilityEffect);
                //AddEffect(executionEffect);

                //if (abilityEffect.EffectConfig is DamageEffect)
                //{
                //    DamageExecutionEffect = executionEffect;
                //}
                //if (abilityEffect.EffectConfig is CureEffect)
                //{
                //    CureExecutionEffect = executionEffect;
                //}
            }
            foreach (var effect in GetEntity<SkillExecution>().SkillExecutionData.ExecutionEffects)
            {
                var executionEffect = Entity.AddChild<ExecutionEffect>(effect);
                AddEffect(executionEffect);
            }
        }

        public void AddEffect(ExecutionEffect executionEffect)
        {
            ExecutionEffects.Add(executionEffect);
        }

        public void FillEffects(List<ExecutionEffect> executionEffects)
        {
            this.ExecutionEffects.Clear();
            this.ExecutionEffects.AddRange(executionEffects);
        }

        public void ApplyAllEffectsTo(CombatEntity targetEntity)
        {
            if (ExecutionEffects.Count > 0)
            {
                foreach (var executionEffect in ExecutionEffects)
                {
                    executionEffect.ApplyEffectTo(targetEntity);
                }
            }
        }

        public void ApplyEffectByIndex(CombatEntity targetEntity, int index)
        {
            ExecutionEffects[index].ApplyEffectTo(targetEntity);
        }
    }
}