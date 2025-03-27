<script setup>

defineProps({
  loading: Boolean,
  variant: {
    type: String,
    default: 'passive',
  },
  color: {
    type: String,
    default: '#7A5CFA',
  }
})
</script>

<template>
  <div :class="['form-block', variant, loading && 'skeleton']" :style="'border-top-color:' + color">
    <slot/>
  </div>
</template>

<style scoped>
.form-block {
  position: relative;
  display: flex;
  flex-flow: column nowrap;
  width: 100%;
  padding: 22px 24px 24px 24px;
  border-radius: 8px;
  box-shadow: 0 2px 1px -1px rgba(0, 0, 0, .2), 0 1px 1px 0 rgba(0, 0, 0, .14), 0 1px 3px 0 rgba(0, 0, 0, .12);

  &.passive {
    border-top: none;
  }

  &.accent {
    border-top: 5px solid;
  }

  &.skeleton {
    height: 150px;
  }
}
</style>