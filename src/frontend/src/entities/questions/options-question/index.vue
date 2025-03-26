<script setup>
import {FormGroup, RadioButton} from '@/shared/ui'
import {computed, ref} from "vue";
import {COMMON_VALIDATORS} from "@/shared/lib";

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
      :error="error"
      :label="question.title"
      :name="question.id.toString()">
    <RadioButton
        v-for="option in question.options"
        :id="'question'+question.id"
        :checked="value === option.id"
        :label="option.label"
        :name="question.id"
        :value="option.id"
        @changed="e => OnChange(e, option.id)"
    />
  </FormGroup>
</template>

<style scoped>

</style>