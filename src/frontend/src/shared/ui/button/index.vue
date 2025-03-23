<script setup>
defineProps({
  type: String,
  variant: {
    type: String,
    default: 'primary',
  },
  size:{
    type: String,
    default: 'medium',
  }
})
</script>

<template>
  <button :class="['button', variant, size]" :type="type">
    <slot/>
  </button>
</template>

<style scoped>
.button{
  display: flex;
  align-items: center;
  cursor: pointer;
  border-radius: 8px;
  text-transform: capitalize;
  
  &.primary{
    color: #FFF;
    outline: 1px solid #7A5CFA;
    background-color: #7A5CFA;
  }
  
  &.secondary{
    color: #7A5CFA;
    outline: 1px solid #7A5CFA;
    background-color: #FFF;
  }
  
  &.small{
    font-size: 12px;
    line-height: 18px;
    padding: 16px 32px;
  }
  
  &.medium{
    font-size: 16px;
    line-height: 24px;
    padding: 16px 32px;
  }
  
  &.large{
    font-size: 24px;
    line-height: 36px;
    padding: 16px 64px;
  }
}
</style>