<script setup>
import {computed, ref} from "vue";
import {DatePicker, Dropdown, DropdownItem} from '@/shared/ui'
import { COMMON_VALIDATORS } from "@/shared/lib";
const props = defineProps({
  question: Object
})

const validator = computed(() => COMMON_VALIDATORS[props.question.validator] || COMMON_VALIDATORS.default);
const triggered = ref(false)
const value = ref(null)
const error = ref()

const onChange = (id, label) => {
  triggered.value = true
  value.value = {id: id, label: label}
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
          :name="question.id"
          :label="question.title"
          :placeholder="question.placeholder"
          :value="value?.label"
          :error="error">
        <DropdownItem
            v-for="item in question.options"
            :key="item.id"
            :label="item.label"
            @selected="onChange(item.id, item.label)"/>
      </Dropdown>
</template>

<style scoped>

</style>