<script setup>
import {Checkbox, FormGroup} from "@/shared/ui/index.js";
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
      :error="error"
      :label="question.title">
    <Checkbox
        v-for="option in question.options"
        :id="'multiple-options-question-'+question.id+'-option-'+option.id"
        :key="option.id"
        :checked="value.indexOf(option.id) >= 0"
        :label="option.label"
        :name="question.id"
        :value="option.id"
        @changed="e => OnChange(e, option.id)"/>
  </FormGroup>
</template>