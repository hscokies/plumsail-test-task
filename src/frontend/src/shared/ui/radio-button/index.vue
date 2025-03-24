<script setup>
defineProps({
  id: String,
  name: String | Number,
  label: String,
  value: String | Number,
  checked: Boolean,
})

defineEmits(['changed'])
</script>

<template>
  <div class="radio-button_root">
    <input
        :id="id"
        :checked="checked"
        :name="name"
        :value="value"
        class="radio-button_input"
        type="radio"
        @change="$emit('changed', $event);"
    />
    <div class="radio-button_radio">
      <span class="radio-button_radio-dot"/>
    </div>
    <label :for="id" class="radio-button_label">
      {{ label }}
    </label>
  </div>
</template>

<style scoped>
.radio-button_root {
  position: relative;
  display: inline-flex;
  gap: 16px;
  align-items: center;
  cursor: pointer;
  vertical-align: middle;
}

.radio-button_input {
  cursor: inherit;
  position: absolute;
  opacity: 0;
  width: 100%;
  height: 100%;
  z-index: 1;
}

.radio-button_radio {
  display: flex;
  justify-content: center;
  align-items: center;
  border: 1px solid #CCC;
  border-radius: 32px;
  background: transparent;
  width: 24px;
  height: 24px;
}

.radio-button_radio-dot {
  display: inline-block;
  width: 12px;
  height: 12px;
  border-radius: 50%;

  transition: background-color .2s ease-in-out;
}

.radio-button_input:checked + .radio-button_radio > .radio-button_radio-dot {
  background: #7A5CFA;
}

.radio-button_label {
  text-align: left;
  line-height: 24px;
  font-size: 16px;
  color: #666;
}
</style>