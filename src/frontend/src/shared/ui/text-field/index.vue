<script setup>
defineProps({
  id: String,
  label: String,
  name: String,
  value: String,
  placeholder: String,
  helperText: String,
  type: {
    type: String,
    default: 'text'
  },
  error: Boolean,
  errorMessage: String,
})

defineEmits(['changed'])
</script>

<template>
  <div class="text-field_root">
    <label class="text-field_label" :for="id">
      {{ label }}
    </label>
    <input
        :class="['text-field_input', error && 'error']"
        :id="id"
        :name="name"
        :type="type"
        :placeholder="placeholder"
        :value="value"
        @change="$emit('changed', $event);"
    />
    <span class="text-field_helper-text" v-if="!error">
      {{ helperText }}
    </span>
    <span class="text-field_error-text" v-else-if="error">
      {{ errorMessage }}
    </span>
  </div>
</template>

<style scoped>
.text-field_root{
  display: inline-flex;
  flex-flow: column nowrap;
  gap: 8px;
  width: 100%;
}
.text-field_label {
  text-align: left;
  line-height: 18px;
  font-size: 12px;
  font-weight: 600;
  color: #666;
}

.text-field_input{
  padding: 16px;
  background-color: transparent;
  border: none;
  border-radius: 8px;
  outline: 1px solid #ccc;
  font-size: 16px;
  color: #333;

  &::placeholder {
    color: #666;
  }

  &:focus{
    outline: 2px solid #7A5CFA;
  }
  
  &.error{
    outline-color: #EB5757;
  }
}

.text-field_helper-text{
  text-align: left;
  line-height: 18px;
  font-size: 12px;
  font-weight: 600;
  color: #666;
}

.text-field_error-text{
  text-align: left;
  line-height: 18px;
  font-size: 12px;
  font-weight: 600;
  color: #EB5757;
}
</style>