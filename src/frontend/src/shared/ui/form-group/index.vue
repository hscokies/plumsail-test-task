<script setup>
defineProps({
  name: String,
  disabled: Boolean,
  label: String,
  error: {
    type: String,
    default: '',
  }
})
</script>

<template>
  <fieldset 
    class="form-group_root"
    :disabled="disabled"
    :name="name">
    <legend class="form-group_label">
      {{ label }}
    </legend>
    <div class="form-group_wrapper">
      <slot/>
    </div>
    <span v-if="error.length > 0" class="form-group_error">
      {{error}}
    </span>
  </fieldset>
</template>

<style scoped>
.form-group_root{
  display: flex;
  flex-direction: column;

  outline: none;
  border: none;
}

.form-group_wrapper{
  display: flex;
  flex-direction: column;
  gap: 16px;
}

.form-group_label{
  text-align: left;
  line-height: 18px;
  font-size: 12px;
  font-weight: 600;
  color: #666;
}

.form-group_error{
  text-align: left;
  line-height: 18px;
  font-size: 12px;
  font-weight: 600;
  color: #EB5757;
  margin-top: 5px;
}
</style>