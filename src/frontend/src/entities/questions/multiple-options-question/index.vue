<script setup>
import {FormGroup, Checkbox} from "@/shared/ui/index.js";
import {computed, ref} from "vue";
import {COMMON_VALIDATORS} from "@/shared/lib/index.js";

const props = defineProps({
  question: Object
})

const validator = computed(() => COMMON_VALIDATORS[props.question.validator] || COMMON_VALIDATORS.checkbox);
const triggered = ref(false)
const value = ref([])
const error = ref()

const OnChange = (event, id) => {
  const isChecked = event.target.checked;
  triggered.value = true;

  if (isChecked) {
    value.value.push(id);
    return validate();
  }

  value.value = value.value.filter(item => item !== id);
  
  validate();
}

const validate = () => {
  error.value = validator.value.check([...value.value]);
}

defineExpose({triggered, error, validate, value})
</script>

<template>
  <FormGroup
      :id="'multiple-options-question-'+question.id"
      :label="question.title"
      :error="error">
    <Checkbox 
        v-for="option in question.options"
        :key="option.id"
        :id="'multiple-options-question-'+question.id+'-option-'+option.id"
        :name="question.id" 
        :label="option.label" 
        :value="option.id" 
        :checked="value.indexOf(option.id) >= 0" 
        @changed="e => OnChange(e, option.id)"/>
  </FormGroup>
</template>