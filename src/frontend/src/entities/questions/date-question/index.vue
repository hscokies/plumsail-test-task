<script setup>
import {computed, ref} from "vue";
import {DatePicker} from '@/shared/ui'
import {COMMON_VALIDATORS} from "@/shared/lib";

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
      :id="'date-question-'+question.id"
      :error="error"
      :label="question.title"
      :name="question.id"
      :value="value"
      format="yyyy/MM/dd"
      @changed="e => onChange(e)"
      @focusout="e => onChange(e)"/>
</template>