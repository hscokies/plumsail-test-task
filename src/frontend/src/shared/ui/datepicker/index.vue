<script setup>
import { Calendar } from '@/shared/ui/icons'
import {useOutsideClick} from "@/shared/lib/index.js";
import {ref} from "vue";
defineProps({
  id: String,
  name: String,
  label: String,
  value: Date,
  placeholder: String,
  format: {
    type: String,
    default: 'yyyy-MM-dd',
  },
})
defineEmits(['changed'])

const { elementRef, active, toggleActive } = useOutsideClick();

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
    <label class="datepicker_label" :for="id">
      {{label}}
    </label>
    <div
        @click="toggleActive"
        ref="elementRef"
        :class="['datepicker_input-wrapper', active && 'active']">
      <input
          ref="dateInput"
          :id="id"
          :name="name"
          :value="formatDate(value, format)"
          @change="$emit('changed', $event)"
          :placeholder="placeholder || format" 
          :maxlength="format.length"
          autocomplete="off"
          class="datepicker_input"/>
      <input
          @change="$emit('changed', $event)"
          type="date"
          class="datepicker_picker"
          ref="datepicker" />
      <Calendar @click="datepicker.showPicker()"/>
    </div>
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

.datepicker_label{
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
}
.datepicker_picker{
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
</style>