<script setup>
import {computed, ref} from "vue";
import {DatePicker} from '@/shared/ui'
import {COMMON_VALIDATORS} from "@/shared/lib";

const props = defineProps({
  question: Object,
})

const validator = computed(() => COMMON_VALIDATORS[props.question.validator] || COMMON_VALIDATORS.date);
const triggered = ref(false)
const dateValue = ref(null)
const value = ref(null)
const error = ref('')

const onChange = (event) => {
  const date = new Date(event.target.value);
  validateInternal(date);

  triggered.value = true;
  dateValue.value = error.value ? null : date;
  value.value = date?.toISOString().split('T')[0];
}

const validateInternal = (date) => {
  error.value = validator?.value.check(date)
}
const validate = () => validateInternal(dateValue.value);

defineExpose({triggered, error, validate, value})
</script>

<template>
  <DatePicker
      :id="'date-question-'+question.id"
      :error="error"
      :label="question.title"
      :name="question.id"
      :value="dateValue"
      format="yyyy/MM/dd"
      @changed="e => onChange(e)"
      @focusout="e => validate(e)"/>
</template>