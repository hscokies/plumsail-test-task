<script setup>
import {TextField} from '@/shared/ui'
import {computed, ref} from "vue";
import {COMMON_VALIDATORS} from "@/shared/lib";

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
      :id="'question'+question.id"
      :error="error"
      :helper-text="validator.helperText"
      :label="question.title"
      :name="question.id.toString()"
      :placeholder="question.placeholder"
      :value="value"
      type="text"
      @changed="e => onChange(e)"
      @focusout="triggered = true"/>
</template>
