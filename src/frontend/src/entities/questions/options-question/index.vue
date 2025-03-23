<script setup>
import {RadioButton, FormGroup, TextField} from '@/shared/ui'
import {computed, ref} from "vue";
import { COMMON_VALIDATORS } from "@/shared/lib";
const props = defineProps({
  question: Object
})

const validator = computed(() => COMMON_VALIDATORS[props.question.validator] || COMMON_VALIDATORS.radio);
const triggered = ref(false)
const value = ref()
const error = ref()

const OnChange = (event, id) => {
  triggered.value = true;
  const isChecked = event.target.checked;
  if (isChecked) {
    value.value = id;
  }

  validate();
}

const validate = () => {
  error.value = validator.value.check(value.value);
}

defineExpose({triggered, error, validate, value})
</script>

<template>
<FormGroup
    :name="question.id.toString()"
    :label="question.title"
    :error="error">
  <RadioButton
      v-for="option in question.options"
      :id="'question'+question.id"
      :name="question.id"
      :label="option.label"
      :value="option.id"
      :checked="value === option.id"
      @changed="e => OnChange(e, option.id)"
  />
</FormGroup>
</template>

<style scoped>

</style>