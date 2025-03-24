<script setup>
import {Checkmark} from '@/shared/ui/icons'

defineProps({
  id: String | Number,
  name: String | Number,
  label: String,
  value: String | Number,
  checked: Boolean,
})

defineEmits(['changed'])
</script>

<template>
  <div class="checkbox_root">
    <input
        :id="id"
        :checked="checked"
        :name="name"
        :value="value"
        class="checkbox_input"
        type="checkbox"
        @change="$emit('changed', $event);"
    />
    <div class="checkbox_box">
      <Checkmark v-if="checked"/>
    </div>
    <label class="checkbox_label">
      {{ label }}
    </label>
  </div>
</template>

<style scoped>
.checkbox_root {
  position: relative;
  display: inline-flex;
  gap: 16px;
  align-items: center;
  cursor: pointer;
  vertical-align: middle;
}

.checkbox_input {
  cursor: inherit;
  position: absolute;
  opacity: 0;
  width: 100%;
  height: 100%;
  z-index: 1;
}

.checkbox_box {
  display: flex;
  justify-content: center;
  align-items: center;
  border: 1px solid #CCC;
  border-radius: 8px;
  background: transparent;
  width: 24px;
  height: 24px;
}

.checkbox_input:checked + .checkbox_box > .checkbox_checkmark {
  background: #7A5CFA;
}

.checkbox_label {
  text-align: left;
  line-height: 24px;
  font-size: 16px;
  color: #666;
}
</style>