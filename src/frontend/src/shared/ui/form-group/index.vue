<script setup>
defineProps({
  name: String,
  disabled: Boolean,
  label: String,
  error: String,
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
    <p :class="['form-group_error', error?.length > 0 && 'active']">
      {{error}}
    </p>
  </fieldset>
</template>

<style scoped>
.form-group_root{
  display: flex;
  flex-direction: column;

  outline: none;
  border: none;
  
  padding: 0;
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
  margin-bottom: 8px;
}

.form-group_error{
  visibility: hidden;
  text-align: left;
  line-height: 18px;
  font-size: 12px;
  font-weight: 600;
  min-height: 18px;
  color: #EB5757;
  margin-top: 5px;
  &.active{
    visibility: visible;
  }
}
</style>