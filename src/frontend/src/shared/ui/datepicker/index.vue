<script setup>
import {Calendar} from '@/shared/ui/icons'
import {useOutsideClick} from "@/shared/lib/index.js";
import {ref} from "vue";

defineProps({
  id: String,
  name: String | Number,
  label: String,
  value: Date,
  placeholder: String,
  error: String,
  color: String,
  format: {
    type: String,
    default: 'yyyy-MM-dd',
  },
})
defineEmits(['changed'])

const {elementRef, active, toggleActive} = useOutsideClick();

const datepicker = ref(null);

const formatDate = (value, format) => {
  if (!(value instanceof Date)) {
    return null;
  }
  const day = value.getDate().toString().padStart(2, '0');
  const month = (value.getMonth() + 1).toString().padStart(2, '0');
  const year = value.getFullYear();
  return format
      .replace("dd", day)
      .replace("MM", month)
      .replace("yyyy", year);
}
</script>

<template>
  <div class="datepicker_root">
    <label :for="id" class="datepicker_label">
      {{ label }}
    </label>
    <div
        ref="elementRef"
        :class="['datepicker_input-wrapper', active && 'active', error?.length > 0 && 'error']"
        @click="toggleActive">
      <input
          :id="id"
          ref="dateInput"
          :maxlength="format.length"
          :name="name"
          :placeholder="placeholder || format"
          :value="formatDate(value, format)"
          autocomplete="off"
          class="datepicker_input"
          @change="$emit('changed', $event)"/>
      <input
          ref="datepicker"
          class="datepicker_picker"
          type="date"
          @change="$emit('changed', $event)"/>
      <Calendar :color="error ? '#EB5757' : color" @click="datepicker.showPicker()"/>
    </div>
    <span :class="['datepicker_error', error?.length > 0 && 'active']">{{ error }}</span>
  </div>
</template>

<style scoped>
.datepicker_root {
  position: relative;
  width: 100%;
  display: inline-flex;
  flex-flow: column nowrap;
  gap: 8px;
}

.datepicker_label {
  text-align: left;
  line-height: 18px;
  font-size: 12px;
  font-weight: 600;
  color: #666;
}

.datepicker_input-wrapper {
  display: inline-flex;
  align-items: center;
  justify-content: space-between;
  padding: 16px;
  background-color: transparent;
  border-radius: 8px;
  font-size: 16px;
  line-height: 24px;
  color: #333;
  outline: 1px solid #ccc;
  cursor: pointer;
  transition: outline-color .2s ease-in-out;

  &.active {
    outline: 2px solid #7A5CFA;
  }

  &.error {
    outline-color: #EB5757;
  }
}

.datepicker_picker {
  position: absolute;
  top: 0;
  right: 0;
  opacity: 0;
}

.datepicker_input {
  width: 100%;
  background-color: transparent;
  border: none;
  outline: none;
  font-size: 16px;
  color: #333;

  &::placeholder {
    color: #666;
  }
}

.datepicker_error {
  visibility: hidden;
  text-align: left;
  line-height: 18px;
  font-size: 12px;
  font-weight: 600;
  min-height: 18px;
  color: #EB5757;

  &.active {
    visibility: visible;
  }
}
</style>