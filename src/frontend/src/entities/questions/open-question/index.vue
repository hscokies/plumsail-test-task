<script setup>
import { TextField } from '@/shared/ui'
import {computed, ref} from "vue";
import { COMMON_VALIDATORS } from "@/shared/lib";
const props = defineProps({
  question: Object
})

const validator = computed(() => COMMON_VALIDATORS[props.question.validator] || COMMON_VALIDATORS.text);
const triggered = ref(false)
const value = ref('')
const error = ref('')
const onChange = (event) => {
  value.value = event.target.value.trim()
  triggered.value = true;
  validate();
}

const validate = () => {
  error.value = validator.value.check(value.value)
}

defineExpose({triggered, error, validate, value})
</script>

<template>
  <TextField
      @focusout="triggered = true"
      :id="'question'+question.id"
      :name="question.id.toString()"
      :label="question.title"
      :placeholder="question.placeholder"
      :value="value"
      :error="error"
      :helper-text="validator.helperText"
      @changed="e => onChange(e)"
      type="text"/>
</template>
