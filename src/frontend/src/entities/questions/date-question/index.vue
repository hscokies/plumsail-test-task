<script setup>
import {computed, ref} from "vue";
import {DatePicker} from '@/shared/ui'
import { COMMON_VALIDATORS } from "@/shared/lib";
const props = defineProps({
  question: Object
})

const validator = computed(() => COMMON_VALIDATORS[props.question.validator] || COMMON_VALIDATORS.date);
const triggered = ref(false)
const value = ref(null)
const error = ref('')

const onChange = (event) => {
  const date = new Date(event.target.value);
  validateInternal(date);

  triggered.value = true;
  value.value = error.value ? null : date;
}

const validateInternal = (date) => {
  error.value = validator?.value.check(date)
}
const validate = () => validateInternal(value.value);

defineExpose({triggered, error, validate, value})
</script>

<template>
      <DatePicker
          @focusout="e => onChange(e)"
          :id="'date-question-'+question.id"
          :name="question.id"
          :label="question.title"
          :value="value"
          :error="error"
          @changed="e => onChange(e)"
          format="yyyy/MM/dd"/>
</template>