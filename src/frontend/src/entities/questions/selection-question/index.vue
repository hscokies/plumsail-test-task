<script setup>
import {computed, ref} from "vue";
import {Dropdown, DropdownItem} from '@/shared/ui'
import {COMMON_VALIDATORS} from "@/shared/lib";

const props = defineProps({
  question: Object,
  color: String,
})

const validator = computed(() => COMMON_VALIDATORS[props.question.validator] || COMMON_VALIDATORS.default);
const triggered = ref(false)
const title = ref(null)
const value = ref(null)
const error = ref()

const onChange = (id, label) => {
  triggered.value = true
  value.value = id;
  title.value = label
  validate(value.value)
}

const validate = () => {
  error.value = validator.value.check(value.value)
}

defineExpose({triggered, error, validate, value})
</script>

<template>
  <Dropdown
      :id="'selection-question-'+question.id"
      :error="error"
      :label="question.title"
      :name="question.id"
      :placeholder="question.placeholder || question.title"
      :value="title"
      :color="color">
    <DropdownItem
        v-for="item in question.options"
        :key="item.id"
        :label="item.label"
        @selected="onChange(item.id, item.label)"/>
  </Dropdown>
</template>

<style scoped>

</style>